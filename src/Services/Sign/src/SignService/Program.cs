using System;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace SignService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Build().Run();
        }

        public static IWebHostBuilder BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                    .ConfigureAppConfiguration((context, config) =>
                    {

                    })
                    .ConfigureAppConfiguration((builder =>
                                                {
                                                    builder.AddJsonFile(@"App_Data\appsettings.json", true, true);
                                                }))
                    .UseStartup<Startup>();
                    
    }
}
