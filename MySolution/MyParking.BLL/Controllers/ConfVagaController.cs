using System.Web.Mvc;
using MyParking.DAL.Models;
using MyParking.DAL.Services;
using MyParking.Framework;
using MyParking.DAL.ViewData;
using System;

namespace MyParking.BLL.Controllers
{
    public class ConfVagaController : Controller
    {
        private ConfVagasService service = new ConfVagasService();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            ConfVagaViewData data = new ConfVagaViewData();
            return View(data);
        }

    }
}
