using Api.Utilities;
using Core.Context;
using Core.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Options
            services.AddOptions();

            // Settings

            services.AddSqlServerRepositories();

            services.AddScoped<ICurrentContext, CurrentContext>();

            // Caching
            services.AddMemoryCache();

            // MVC
            services.AddMvc(config =>
            {
                config.Conventions.Add(new ApiExplorerGroupConvention());
                //config.Conventions.Add()
            }).AddNewtonsoftJson(options =>
            {

            });


        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IHostApplicationLifetime appLifetime)
        {

            // Add static files to the request pipeline.
            app.UseStaticFiles();

            // Add routing
            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());


        }
    }
}
