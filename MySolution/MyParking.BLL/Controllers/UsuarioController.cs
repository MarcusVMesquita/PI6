using System.Web.Mvc;
using MyParking.DAL.Services;
using MyParking.DAL.Models;
using MyParking.DAL.ViewData;
using System.Linq;
using MyParking.Framework;

namespace MyParking.BLL.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioService service = new UsuarioService();
        public ActionResult Index()
        {
            return View(service.UsuarioToList());
        }

        public ActionResult Create()
        {
            if (service.UsuarioToList().ToList().Count != 0)
                return View();
            else
            {
                UsuarioViewData Data = new UsuarioViewData();
                Data.Usuario = new Usuario();
                Data.Usuario.Administrador = true;
                Data.FirstUsr = true;
                return View(Data);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewData Data)
        {
            Result resultado = null;
            bool firstUsr = (service.UsuarioToList().ToList().Count == 0);//deve salvar se é o primeiro usuario ou não

            if (ModelState.IsValid)
            {
                if (firstUsr)
                    Data.Usuario.Administrador = true;
                resultado = service.GravaUsuario(Data.Usuario);
                if (resultado.tipoResultado == Result.TipoResult.OK)
                {
                    if (!firstUsr)
                        return RedirectToAction("Index");
                    else
                        return RedirectToAction("Login", "Login");
                }
            }
            Data.Resultado = resultado;
            return View(Data);
        }

        public ActionResult Delete(int id = 0)
        {
            Usuario usuario = service.GetUsuario(id);
            if (usuario == null)
                return HttpNotFound();
            else
                return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            Result resultado = service.DeletaUsuario(id);
            return RedirectToAction("Index");
        }
 
    }

}
