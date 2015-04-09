using System.Web.Mvc;
using MyParking.DAL.ViewData;
using MyParking.Framework;
using MyParking.DAL.Services;
using System.Linq;
using MyParking.DAL.Models;

namespace MyParking.BLL.Controllers
{
    public class LoginController : Controller
    {
        UsuarioService service = new UsuarioService();
        public ActionResult Login()
        {
            if (service.UsuarioToList().ToList().Count == 0)
                return RedirectToAction("Create", "Usuario");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioViewData data)
        {
            if (data.Usuario.Login != null)
            {
                Usuario usuario = service.getUsrByLogin(data.Usuario.Login);

                if (usuario != null) //Achou o login
                    if (data.Usuario.Password == Cripto.Descriptografar(usuario.Password, usuario.Login))
                        return PartialView("_MyPartial", usuario);
            }
            data.Resultado = new Result("Login Incorreto", Result.TipoResult.Error);

            return View(data);
        }
    }
}
