//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using Serilog;
//using Serilog.Events;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Core.Utilities
//{
//    public static class LoggerFactoryExtensions
//    {

//        public static ILoggingBuilder AddSerilog(
//            this ILoggingBuilder builder,
//            WebHostBuilderContext context,
//            Func<LogEvent, bool> filter = null)
//        {
//            if (context.HostingEnvironment.IsDevelopment())
//            {
//                return builder;
//            }

//            bool inclusionPredicate(LogEvent e)
//            {
//                if (filter == null)
//                {
//                    return true;
//                }
//                var eventId = e.Properties.ContainsKey("EventId") ? e.Properties["EventId"].ToString() : null;
//                if (eventId?.Contains(Constants.BypassFiltersEventId.ToString()) ?? false)
//                {
//                    return true;
//                }
//                return filter(e);
//            }

//            var globalSettings = new GlobalSettings();
//            ConfigurationBinder.Bind(context.Configuration.GetSection("GlobalSettings"), globalSettings);

//            var config = new LoggerConfiguration()
//                .Enrich.FromLogContext()
//                .Filter.ByIncludingOnly(inclusionPredicate);

//            if (CoreHelpers.SettingHasValue(globalSettings?.))
//        }
//    }
//}
