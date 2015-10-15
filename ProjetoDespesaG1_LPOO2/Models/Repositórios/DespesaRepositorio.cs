using MySql.Data.MySqlClient;
using PeixeiraConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ProjetoDespesaG1_LPOO2.Models
{
    public class DespesaRepositorio
    {
        Database db = new Database();
        MySqlCommand cmm = new MySqlCommand();
        
        public List<Despesa> getAll()
        {
            List<Despesa> despesas = new List<Despesa>();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT * ");
            sql.Append("FROM despesa d ");
            sql.Append("INNER JOIN tipodespesa t ");
            sql.Append("ON d.idTipo = t.idTipo");

            cmm.CommandText = sql.ToString();
            MySqlDataReader dr = db.executarConsulta(cmm);

            while (dr.Read())
            {
                despesas.Add
                (
                    new Despesa
                    {
                        IdDespesa = (int)dr["idDespesa"],
                        LocalDespesa = (string)dr["localDespesa"],
                        DataDespesa = (DateTime)dr["dataDespesa"],
                        ValorDespesa = (decimal)dr["valorDespesa"],
                        Tipo = new TipoDespesa
                        {
                            idTipo = (int)dr["idTipo"],
                            nomeTipo = (string)dr["nomeTipo"]
                        }

                    }
                );
            }
            dr.Dispose();

            return despesas;
        }

        public List<Despesa> getLasts()
        {
            List<Despesa> despesas = new List<Despesa>();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT d.idDespesa, d.localDespesa, d.dataDespesa, d.valorDespesa, ");
            sql.Append(" t.idTipo, t.nomeTipo ");
            sql.Append("FROM despesa d ");
            sql.Append("INNER JOIN tipodespesa t ");
            sql.Append("ON d.idTipo = t.idTipo ");
            sql.Append("ORDER BY idDespesa DESC ");
            sql.Append("LIMIT 7");

            cmm.CommandText = sql.ToString();
            MySqlDataReader dr = db.executarConsulta(cmm);

            while (dr.Read())
            {
                despesas.Add
                (
                    new Despesa
                    {
                        IdDespesa = (int)dr["idDespesa"],
                        LocalDespesa = (string)dr["localDespesa"],
                        DataDespesa = (DateTime)dr["dataDespesa"],
                        ValorDespesa = (decimal)dr["valorDespesa"],
                        Tipo = new TipoDespesa
                        {
                            idTipo = (int)dr["idTipo"],
                            nomeTipo = (string)dr["nomeTipo"]
                        }

                    }
                );
            }
            dr.Dispose();

            return despesas;
        }

        public Despesa getOne(int Id)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT * ");
            sql.Append("FROM despesa d ");
            sql.Append("INNER JOIN tipodespesa t ");
            sql.Append("ON d.idTipo = t.idTipo ");
            sql.Append("WHERE idDespesa = @id_despesa");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@id_despesa", Id);
            MySqlDataReader dr = db.executarConsulta(cmm);
            dr.Read();
            Despesa dp = new Despesa
            {
                IdDespesa = (int)dr["idDespesa"],
                LocalDespesa = (string)dr["localDespesa"],
                DataDespesa = (DateTime)dr["dataDespesa"],
                ValorDespesa = (decimal)dr["valorDespesa"],
                Tipo = new TipoDespesa
                {
                    idTipo = (int)dr["idTipo"],
                    nomeTipo = (string)dr["nomeTipo"]
                }

            };
            dr.Dispose();

            return dp;
        }

        public List<Despesa> getByDate(string pData)
        {
            List<Despesa> despesas = new List<Despesa>();
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT * ");
            sql.Append("FROM despesa d ");
            sql.Append("INNER JOIN tipodespesa t ON d.idTipo = t.idTipo "); 
            sql.Append("WHERE dataDespesa = @data_despesa");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@data_despesa", pData);
            MySqlDataReader dr = db.executarConsulta(cmm);

            while (dr.Read())
            {
                despesas.Add
                (
                    new Despesa
                    {
                        IdDespesa = (int)dr["idDespesa"],
                        LocalDespesa = (string)dr["localDespesa"],
                        DataDespesa = (DateTime)dr["dataDespesa"],
                        ValorDespesa = (decimal)dr["valorDespesa"],
                        Tipo = new TipoDespesa
                        {
                            idTipo = (int)dr["idTipo"],
                            nomeTipo = (string)dr["nomeTipo"]
                        }
                    }
                );
            }
            dr.Dispose();

            return despesas;
        }

        public void Create(Despesa pDespesa)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("INSERT INTO despesa (localDespesa, dataDespesa, valorDespesa, idTipo) ");
            sql.Append("VALUES (@local_despesa, @data_despesa, @valor_despesa, @id_tipo)");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@local_despesa", pDespesa.LocalDespesa);
            cmm.Parameters.AddWithValue("@data_despesa", pDespesa.DataDespesa);
            cmm.Parameters.AddWithValue("@valor_despesa", pDespesa.ValorDespesa);
            cmm.Parameters.AddWithValue("@id_tipo", pDespesa.Tipo.idTipo);

            db.executarComando(cmm);
        }

        public void Update(Despesa pDespesa)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE despesa ");
            sql.Append("SET localDespesa = @local_despesa, dataDespesa = @data_despesa, ");
            sql.Append("valorDespesa = @valor_despesa, idTipo = @id_tipo ");
            sql.Append("WHERE idDespesa = @id_despesa");

            cmm.CommandText = sql.ToString();

            cmm.Parameters.AddWithValue("@local_despesa", pDespesa.LocalDespesa);
            cmm.Parameters.AddWithValue("@data_despesa", pDespesa.DataDespesa);
            cmm.Parameters.AddWithValue("@valor_despesa", pDespesa.ValorDespesa);
            cmm.Parameters.AddWithValue("@id_despesa", pDespesa.IdDespesa);
            cmm.Parameters.AddWithValue("@id_tipo", pDespesa.Tipo.idTipo);

            db.executarComando(cmm);
        }

        public void Delete(int Id)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("DELETE FROM despesa ");
            sql.Append("WHERE idDespesa = @id_despesa");

            cmm.CommandText = sql.ToString();
            cmm.Parameters.AddWithValue("@id_despesa", Id);

            db.executarComando(cmm);
        }
    }
}