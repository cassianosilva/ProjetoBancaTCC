using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBancaTCC_OO2.Models
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public static List<Cidade> listaCidades = new List<Cidade>();

        public Cidade()
        {
        }

        public Cidade(int pId, string pNome)
        {
            Id = pId;
            Nome = pNome;
        }

        public static void popularCidades(int pId, string pNome)
        {
            Cidade novaCidade = new Cidade(pId, pNome);
            listaCidades.Add(novaCidade);
        }
    }
}