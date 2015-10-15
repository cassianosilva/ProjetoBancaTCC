using MySql.Data.MySqlClient;
using PeixeiraConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ProjetoDespesaG1_LPOO2.Models
{
    public class TipoDespesaRepositorio
    {
        Database conn = new Database();
        MySqlCommand cmm = new MySqlCommand();

        public List<TipoDespesa> getAll()
        {
            List<TipoDespesa> tipos = new List<TipoDespesa>();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT * FROM tipodespesa");
            cmm.CommandText = sql.ToString();
            MySqlDataReader dr = conn.executarConsulta(cmm);

            while (dr.Read())
            {
                tipos.Add
                (
                    new TipoDespesa
                    {
                        idTipo = (int)dr["idTipo"],
                        nomeTipo = (string)dr["nomeTipo"]
                    }
                );
            }

            return tipos;
        }

        public List<TipoDespesa> getAllExceptOne(int pIdTipo)
        {
            List<TipoDespesa> tipos = new List<TipoDespesa>();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT * ");
            sql.Append("FROM tipodespesa ");
            sql.Append("WHERE idTipo <> " + pIdTipo);

            cmm.CommandText = sql.ToString();
            MySqlDataReader dr = conn.executarConsulta(cmm);

            while (dr.Read())
            {
                tipos.Add
                (
                    new TipoDespesa
                    {
                        idTipo = (int)dr["idTipo"],
                        nomeTipo = (string)dr["nomeTipo"]
                    }
                );
            }

            return tipos;
        }

        public TipoDespesa getOne(int pId)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT * FROM tipodespesa ");
            sql.Append("WHERE idTipo = @id_tipo");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@id_tipo", pId);
            MySqlDataReader dr = conn.executarConsulta(cmm);
            dr.Read();
            TipoDespesa tipo = new TipoDespesa
            {
                idTipo = (int)dr["idTipo"],
                nomeTipo = (string)dr["nomeTipo"]
            };

            return tipo;
        }

        public void Create(TipoDespesa pTipo)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("INSERT INTO tipodespesa (nomeTipo) ");
            sql.Append("VALUES (@nome_tipo)");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@nome_tipo", pTipo.nomeTipo);

            conn.executarComando(cmm);
        }

        public void Update(TipoDespesa pTipo)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE tipodespesa ");
            sql.Append("SET nomeTipo = @nome_tipo ");
            sql.Append("WHERE idTipo = @id_tipo");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@nome_tipo", pTipo.nomeTipo);
            cmm.Parameters.AddWithValue("@id_tipo", pTipo.idTipo);

            conn.executarComando(cmm);
        }

        public void Delete(int Id)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("DELETE FROM tipodespesa ");
            sql.Append("WHERE idTipo = @id_tipo");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@id_tipo", Id);

            try
            {
                conn.executarComando(cmm);
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }
    }
}