using System.Web.Mvc;
using MyParking.DAL.Models;
using MyParking.DAL.Services;
using MyParking.Framework;
using MyParking.DAL.ViewData;
using MyParking.DAL.Models;
using System;

namespace MyParking.BLL.Controllers
{
    public class ConfiguracaoController : Controller
    {
        private ConfiguracaoService service = new ConfiguracaoService();

        public ActionResult Index()
        {
            Configuracao data = new Configuracao();
            data = service.getTamanho();
            return View(data);
        }

        public ActionResult Edit(int id = 0)
        {
            Configuracao conf = service.getConfById(id);
            if (conf == null)
                return HttpNotFound();
            else
            {
                ConfiguracaoViewData data = new ConfiguracaoViewData();
                data.Configuracao = conf;
                return View(data);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ConfiguracaoViewData data)
        {
            Result resultado = null;

            if (ModelState.IsValid)
            {
                resultado = service.definirTamanho(data.Configuracao);
                if (resultado.tipoResultado == Result.TipoResult.OK)
                    return RedirectToAction("Index");
            }
            data.Result = resultado;
            return View(data);

            
        }

    }
}
