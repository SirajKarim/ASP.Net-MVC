using MvcApplication4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication4.Controllers
{
    public class ShopController : Controller
    {
        //
        // GET: /Shop/


        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add(Shop s, HttpPostedFileBase f1)
        {
            if (f1 != null)
            {
                string img_name = Path.GetFileName(f1.FileName);
                string phy_path = Server.MapPath("~/Images/" + img_name);
                f1.SaveAs(phy_path);
                s.ImagePath = img_name;
                s.AddToDatabase();
            }
            return View();
        }
        [HttpGet]
        public ActionResult ShowCart()
        {
            List<Shop> l = new List<Shop>();
            return View(new Shop().ShowonShop());

        }
        
        public ActionResult Checkout()
        {
            return View();
        }

        
        public ActionResult Thankyou()
        {
            return View();

        }
        [HttpGet]
        public ActionResult Update(int ID)
        {
            Shop B = new Shop()
            {
                ProductID = ID
            };
            return View(B.Search());

        }
        [HttpPost]
        public ActionResult Update(Shop b)
        {
            b.Update();
            return RedirectToAction("ShowAll");

        }
    }
}
          
    

