
using Microsoft.EntityFrameworkCore;
using TMI.Library.Infrastructure.Core;
using WebApi.Application.Common.Interfaces;
using WebApi.Infrastructure.Persistence;

namespace WebApi.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructureCore();

            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
                     , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());


            return services;
        }

    }
}
