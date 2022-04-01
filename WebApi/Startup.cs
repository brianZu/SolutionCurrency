using Microsoft.AspNetCore.Mvc;
using TMI.Library.Utils.ApiSecurity;
using TMI.Library.Utils.Logging;
using WebApi.Application;
using WebApi.Filters;
using WebApi.Infrastructure;

namespace TMIBFFMastersData.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddApiSecurity();

            services.AddControllers(options => options.Filters.Add<ApiExceptionFilterAttribute>());
            services.AddEndpointsApiExplorer();
            services.AddHealthChecks();
           
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

            services.AddApplication();
            services.AddInfrastructure(Configuration);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseTransactorLogContext();

            app.UseRouting();

            app.UseHealthChecks("/health");
            app.UseHttpsRedirection();


            app.UseApiKey();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}");
            });

            

        }
    }
}
