using System;
using System.Web;

namespace FirstLab
{
    public class SixthHandler : IHttpHandler
    {
        #region Члены IHttpHandler

        public bool IsReusable
        {
            // Верните значение false в том случае, если ваш управляемый обработчик не может быть повторно использован для другого запроса.
            // Обычно значение false соответствует случаю, когда некоторые данные о состоянии сохранены по запросу.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.RequestType == "POST")
            {
                HttpResponse response = context.Response;
                string ParmA = context.Request.Params["X"];
                string ParmB = context.Request.Params["Y"];
                response.Write(int.Parse(ParmA) * int.Parse(ParmB));
            }
            else
            {
                HttpResponse response = context.Response;
                context.Response.WriteFile("HTML/indexForm.html");
            }
        }

        #endregion
    }
}
