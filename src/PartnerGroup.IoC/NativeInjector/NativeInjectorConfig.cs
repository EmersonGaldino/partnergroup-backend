using PartnerGroup.IoC.Containers;
using Microsoft.Extensions.DependencyInjection;

namespace PartnerGroup.IoC.NativeInjector
{
    public static class NativeInjectorConfig
    {
        public static ServiceProvider RegisterDependency(this IServiceCollection services)
        {
            ApplicationContainer.AddDependency(services);
            RepositoriesContainer.AddDependency(services);

            return services.BuildServiceProvider();
        }
    }
}
