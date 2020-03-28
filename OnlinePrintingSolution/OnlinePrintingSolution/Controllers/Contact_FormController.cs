using Microsoft.Reporting.WebForms;
using OnlinePrintingSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlinePrintingSolution.Controllers
{
    public class Contact_FormController : Controller
    {
        //
        // GET: /Contact_Form/

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Contact c)
        {
            c.Add();
            return View();
        }

        [HttpGet]
        public ActionResult ShowAll()
        {

            return View(new Contact().ShowAll());
        }



        [HttpGet]
        public ActionResult Update(int ContactTypeId)
        {
            Contact c = new Contact();
            c.ContactTypeId = ContactTypeId;
            Contact search = c.Search();
            return View(search);
        }
        [HttpPost]
        public ActionResult Update(Contact c)
        {
           c.Update();
            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public ActionResult Delete(int ContactTypeId)
        {
            Contact c = new Contact();
            c.ContactTypeId = ContactTypeId;
            c.Delete();
            return RedirectToAction("ShowAll");
        }

        public ActionResult Reporting()
        {
            LocalReport lr = new LocalReport();
            lr.ReportPath = Server.MapPath("~/Report/ContactReport.rdlc");
            ReportDataSource rd = new ReportDataSource("DataSet1", new Contact().ShowAll());
            lr.DataSources.Add(rd);
            byte[] render = lr.Render("PDF");
            return File(render, "application/pdf");

        }

    }
}
