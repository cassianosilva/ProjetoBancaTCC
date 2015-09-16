using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBancaTCC_OO2.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Professor()
        {
        }

        public Professor(int pId, string pNome)
        {
            Id = pId;
            Nome = pNome;
        }

    }
}