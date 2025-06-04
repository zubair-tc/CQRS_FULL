using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace CleanArchitectureCQRSPatteren.Application
{
    public static class ConfigureService
    {
        public static IServiceCollection AddApplicationServices (this IServiceCollection services) 
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(ctg =>
            {
                ctg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}
