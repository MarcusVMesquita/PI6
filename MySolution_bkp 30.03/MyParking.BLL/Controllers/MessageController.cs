using System.Web.Mvc;
using MyParking.Framework;

namespace MyParking.BLL.Controllers
{
    public class MessageController : Controller
    {
        //public ActionResult Message (string mensagem, Result.TipoResult tipoResultado)
        [HttpGet]
        public ActionResult Message (Result resultado)
        {
            //Result resultado = new Result();
            //resultado.AdicionaMensagem(mensagem, tipoResultado);
            return View(resultado);
        }

        public ActionResult Message()
        {
            return View();
        }
    }
}
