using MvcApplication4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication4.Controllers
{
    public class SessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!Admin.C)
            {
               // int a = (int)HttpContext.Current.Session["ID"];
                filterContext.Result = new RedirectResult("~\\Admin");
                return;
            }
            base.OnActionExecuting(filterContext);

        }
    }
}

