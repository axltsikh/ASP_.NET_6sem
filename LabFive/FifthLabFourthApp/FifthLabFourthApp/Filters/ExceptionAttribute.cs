using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FifthLabFourthApp.Filters
{
    public class FormatAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if(!filterContext.ExceptionHandled && filterContext.Exception is FormatException)
            {   
                filterContext.Result = new RedirectResult("/Content/ExceptionFound.html");
                filterContext.ExceptionHandled = true;
            }
        }
    }
}