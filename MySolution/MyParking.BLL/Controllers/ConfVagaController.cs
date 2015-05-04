using System.Web.Mvc;
using MyParking.DAL.Models;
using MyParking.DAL.Services;
using MyParking.Framework;
using MyParking.DAL.ViewData;
using MyParking.DAL.Models;
using System;

namespace MyParking.BLL.Controllers
{
    public class ConfVagaController : Controller
    {
        private ConfVagasService service = new ConfVagasService();

        public ActionResult Index()
        {
            ConfVagas data = new ConfVagas();
            data = service.getTamanho();
            return View(data);
        }

        public ActionResult Edit()
        {
            ConfVagaViewData data = new ConfVagaViewData();
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ConfVagaViewData data)
        {
            Result resultado = null;

            if (ModelState.IsValid)
            {
                resultado = service.definirTamanho(data.ConfigVaga);
                if (resultado.tipoResultado == Result.TipoResult.OK)
                    return RedirectToAction("Index");
            }
            data.Result = resultado;
            return View(data);

            
        }

    }
}
