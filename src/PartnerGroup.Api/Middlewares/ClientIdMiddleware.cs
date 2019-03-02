using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PartnerGroup.Domain.Shared.AppSettings;
using System.Net;
using System.Threading.Tasks;

namespace PartnerGroup.Api.Middlewares
{
    public class ClientIdMiddleware
    {
        private readonly RequestDelegate _next;
        public ClientIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var clientId = httpContext.Request.Headers["client_id"].ToString();
            if (!string.IsNullOrEmpty(clientId))
            {
                if (clientId != Settings.ClientId)
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    var response = new { Success = false, Error = "client_id inválido!" };
                    await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
                }
                else
                {
                    await _next(httpContext);
                }
            }
            else
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                var response = new { Success = false, Error = "Favor informar o cliente_id" };
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
            }
        }
    }
}
