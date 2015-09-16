using ProjetoBancaTCC_OO2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBancaTCC_OO2.Controllers
{
    public class ProfessorController : Controller
    {
        ProfessorRepositorio profRep = new ProfessorRepositorio();

        // GET: Professor
        public ActionResult Index()
        {
            var professores = profRep.getAll();

            return View(professores);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Professor professor)
        {
            profRep.Create(professor);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            profRep.Delete(Id);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int Id)
        {
            var professor = profRep.getOne(Id);
            return View(professor);
        }

        [HttpPost]
        public ActionResult Update(Professor professor)
        {
            profRep.Update(professor);
            return RedirectToAction("Index");
        }
    }
}