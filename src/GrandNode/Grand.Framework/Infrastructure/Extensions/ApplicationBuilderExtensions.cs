using Grand.Core;
using Grand.Core.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grand.Framework.Infrastructure.Extensions
{
    /// <summary>
    /// Represents extensions of IApplicationBuilder
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Configure the application HTTP request pipeline
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        /// <param name="webHostEnvironment">Web Host Environment</param>
        public static void ConfigureRequestPipeline(this IApplicationBuilder application, IWebHostEnvironment webHostEnvironment)
        {
            Engine.ConfigureRequestPipeline(application, webHostEnvironment);
        }

        /// <summary>
        /// Configure container
        /// </summary>
        /// <param name="container">ContainerBuilder from autofac</param>
        /// <param name="configuration">configuration</param>
        public static void ConfigureContainer(this IServiceCollection container, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Engine.ConfigureContainer(container, configuration);
        }

        /// <summary>
        /// Configure MVC endpoint
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public static void UseGrandEndpoints(this IApplicationBuilder application)
        {
            application.UseEndpoints(endpoints =>
            {
                endpoints.ServiceProvider.GetRequiredService<IRoutePublisher>().RegisterRoutes(endpoints);
            });
        }
    }
}
