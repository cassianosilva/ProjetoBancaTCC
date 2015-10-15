using MySql.Data.MySqlClient;
using ProjetoDespesaG1_LPOO2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoDespesaG1_LPOO2.Controllers
{
    public class TipoController : Controller
    {
        TipoDespesaRepositorio tipoRep = new TipoDespesaRepositorio();

        public ActionResult Tipos()
        {
            return View(tipoRep.getAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TipoDespesa pTipo)
        {
            if (ModelState.IsValid)
            {
                tipoRep.Create(pTipo);

                return RedirectToAction("Tipos");
            }

            return View(pTipo);
        }

        public ActionResult Update(int Id)
        {
            var editTipo = tipoRep.getOne(Id);

            return View(editTipo);
        }

        [HttpPost]
        public ActionResult Update(TipoDespesa pTipo)
        {
            if (ModelState.IsValid)
            {
                tipoRep.Update(pTipo);

                return RedirectToAction("Tipos");
            }

            return View(pTipo);
        }

        public ActionResult Delete(int Id)
        {
            try
            {
                tipoRep.Delete(Id);
            }
            catch (MySqlException)
            {
                TempData["errorDelete"] = "Este tipo possui despesas relacionadas. Não é possível excluir.";
            }
            
            return RedirectToAction("Tipos");
        }
    }
}