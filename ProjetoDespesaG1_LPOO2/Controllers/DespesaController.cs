using ProjetoDespesaG1_LPOO2.Models;
using System.Web.Mvc;

namespace ProjetoDespesaG1_LPOO2.Controllers
{
    public class DespesaController : Controller
    {
        TipoDespesaRepositorio tipoRep = new TipoDespesaRepositorio();
        DespesaRepositorio despesaRep = new DespesaRepositorio();

        public ActionResult Despesas()
        {
            return View(despesaRep.getAll());
        }

        public ActionResult Create()
        {
            ViewBag.Tipos = tipoRep.getAll();

            return View();
        }

        [HttpPost]
        public ActionResult Create(Despesa pDespesa)
        {
            if (ModelState.IsValid)
            {
                despesaRep.Create(pDespesa);

                return RedirectToAction("Despesas");
            }

            ViewBag.Tipos = tipoRep.getAll();

            return View();
        }

        public ActionResult Update(int Id)
        {
            var editDespesa = despesaRep.getOne(Id);
            ViewBag.Tipos = tipoRep.getAllExceptOne(editDespesa.Tipo.idTipo);

            return View(editDespesa);
        }

        [HttpPost]
        public ActionResult Update(Despesa pDespesa)
        {
            if (ModelState.IsValid)
            {
                despesaRep.Update(pDespesa);

                return RedirectToAction("Despesas");
            }

            ViewBag.Tipos = tipoRep.getAllExceptOne(pDespesa.Tipo.idTipo);

            return View(pDespesa);
        }

        public ActionResult Delete(int Id)
        {
            despesaRep.Delete(Id);

            return RedirectToAction("Despesas");
        }

        [HttpPost]
        public ActionResult Pesquisa(string Data)
        {
            return View(despesaRep.getByDate(Data));
        }
    }
}