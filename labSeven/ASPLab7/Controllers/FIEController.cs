﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPLab7.Controllers
{
    public class FIEController : Controller
    {
  
        [Authorize(Roles = "Guest,Employer")]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Employer")]
        public ActionResult FIE_TM()
        {
            return View();
        }
        [Authorize(Roles = "Employer")]
        public ActionResult FIE_UR()
        {
            return View();
        }
        [Authorize(Roles = "Employer")]
        public ActionResult FIE_UP()
        {
            return View();
        }
    }
}