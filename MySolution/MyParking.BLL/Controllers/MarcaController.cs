using System.Web.Mvc;
using MyParking.DAL.Models;
using MyParking.DAL.Services;
using MyParking.Framework;

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
        public ActionResult Create(MarcaVeiculo marca)
        {
            if (ModelState.IsValid)
            {
                service.GravaMarca(marca);
                return RedirectToAction("Index");
            }
            else
                return View(marca);
        }

        public ActionResult Edit(int id = 0)
        {
            MarcaVeiculo marca = service.getMarca(id);
            if (marca == null)
                return HttpNotFound();
            else
                return View(marca);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MarcaVeiculo marca)
        {
            if (ModelState.IsValid)
            {
                service.GravaMarca(marca);
                return RedirectToAction("Index");
            }
            return View(marca);
        }

        public ActionResult Delete(int id = 0)
        {
            MarcaVeiculo marca = service.getMarca(id);
            if (marca == null)
                return HttpNotFound();
            else
                return View(marca);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            service.DeleteMarca(id);
            return RedirectToAction("Index");
        }
    }
}
