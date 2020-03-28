using MvcApplication4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication4.Controllers
{
    
    public class ProductController : Controller
    {
        //
        // GET: /BookForm/

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Product b)
        {
            b.Add();
            return View();
        }

         [HttpGet]
        public ActionResult ShowAll()
        {
            List<Product> l = new List<Product>();
            return View(new Product().ShowAll());
            
        }
      
        [HttpGet]
        public ActionResult Update(int ID)
        { 
         Product B=new Product()
         {
         ProductID=ID
         };
         return View(B.Search());
        
        }
        [HttpPost]
        public ActionResult Update(Product b)
        {
            b.Update();
            return RedirectToAction("ShowAll");
        
        }
          [HttpGet]
        public ActionResult Delete(int ID)
        {
            Product p = new Product();
            p.ProductID = ID;
            p.Delete();
            return RedirectToAction("ShowAll");
        }


    }
}
