using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.DependencyInjection;

namespace PartnerGroup.Api
{
    public partial class Startup
    {
        public void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();

                c.SwaggerDoc("v1", new Info { Title = "Partner Group API", Version = "v1", Description = "Partner Group" });
                c.CustomSchemaIds(x => x.FullName);
            });
        }
    }
}
