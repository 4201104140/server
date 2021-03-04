using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog.Events;
using System;

namespace Admin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Host
            //    .CreateDefaultBuilder(args)
            //    .ConfigureWebHostDefaults(webBuilder =>
            //    {
            //        webBuilder.ConfigureKestrel(o =>
            //        {
            //            o.Limits.MaxRequestLineSize = 20_000;
            //        });
            //        webBuilder.UseStartup<Startup>();
            //        webBuilder.ConfigureLogging((hostingContext, logging) =>
            //        logging.AddSerilog(hostingContext, e =>
            //        { 

            //        }));
            //    })
            //    .Build()
            //    .Run();
        }
    }
}
