using MySql.Data.MySqlClient;
using PeixeiraConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBancaTCC_OO2.Models
{
    public class ProfessorRepositorio
    {
        Database conn = new Database();

        public IEnumerable<Professor> getAll()
        {
            List<Professor> professores = new List<Professor>();

            string sql = "SELECT * FROM professores";
            MySqlDataReader dr = conn.executarConsulta(sql);
            
            while (dr.Read())
            {
                professores.Add(
                    new Professor((int)dr["id"], (string)dr["nome"]));
                                       
            }
            return professores;

        }

        public Professor getOne(int pId)
        {
            string sql = "SELECT * FROM professores WHERE id = " + pId;
            MySqlDataReader dr = conn.executarConsulta(sql);
            dr.Read();
            Professor profEdit = new Professor((int)dr["id"], (string)dr["nome"]);

            return profEdit;
        }
 
        public void Create(Professor pProf)
        {
            string insert = "INSERT INTO professores VALUES (";
            insert += pProf.Id + ",'" + pProf.Nome + "')";

            conn.executarComando(insert);
        }

        public void Delete(int pId)
        {
            string deleteSql = "DELETE FROM professores WHERE id = " + pId;

            conn.executarComando(deleteSql);
        }

        public void Update(Professor pProf)
        {
            string updateSql = "UPDATE professores SET nome = " + pProf.Nome + " WHERE id = " + pProf.Id;
            conn.executarComando(updateSql);
        }
    }
}