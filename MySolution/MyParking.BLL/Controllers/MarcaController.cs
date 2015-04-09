using System.Web.Mvc;
using MyParking.DAL.Services;
using MyParking.Framework;
using MyParking.DAL.ViewData;

namespace MyParking.BLL.Controllers
{
    public class MarcaController : Controller
    {
        MarcaService service = new MarcaService();
        public ActionResult Index()
        {
            return View(service.MarcaToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MarcaViewData Data)
        {
            Result resultado = null;
            if (ModelState.IsValid)
            {
                resultado = service.GravaMarca(Data.MarcaVeiculo);
                if (resultado.tipoResultado == Result.TipoResult.OK)
                    return RedirectToAction("Index");
            }

            Data.Resultado = resultado;
            return View(Data);
        }

        public ActionResult Edit(int id = 0)
        {
            MarcaViewData Data = new MarcaViewData();
            Data.MarcaVeiculo = service.GetMarca(id);
            if (Data.MarcaVeiculo == null)
                return HttpNotFound();
            else
                return View(Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MarcaViewData Data)
        {
            Result resultado = null;
            if (ModelState.IsValid)
            {
                resultado = service.GravaMarca(Data.MarcaVeiculo);
                if (resultado.tipoResultado == Result.TipoResult.OK)
                    return RedirectToAction("Index");
            }
            Data.Resultado = resultado;
            return View(Data);
        }

        public ActionResult Delete(int id = 0)
        {
            MarcaViewData Data = new MarcaViewData();
            Data.MarcaVeiculo = service.GetMarca(id);
            if (Data.MarcaVeiculo == null)
                return HttpNotFound();
            else
                return View(Data);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(MarcaViewData Data)
        {
            Result resultado = service.DeleteMarca(Data.MarcaVeiculo.id_marca);
            if (resultado.tipoResultado == Result.TipoResult.OK)
                return RedirectToAction("Index");

            Data.Resultado = resultado;
            return View(Data);
        }
    }
}
