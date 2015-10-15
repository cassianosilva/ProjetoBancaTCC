using PeixeiraConnection;
using ProjetoBancaTCC_OO2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBancaTCC_OO2.Controllers
{
    public class AlunoController : Controller
    {
        AlunoRepositorio alunoRep = new AlunoRepositorio();

        // GET: Aluno
        public ActionResult Index()
        {
            var alunos = alunoRep.getAll();

            return View(alunos);
        }


        public ActionResult Create()
        {
            Cidade.popularCidades(1, "Torres");
            Cidade.popularCidades(2, "Arroio do Sal");
            Cidade.popularCidades(3, "Terra de Areia");
            ViewBag.ListCidade = Cidade.listaCidades;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Aluno aluno)
        {
            alunoRep.Create(aluno);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            alunoRep.Delete(Id);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int Id)
        {
            var aluno = alunoRep.getOne(Id);
            return View(aluno);
        }

        [HttpPost]
        public ActionResult Update(Aluno aluno)
        {
            alunoRep.Update(aluno);
            return RedirectToAction("Index");
        }
    }
}