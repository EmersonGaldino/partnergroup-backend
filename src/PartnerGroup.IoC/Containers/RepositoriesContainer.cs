using PartnerGroup.Domain.Contracts;
using PartnerGroup.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace PartnerGroup.IoC.Containers
{
    public static class RepositoriesContainer
    {
        public static void AddDependency(IServiceCollection services)
        {
            services.AddTransient<IBrandRepository, BrandRepository>();
        }
    }
}
