using Lesson5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson5.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
       public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Account ac)
        {
            if(ac.ID==1 && ac.Password=="123")
            {
                Account.Check = true;
                return RedirectToAction("Shoow", "Book");
            }
            return View();
        }
    }
}