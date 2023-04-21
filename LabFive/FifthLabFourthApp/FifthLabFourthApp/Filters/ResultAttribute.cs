using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FifthLabFourthApp.Filters
{
    public class ResultAttribute : FilterAttribute, IResultFilter
    {
        private Stopwatch stopwatch = new Stopwatch();
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            stopwatch.Start();
            filterContext.HttpContext.Response.Write("Время обработки результата: " + stopwatch.Elapsed.TotalSeconds +"<br/>");
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            stopwatch.Start();
            if (Convert.ToInt32(HttpContext.Current.Session[0]) < 0)
            {
                throw new Exception();
            }
        }
    }
}