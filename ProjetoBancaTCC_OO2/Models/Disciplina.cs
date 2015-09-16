using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBancaTCC_OO2.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Disciplina()
        {
        }

        public Disciplina(int pId, string pNome)
        {
            Id = pId;
            Nome = pNome;
        }
    }
}