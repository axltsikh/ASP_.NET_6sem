using System;
using System.Web;

namespace FirstLab
{
    public class SecondHandler : IHttpHandler
    {
        #region Члены IHttpHandler

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse response = context.Response;
            response.ContentType = "text/plain; charset=utf-8";
            string ParmA = HttpUtility.ParseQueryString(context.Request.QueryString.ToString()).Get("ParmA");
            string ParmB = HttpUtility.ParseQueryString(context.Request.QueryString.ToString()).Get("ParmB");
            response.Write("POST-Http-TAA: ParmA=" + ParmA + ", ParmB=" + ParmB);
        }

        #endregion
    }
}
