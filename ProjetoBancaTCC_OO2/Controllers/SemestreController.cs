using ProjetoBancaTCC_OO2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBancaTCC_OO2.Controllers
{
    public class SemestreController : Controller
    {
        SemestreRepositorio semestreRep = new SemestreRepositorio();

        // GET: Semestre
        public ActionResult Index()
        {
            var semestres = semestreRep.getAll();

            return View(semestres);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Semestre semestre)
        {
            semestreRep.Create(semestre);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            semestreRep.Delete(Id);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int Id)
        {
            var semestre = semestreRep.getOne(Id);
            return View(semestre);
        }

        [HttpPost]
        public ActionResult Update(Semestre semestre)
        {
            semestreRep.Update(semestre);
            return RedirectToAction("Index");
        }
    }
}