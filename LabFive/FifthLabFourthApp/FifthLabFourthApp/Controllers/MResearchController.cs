using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FifthLabFourthApp.Controllers
{
    [RoutePrefix("it")]
    public class MResearchController : Controller
    {
        [HttpGet]
        [Route("{n:int}/{name}")]
        public ActionResult M01(int n, string name)
        {
            return Content($"GET:M01: /{n}/{name}");
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        [Route("{b:bool}/{str:regex([a-zA-Z]$)}")]
        public ActionResult M02(bool b, string str)
        {
            return Content($"{this.HttpContext.Request.HttpMethod}:M02: /{b}/{str}");
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Delete)]
        [Route("{b:float}/{str:length(2,5)}")]
        public ActionResult M03(float b, string str)
        {
            return Content($"{this.HttpContext.Request.HttpMethod}:M03: /{b}/{str}");
        }

        [AcceptVerbs(HttpVerbs.Put)]
        [Route("{letters:regex(^[a-zA-Z]{3,4}$)}/{n:range(100,200)}")]
        public ActionResult M04(string letters, int n)
        {
            return Content($"{this.HttpContext.Request.HttpMethod}:M04: /{letters}/{n}");
        }
        [HttpPost]
        [Route("{letters:regex(^\\S+@\\S+.\\$)}")]
        public ActionResult M04(string letters)
        {
            return Content($"POST: " + letters);
        }
    }
}