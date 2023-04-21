using FifthLab.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FifthLab.Controllers
{
    public class MResearchController : Controller
    {
        public ActionResult M01()
        {
            return new ResponseUtility("GET:M01");
        }   

        public ActionResult M02()
        {
            return new ResponseUtility("GET:M02");
        }

        public ActionResult M03()
        {
            return new ResponseUtility("GET:M03");
        }
        public ActionResult MXX()
        {
            return new ResponseUtility("GET:MXX");
        }
    }
}