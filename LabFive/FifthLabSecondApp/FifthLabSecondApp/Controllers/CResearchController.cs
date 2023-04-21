using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace FifthLabSecondApp.Controllers
{
    public class CResearchController : Controller
    {

        [AcceptVerbs("get", "post")]
        public ActionResult C01()
        {
            string method = this.HttpContext.Request.HttpMethod;
            Uri url = this.HttpContext.Request.Url;
            System.Collections.Specialized.NameValueCollection headers = this.HttpContext.Request.Headers;
            System.Collections.Specialized.NameValueCollection query = this.HttpContext.Request.QueryString;
            Request.InputStream.Position = 0;
            var rawRequestBody = new StreamReader(Request.InputStream).ReadToEnd();
            string finalString = "Method: " + method + "<br/>" + "Url: " + url.ToString();
            if (query.Count != 0)
            {
                finalString += "<br/> Query-parameters: ";
                for (int i = 0; i < query.Count; i++)
                {

                    finalString += query.GetKey(i) + ": " + query.Get(i).ToString() + ", ";
                }

            }
            if (headers.Count != 0)
            {
                finalString += "<br/> Headers: ";
                for (int i = 0; i < headers.Count; i++)
                {
                    finalString += headers.GetKey(i) + ": " + headers.Get(i).ToString() + ", ";
                }

            }
            if (rawRequestBody.Length > 0)
            {
                finalString += "<br/> Body: ";
                finalString += rawRequestBody;
            }
            return Content(finalString);
        }
        [AcceptVerbs("get", "post")]
        public ActionResult C02()
        {
            int status = this.HttpContext.Response.StatusCode;
            System.Collections.Specialized.NameValueCollection headers = this.HttpContext.Request.Headers;
            Request.InputStream.Position = 0;
            var rawRequestBody = new StreamReader(Request.InputStream).ReadToEnd();

            string finalString = "Status code: " + status;
            if (headers.Count != 0)
            {
                finalString += "<br/> Headers: ";
                for (int i = 0; i < headers.Count; i++)
                {
                    finalString += headers.GetKey(i) + ": " + headers.Get(i).ToString() + ", ";
                }

            }
            if (rawRequestBody.Length > 0)
            {
                finalString += "<br/> Body: ";
                finalString += rawRequestBody;
            }
            return Content(finalString);
        }
    }
}