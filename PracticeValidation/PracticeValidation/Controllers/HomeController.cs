using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace PracticeValidation.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Name,string Contact,string Email,string Date)
        {
            if (Name.Length==0)
            {
                ModelState.AddModelError("Name","Name is Required");
              //  ViewBag.NameError = "*";
            }
            if (Contact.Length == 0)
            {
                ModelState.AddModelError("Contact", "Contact is Required");
              //  ViewBag.ContactError = "*";
            }
            if (Email.Length == 0)
            {
                ModelState.AddModelError("Email", "Email is Required");
                //ViewBag.EmailError = "*";
            }
            else
            {
                Regex regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                if (!regex.IsMatch(Email))
                {
                    ModelState.AddModelError("Email","Email Pattern is invalid");
                }
            }
            if (Date.Length == 0)
            {
                ModelState.AddModelError("Date", "Date is Required");
              //  ViewBag.DateError = "*";
            }
            else
            {
                Regex regex = new Regex("(^((((0[1-9])|([1-2][0-9])|(3[0-1]))|([1-9]))-(((0[1-9])|(1[0-2]))|([1-9]))-(([0-9]{2})|(((19)|([2]([0]{1})))([0-9]{2}))))$)");
                if (!regex.IsMatch(Date))
                {
                    ModelState.AddModelError("Date","Date Formate is Invalid");
                }
            }
            if (ModelState.IsValid==true)
            {
                ViewBag.AlertMessage = "<script>alert('save successfully');</script>";
            }
            return View();
        }

    }
}
