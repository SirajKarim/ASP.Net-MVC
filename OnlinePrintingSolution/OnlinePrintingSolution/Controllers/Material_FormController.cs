using Microsoft.Reporting.WebForms;
using OnlinePrintingSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlinePrintingSolution.Controllers
{
    public class Material_FormController : Controller
    {
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(MaterialType mt)
        {
            mt.Add();
            return View();
        }

        [HttpGet]
        public ActionResult ShowAll()
        {

            return View(new MaterialType().ShowAll());
        }



        [HttpGet]
        public ActionResult Update(int MaterialTypId)
        {
            MaterialType mt = new MaterialType();
            mt.MaterialTypId =MaterialTypId;
            MaterialType search = mt.Search();
            return View(search);
        }
        [HttpPost]
        public ActionResult Update(MaterialType mt)
        {
            mt.Update();
            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public ActionResult Delete(int MaterialTypId)
        {
            MaterialType mt = new MaterialType();
            mt.MaterialTypId = MaterialTypId;
            mt.Delete();
            return RedirectToAction("ShowAll");
        }

        public ActionResult Reporting()
        {
            LocalReport lr = new LocalReport();
            lr.ReportPath = Server.MapPath("~/Report/MaterialReport.rdlc");
            ReportDataSource rd = new ReportDataSource("DataSet1", new MaterialType().ShowAll());
            lr.DataSources.Add(rd);
            byte[] render = lr.Render("PDF");
            return File(render, "application/pdf");

        }

    }
}
