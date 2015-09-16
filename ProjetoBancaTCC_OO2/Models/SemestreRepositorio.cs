using MySql.Data.MySqlClient;
using PeixeiraConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBancaTCC_OO2.Models
{
    public class SemestreRepositorio
    {
        Database conn = new Database();

        public IEnumerable<Semestre> getAll()
        {
            List<Semestre> semestres = new List<Semestre>();

            string sql = "SELECT * FROM semestres";
            MySqlDataReader dr = conn.executarConsulta(sql);

            while (dr.Read())
            {
                semestres.Add(new Semestre((int)dr["id"], (string)dr["nome"]));
            }

            return semestres;
        }

        public Semestre getOne(int pId)
        {
            string sql = "SELECT * FROM semestres where id = " + pId;
            MySqlDataReader dr = conn.executarConsulta(sql);
            dr.Read();
            Semestre semEdit = new Semestre((int)dr["id"], (string)dr["nome"]);

            return semEdit;
        }

        public void Create(Semestre pSemestre)
        {
            string insert = "INSERT INTO semestres VALUES (";
            insert += pSemestre.Id + ",'" + pSemestre.Nome + "')";

            conn.executarComando(insert);
        }

        public void Delete(int pId)
        {
            string deleteSql = "DELETE FROM semestres WHERE id = " + pId;

            conn.executarComando(deleteSql);
        }

        public void Update(Semestre pSemestre)
        {
            string updateSql = "UPDATE semestres SET nome = " + pSemestre.Nome + " WHERE id = " + pSemestre.Id;

            conn.executarComando(updateSql);
        }
    }
}