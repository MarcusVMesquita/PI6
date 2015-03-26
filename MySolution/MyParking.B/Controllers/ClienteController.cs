using System.Web.Mvc;
using MyParking.DAL.Models;
using MyParking.DAL.Services;

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

        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(Cliente resposta)
        {
            try
            {
                service.GravaCliente(resposta);
                return RedirectToAction("Obrigado");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Home/Obrigado
        public ActionResult Obrigado()
        {
            return View();
        }
    }
}
