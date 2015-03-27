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

        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(Cliente resposta)
        {
            try
            {
                Result result = service.GravaCliente(resposta);

                return RedirectToAction("Message", "Message", new { tipoResultado = result.tipoResultado, mensagem = result.mensagem });//new { mensagem = result.mensagem, tipoResultado = result.tipoResultado });                
            }
            catch
            {
                return View();
            }
        }
    }
}
