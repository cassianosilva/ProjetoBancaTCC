using MySql.Data.MySqlClient;
using PeixeiraConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBancaTCC_OO2.Models
{
    public class DisciplinaRepositorio
    {
        Database conn = new Database();

        public IEnumerable<Disciplina> getAll()
        {
            List<Disciplina> disciplinas = new List<Disciplina>();

            string sql = "SELECT * FROM disciplinas";
            MySqlDataReader dr = conn.executarConsulta(sql);

            while (dr.Read())
            {
                disciplinas.Add(new Disciplina((int)dr["id"], (string)dr["nome"]));
            }

            return disciplinas;
        }

        public Disciplina getOne(int pId)
        {
            string sql = "SELECT * FROM disciplinas WHERE id = " + pId;
            MySqlDataReader dr = conn.executarConsulta(sql);
            dr.Read();
            Disciplina discEdit = new Disciplina((int)dr["id"], (string)dr["nome"]);

            return discEdit;
        }

        public void Create(Disciplina pDisciplina)
        {
            string insert = "INSERT INTO disciplinas VALUES (";
            insert += pDisciplina.Id + ",'" + pDisciplina.Nome + "')";

            conn.executarComando(insert);
        }

        public void Delete(int pId)
        {
            string deleteSql = "DELETE FROM disciplinas WHERE id = " + pId;

            conn.executarComando(deleteSql);
        }

        public void Update(Disciplina pDisciplina)
        {
            string updateSql = 
            "UPDATE disciplinas SET nome = " + pDisciplina.Nome + " WHERE id = " + pDisciplina.Id;

            conn.executarComando(updateSql);
        }
    }
}