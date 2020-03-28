using Lesson5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson5.Controllers
{
    public class SessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (Account.Check == false)
            {
                filterContext.Result = new RedirectResult("~\\Session\\Login");
                return;
            }

            base.OnActionExecuting(filterContext);

        }
    }
}