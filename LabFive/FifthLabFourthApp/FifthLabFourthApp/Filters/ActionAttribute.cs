using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FifthLabFourthApp.Filters
{
    public class ActionAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("OnActionExecutedMethod finished <br/>");
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.HttpMethod != "GET")
            {
                filterContext.Result = new HttpNotFoundResult();
            }
            else
            {
                filterContext.HttpContext.Response.Write("OnActionExecutedMethod started <br/>");
            }
        }
    }
}