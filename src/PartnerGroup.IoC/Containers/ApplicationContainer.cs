using PartnerGroup.Application.Services;
using PartnerGroup.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace PartnerGroup.IoC.Containers
{
    public static class ApplicationContainer
    {
        public static void AddDependency(IServiceCollection services)
        {
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<IPatrimonyService, PatrimonyService>();
        }
    }
}
