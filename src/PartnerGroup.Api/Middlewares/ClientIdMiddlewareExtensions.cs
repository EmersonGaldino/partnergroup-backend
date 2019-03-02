using Microsoft.AspNetCore.Builder;

namespace PartnerGroup.Api.Middlewares
{
    public static class ClientIdMiddlewareExtensions
    {
        public static IApplicationBuilder UseClientId(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ClientIdMiddleware>();
        }
    }
}
