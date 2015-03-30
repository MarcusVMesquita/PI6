using System.Web.Mvc;
using MyParking.DAL.Models;
using MyParking.DAL.Services;
using MyParking.Framework;

namespace MyParking.BLL.Controllers
{
    public class ClienteController : Controller
    {
        //
        // GET: /Home/
        private ClienteService service;
        public ClienteController()
        {
            service = new ClienteService();
        }

        public ActionResult Index()
        {
            return View(service.ClienteToList());
        }

        public ActionResult Details(int id = 0)
        {
            Cliente cliente = service.getCliente(id);
            if (cliente == null)
                return HttpNotFound();
            else
                return View(cliente);
        }

        public ActionResult Edit(int id = 0)
        {
            Cliente cliente = service.getCliente(id);
            if (cliente == null)
                return HttpNotFound();
            else
                return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                service.GravaCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                service.GravaCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Delete(int id = 0)
        {
            Cliente cliente = service.getCliente(id);
            if (cliente == null)
                return HttpNotFound();
            else
                return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            service.DeleteCliente(id);
            return RedirectToAction("Index");
        }
    }
}
