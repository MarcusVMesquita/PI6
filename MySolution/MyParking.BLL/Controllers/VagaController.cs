using System.Web.Mvc;
using MyParking.DAL.ViewData;
using MyParking.DAL.Services;
using MyParking.DAL.Models;
using MyParking.Framework;

namespace MyParking.BLL.Controllers
{
    public class VagaController : Controller
    {
        VagaService servico = new VagaService();
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VagaViewData Vaga)
        {
            Result resultado = null;
            if (ModelState.IsValid)
            {
                resultado = servico.SetNumVagas(Vaga.QtdeVagas);
                if (resultado.tipoResultado == Result.TipoResult.OK)
                    return RedirectToAction("Index");
            }

            Vaga.Resultado = resultado;
            return View(Vaga);
        }
    }
}