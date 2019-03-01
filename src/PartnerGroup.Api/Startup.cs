using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using PartnerGroup.IoC.NativeInjector;
using Microsoft.Extensions.Configuration;
using PartnerGroup.Domain.Shared.AppSettings;
using Microsoft.Extensions.DependencyInjection;

namespace PartnerGroup.Api
{
    public partial class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors();
            services.RegisterDependency();

            ConfigureSettings();
            ConfigureSwagger(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseAuthentication();
            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Partner Group - V1"); });
        }

        private void ConfigureSettings()
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Equals("Development"))
            {
                Settings.ClientId = Environment.GetEnvironmentVariable("CLIENT_ID");
                Settings.ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            }
            else
            {
                Settings.ClientId = Environment.GetEnvironmentVariable("CLIENT_ID");
                Settings.ConnectionString = Configuration.GetConnectionString("CONNECTION_STRING");
            }
        }
    }
}
