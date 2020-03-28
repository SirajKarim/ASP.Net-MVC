using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Email_Esnding.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegistrationPage()
        {
            return View();
        }
        public ActionResult ThankyouPage()
        {
            return View();
        }

    }
}
