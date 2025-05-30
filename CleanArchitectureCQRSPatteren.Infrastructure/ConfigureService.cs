using CleanArchitectureCQRSPatteren.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CleanArchitectureCQRSPatteren.Domain.Repository;
using CleanArchitectureCQRSPatteren.Infrastructure.Repository;

namespace CleanArchitectureCQRSPatteren.Infrastructure
{
    public static class ConfigureService
    {
        public static IServiceCollection AddInfraService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("BlogConnection")));
            services.AddTransient<IBlogRepository, BlogRepository>();
    
            return services;
        }
    }
}
