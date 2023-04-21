using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FifthLabFourthApp.Controllers
{
    public class CHResearchController : Controller
    {
        [HttpGet]
        [OutputCache(Duration = 5, Location = System.Web.UI.OutputCacheLocation.Any)]
        public ActionResult AD()
        {
            Utility.counter++;
            return Content($"AD action reposnse!<br/>Counter value: {Utility.counter}");
        }

        [HttpPost]
        [OutputCache(Duration = 7, Location = System.Web.UI.OutputCacheLocation.Any, VaryByParam = "x")]
        public ActionResult AP(int x,int y)
        {
            Utility.counter++;
            return Content($"AP action response!<br/>Sum result: {DateTime.Now}");
        }
    }
}