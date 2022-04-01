using System.Reflection;
using TMI.Library.Application.Core.Common;

namespace WebApi.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddApplicationCore(Assembly.GetExecutingAssembly());

            return services;
        }

    }
}
