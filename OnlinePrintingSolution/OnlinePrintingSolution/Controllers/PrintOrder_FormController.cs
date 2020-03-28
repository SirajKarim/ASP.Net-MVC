using Microsoft.Reporting.WebForms;
using OnlinePrintingSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlinePrintingSolution.Controllers
{
    public class PrintOrder_FormController : Controller
    {
        //
        // GET: /PrintOrder_Form/

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(PrintOrder po)
        {
            po.Add();
            return View();
        }

        [HttpGet]
        public ActionResult ShowAll()
        {

            return View(new PrintOrder().ShowAll());
        }



        [HttpGet]
        public ActionResult Update(int OrderId)
        {
            PrintOrder po = new PrintOrder();
           po.OrderId = OrderId;
            PrintOrder search_book = po.Search();
            return View(search_book);
        }
        [HttpPost]
        public ActionResult Update(PrintOrder po)
        {
            po.Update();
            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public ActionResult Delete(int orderId)
        {
            PrintOrder po = new PrintOrder();
            po.OrderId = orderId;
            po.Delete();
            return RedirectToAction("ShowAll");
        }

        public ActionResult Reporting()
        {
            LocalReport lr = new LocalReport();
            lr.ReportPath = Server.MapPath("~/Report/PrintOrderReport.rdlc");
            ReportDataSource rd = new ReportDataSource("DataSet1", new PrintOrder().ShowAll());
            lr.DataSources.Add(rd);
            byte[] render = lr.Render("PDF");
            return File(render, "application/pdf");

        }
    }
}
