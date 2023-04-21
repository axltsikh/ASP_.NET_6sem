using System;
using System.Web;

namespace FirstLab
{
    public class FourthHandler : IHttpHandler
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
            HttpResponse response = context.Response;
            response.ContentType = "text/plain; charset=utf-8";
            try
            {
                string ParmA = HttpUtility.ParseQueryString(context.Request.QueryString.ToString()).Get("X");
                string ParmB = HttpUtility.ParseQueryString(context.Request.QueryString.ToString()).Get("Y");
                response.Write(int.Parse(ParmA) + int.Parse(ParmB));
            }
            catch
            {
                response.Write("Wrong format");
            }
        }

        #endregion
    }
}
