using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MyParking.DAL.Services;

namespace MyParking.BLL.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioService service = new UsuarioService();

        public ActionResult Index()
        {
            return View(service.UsuarioToList());
        }
    }
}
