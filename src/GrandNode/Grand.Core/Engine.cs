using AutoMapper;
using Grand.Core.Configuration;
using Grand.Core.Extensions;
using Grand.Core.Mapper;
using Grand.Core.Plugins;
using Grand.Core.TypeFinders;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grand.Core
{
    /// <summary>
    /// Represents engine
    /// </summary>
    public static class Engine
    {
        #region Utilities

        /// <summary>
        /// Run startup tasks
        /// </summary>
        /// <param name="typeFinder">Type finder</param>
        private static void RunStartupTasks(ITypeFinder typeFinder)
        {
            //find startup tasks provided by other assemblies
            var startupTasks = typeFinder.FindClassesOfType<IStartupTask>();

            //create and sort instances of startup tasks
            var instances = startupTasks
                //.Where(startupTask => PluginManager.FindPlugin(startupTask).Return(plugin => plugin.Installed, true)) //ignore not installed plugins
                .Select(startupTask => (IStartupTask)Activator.CreateInstance(startupTask))
                .OrderBy(startupTask => startupTask.Order);

            //execute tasks
            foreach (var task in instances)
                task.Execute();
        }

        /// <summary>
        /// Register and configure AutoMapper
        /// </summary>
        /// <param name="typeFinder">Type finder</param>
        private static void AddAutoMapper(ITypeFinder typeFinder)
        {
            //find mapper configurations provided by other assemblies
            var mapperConfigurations = typeFinder.FindClassesOfType<IAutoMapperProfile>();

            //create and sort instances of mapper configurations
            var instances = mapperConfigurations
                .Where(mapperConfiguration => PluginManager.FindPlugin(mapperConfiguration)
                    .Return(plugin => plugin.Installed, true))
                .Select(mapperConfiguration => (IAutoMapperProfile)Activator.CreateInstance(mapperConfiguration))
                .OrderBy(mapperConfiguration => mapperConfiguration.Order);

            //create AutoMapper configuration
            var config = new MapperConfiguration(cfg =>
            {
                foreach (var instance in instances)
                {
                    cfg.AddProfile(instance.GetType());
                }
            });

            //register automapper
            AutoMapperConfig.Init(config);
        }

        /// <summary>
        /// Add attributes to convert some classes
        /// </summary>
        /// <param name="typeFinder"></param>
        private static void AddTypeConverter(ITypeFinder typeFinder)
        {
            //find converters provided by other assemblies
            var converters = typeFinder.FindClassesOfType<ITypeConverter>();

            //create and sort instance of typeConverter
            var instances = converters
                .Select(converter => (ITypeConverter)Activator.CreateInstance(converter))
                .OrderBy(converter => converter.Order);

            foreach (var item in instances)
                item.Register();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initialize engine
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration"></param>
        public static void Initialize(IServiceCollection services, IConfiguration configuration)
        {
            //set base application path
            var provider = services.BuildServiceProvider();
            var hostingEnvironment = provider.GetRequiredService<IWebHostEnvironment>();
            var config = new GrandConfig();
            configuration.GetSection("Grand").Bind(config);

            CommonHelper.WebRootPath = hostingEnvironment.WebRootPath;
            CommonHelper.BaseDirectory = hostingEnvironment.ContentRootPath;
            CommonHelper.CacheTimeMinutes = config.DefaultCacheTimeMinutes;
            CommonHelper.CookieAuthExpires = config.CookieAuthExpires > 0 ? config.CookieAuthExpires : 24 * 365;
            CommonHelper.AllowToJsonResponse = config.AllowToJsonResponse;


        }
        #endregion
    }
}
