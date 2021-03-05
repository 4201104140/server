using Grand.Core;
using Grand.Framework.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grand.Framework.StartupConfigure
{
    /// <summary>
    /// Represents object for the configuring MVC on application startup
    /// </summary>
    public class GrandMvcStartup : IGrandStartup
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {


            //add and cofigure MVC feature
            services.AddGrandMvc(configuration);
        }

        /// <summary>
        /// Configure the using of added middleware
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        /// <param name="webHostEnvironment">WebHostEnvironment</param>
        public void Configure(IApplicationBuilder application, IWebHostEnvironment webHostEnvironment)
        {
            //MVC endpoint routing
            application.UseGrandEndpoints();
        }

        /// <summary>
        /// Gets order of this startup configuration implementation
        /// </summary>
        public int Order
        {
            //MVC should be loaded last
            get { return 1000; }
        }
    }
}
