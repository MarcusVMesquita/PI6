using System.Web.Mvc;
using MyParking.DAL.Services;
using MyParking.DAL.Models;
using MyParking.DAL.ViewData;
using MyParking.Framework;
using System;

namespace MyParking.BLL.Controllers
{
    public class EntradaVeiculoController : Controller
    {
        EntradaVeiculoService service = new EntradaVeiculoService();

        public ActionResult Index()
        {
            return View(service.EntradasToList());
        }
        
        public ActionResult Create()
        {
            EntradaVeiculoViewData data = new EntradaVeiculoViewData();
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EntradaVeiculoViewData Data)
        {

            Result resultado = null;

            if (ModelState.IsValid)
            {
                resultado = service.NovaEntrada(Data.EntradaVeiculo);
                
   
                if (resultado.tipoResultado == Result.TipoResult.OK)
                    return RedirectToAction("Index");
            }
            
            Data.Resultado = resultado;
            return View(Data);
        }
    }
}