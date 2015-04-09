using System.Web.Mvc;
using MyParking.DAL.Services;
using MyParking.Framework;
using MyParking.DAL.ViewData;

namespace MyParking.BLL.Controllers
{
    public class CorController : Controller
    {
        CorService service = new CorService();
        public ActionResult Index()
        {
            return View(service.CorToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CorViewData Data)
        {
            Result resultado = null;
            if (ModelState.IsValid)
            {
                resultado = service.GravaCor(Data.CorVeiculo);
                if (resultado.tipoResultado == Result.TipoResult.OK)
                    return RedirectToAction("Index");
            }

            Data.Resultado = resultado;
            return View(Data);
        }

        public ActionResult Edit(int id = 0)
        {
            CorViewData Data = new CorViewData();
            Data.CorVeiculo = service.GetCor(id);
            if (Data.CorVeiculo == null)
                return HttpNotFound();
            else
                return View(Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CorViewData Data)
        {
            Result resultado = null;
            if (ModelState.IsValid)
            {
                resultado = service.GravaCor(Data.CorVeiculo);
                if (resultado.tipoResultado == Result.TipoResult.OK)
                    return RedirectToAction("Index");
            }
            Data.Resultado = resultado;
            return View(Data);
        }

        public ActionResult Delete(int id = 0)
        {
            CorViewData Data = new CorViewData();
            Data.CorVeiculo = service.GetCor(id);
            if (Data.CorVeiculo == null)
                return HttpNotFound();
            else
                return View(Data);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(CorViewData Data)
        {
            Result resultado = service.DeleteCor(Data.CorVeiculo.id_cor);
            if (resultado.tipoResultado == Result.TipoResult.OK)
                return RedirectToAction("Index");

            Data.Resultado = resultado;
            return View(Data);
        }
    }
}
