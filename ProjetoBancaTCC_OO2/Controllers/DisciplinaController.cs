using ProjetoBancaTCC_OO2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBancaTCC_OO2.Controllers
{
    public class DisciplinaController : Controller
    {
        DisciplinaRepositorio discRep = new DisciplinaRepositorio();

        // GET: Disciplina
        public ActionResult Index()
        {
            var disciplinas = discRep.getAll();

            return View(disciplinas);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Disciplina disciplina)
        {
            discRep.Create(disciplina);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            discRep.Delete(Id);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int Id)
        {
            var disciplina = discRep.getOne(Id);
            return View(disciplina);
        }

        [HttpPost]
        public ActionResult Update(Disciplina disciplina)
        {
            discRep.Update(disciplina);
            return RedirectToAction("Index");
        }
    }
}