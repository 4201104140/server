using Grand.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grand.Framework.Infrastructure.Extensions
{
    /// <summary>
    /// Represents extensions of IServiceCollection
    /// </summary>
    public static class ServiceCollectionExtensions
    {

        public static void ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {


            //add accessor to HttpContext
            services.AddHttpContextAccessor();

            //initialize and configure the engine
            Engine.Initialize(services, configuration);
            Engine.ConfigureServices(services, configuration);
        }

        /// <summary>
        /// Add and configure MVC for the application
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <returns>A builder for configuring MVC services</returns>
        public static IMvcBuilder AddGrandMvc(this IServiceCollection services, IConfiguration configuration)
        {
            //add basic MVC feature
            var mvcBuilder = services.AddMvc(options =>
            {

            });

            //register controllers as services, it'll allow to override them
            mvcBuilder.AddControllersAsServices();

            return mvcBuilder;
        }
    }
}
