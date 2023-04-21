using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;

namespace FirstLabServer
{
    public class IISHandler1 : IHttpHandler
    {

        WebSocket webSocket;
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(WebSocketRequest);
            }
        }
        private async Task WebSocketRequest(AspNetWebSocketContext context)
        {
            webSocket = context.WebSocket;
            while (webSocket.State == WebSocketState.Open)
            {
                await Send(DateTime.Now.ToString("HH:mm:ss"));
                Thread.Sleep(2000);
            }
        }
        private async Task Send(string s)
        {
            var sendbuffer = new ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes(s));
            await webSocket.SendAsync(sendbuffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}
