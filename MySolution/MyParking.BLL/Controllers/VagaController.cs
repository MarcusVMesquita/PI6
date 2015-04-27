using System.Web.Mvc;
using MyParking.DAL.ViewData;
using MyParking.DAL.Services;
using MyParking.DAL.Models;
using MyParking.Framework;

namespace MyParking.BLL.Controllers
{
    public class VagaController : Controller
    {

        private VagaService service;
        public VagaController()
        {
            service = new VagaService();
        }

        //public ActionResult Create()
        
    }
}
