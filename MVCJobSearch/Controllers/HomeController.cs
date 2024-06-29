using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCJobSearch.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Painstakingly Made by a Single Dev - Me";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Developer : Sarat.V";

            return View();
        }


    }
}