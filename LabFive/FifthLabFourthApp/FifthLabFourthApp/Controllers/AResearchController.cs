using FifthLabFourthApp.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FifthLabFourthApp.Controllers
{
    [Format]
    public class AResearchController : Controller
    {
        [Action]
        public ActionResult AA()
        {
            return Content("Action filter method");
        }
        [Result]
        public ActionResult AR(int a,int b)
        {
            HttpContext.Session.Add("Result", a * b);
            return Content("action: " + HttpContext.Session[0]);
        }
        [Format]
        public ActionResult AE(string a,string b)
        {
            int intA = Convert.ToInt32(a);
            int intB = Convert.ToInt32(b);
            return Content((intA * intB).ToString());
        }
        public ActionResult error()
        {
            return Content("Wrong parameters value");
        }
    }
}