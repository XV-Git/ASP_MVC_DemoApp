using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCJobSearch.Controllers
{
    public class RegisterLandingController : Controller
    {
        // GET: RegisterLanding
        public ActionResult RegisterLanding_Pageload()
        {
            return View();
        }
    }
}