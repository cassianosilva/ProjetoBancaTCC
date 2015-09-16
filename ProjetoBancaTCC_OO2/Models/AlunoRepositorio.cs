using MySql.Data.MySqlClient;
using PeixeiraConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBancaTCC_OO2.Models
{
    public class AlunoRepositorio
    {
        Database conn = new Database();

        public IEnumerable<Aluno> getAll()
        {
            List<Aluno> alunos = new List<Aluno>();

            string sql = "SELECT * FROM alunos";
            MySqlDataReader dr = conn.executarConsulta(sql);

            while (dr.Read())
            {
                alunos.Add(new Aluno((int)dr["id"], (string)dr["nome"]));
            }

            return alunos;
        }

        public Aluno getOne(int pId)
        {
            string sql = "SELECT * FROM alunos WHERE id = " + pId;
            MySqlDataReader dr = conn.executarConsulta(sql);
            dr.Read();
            Aluno alunoEditando = new Aluno((int)dr["id"], (string)dr["nome"]);

            return alunoEditando;
        }

        public void Create(Aluno pAluno)
        {
            string insert = "INSERT INTO alunos VALUES (";
            insert += pAluno.Id + ",'" + pAluno.Nome + "')";

            conn.executarComando(insert);
        }

        public void Delete(int pId)
        {
            string deleteSql = "DELETE FROM alunos WHERE id = " + pId;

            conn.executarComando(deleteSql);
        }

        public void Update(Aluno pAluno)
        {
            string updateSql = "UPDATE alunos SET nome = " + pAluno.Nome + " WHERE id = " + pAluno.Id;

            conn.executarComando(updateSql);
        }
    }
}