using MvcApplication4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication4.Controllers
{
    public class AdminController : Controller
    {

        // GET: /Session/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            if (p.Check())
            {
                Session["UserID"] = p.UserID;
                Admin.C = true;
            }
            return RedirectToAction("Index", "Home");
        }


    }
}