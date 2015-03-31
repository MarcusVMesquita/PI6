using System.Web.Mvc;
using MyParking.DAL.Models;
using MyParking.DAL.Services;
using MyParking.Framework;

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
        public ActionResult Create(CorVeiculo cor)
        {
            if (ModelState.IsValid)
            {
                service.GravaCor(cor);
                return RedirectToAction("Index");
            }
            else
                return View(cor);
        }

        public ActionResult Edit(int id = 0)
        {
            CorVeiculo cor = service.getCor(id);
            if (cor == null)
                return HttpNotFound();
            else
                return View(cor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CorVeiculo cor)
        {
            if (ModelState.IsValid)
            {
                service.GravaCor(cor);
                return RedirectToAction("Index");
            }
            return View(cor);
        }

        public ActionResult Delete(int id = 0)
        {
            CorVeiculo cor = service.getCor(id);
            if (cor == null)
                return HttpNotFound();
            else
                return View(cor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            service.DeleteCor(id);
            return RedirectToAction("Index");
        }
    }
}
