using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoDespesaG1_LPOO2.Models
{
    public class Despesa
    {
        public int IdDespesa { get; set; }

        [Required(ErrorMessage = "Você não informou um local.")]
        public string LocalDespesa { get; set; }

        [Required(ErrorMessage = "Você não informou uma data.")]
        public DateTime DataDespesa { get; set; }

        [Required(ErrorMessage = "Você não informou um valor.")]
        public decimal ValorDespesa { get; set; }

        public TipoDespesa Tipo { get; set; }

        public Despesa()
        {
        }

        public Despesa(int pId, string pLocal, DateTime pData, decimal pValor, TipoDespesa pTipo)
        {
            IdDespesa = pId;
            LocalDespesa = pLocal;
            DataDespesa = pData;
            ValorDespesa = pValor;
            Tipo = pTipo;
        }
    }
}