using System.Web.Mvc;
using MyParking.DAL.Models;
using MyParking.DAL.Services;
using MyParking.Framework;
using MyParking.DAL.ViewData;

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
            Cliente cliente = service.GetCliente(id);
            if (cliente == null)
                return HttpNotFound();
            else
                return View(cliente);
        }

        public ActionResult Edit(int id = 0)
        {
            Cliente cliente = service.GetCliente(id);
            if (cliente == null)
                return HttpNotFound();
            else
            {
                ClienteViewData data = new ClienteViewData(cliente);
                return View(data);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewData data)
        {
            Result resultado;
            if (ModelState.IsValid)
            {
                resultado = service.GravaCliente(data.Cliente);
                if (resultado.tipoResultado == Result.TipoResult.OK)
                    return RedirectToAction("Index");
                else
                    data.Resultado = resultado;
            }
            
            return View(data.Cliente);
        }

        public ActionResult Create()
        {
            ClienteViewData data = new ClienteViewData();
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewData Data)
        {
            Result resultado = null;

            if (ModelState.IsValid)
            {
                resultado = service.GravaCliente(Data.Cliente);
                if (resultado.tipoResultado == Result.TipoResult.OK)
                    return RedirectToAction("Index");
            }
            Data.Resultado = resultado;
            return View(Data);
        }

        public ActionResult Delete(int id = 0)
        {
            Cliente cliente = service.GetCliente(id);
            if (cliente == null)
                return HttpNotFound();
            else
                return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            Result resultado = service.DeleteCliente(id);
            return RedirectToAction("Index");
        }
    }
}
