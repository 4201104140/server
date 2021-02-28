using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Identity.API;
using System.IO;
using Services.Identity.API.Data;
using Microsoft.Extensions.Options;

string Namespace = typeof(Startup).Namespace;
string AppName = Namespace.Substring(Namespace.LastIndexOf('.', Namespace.LastIndexOf('.') - 1) + 1);

var configuration = GetConfiguration();

//try
//{
    var host = CreateHostBuilder(configuration, args).Build();
    host.MigrateDbContext<ApplicationDbContext>((context, services) =>
    {

        var env = services.GetService<IWebHostEnvironment>();
        var logger = services.GetService<ILogger<ApplicationDbContextSeed>>();
        var settings = services.GetService<IOptions<AppSettings>>();

        new ApplicationDbContextSeed()
            .SeedAsync(context, env, logger, settings)
            .Wait();
    });
    host.Start();
    return 0;
//}
//catch (Exception ex)
//{
    
//    return 1;
//}
//finally
//{
//}

static IHostBuilder CreateHostBuilder(IConfiguration configuration ,string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder
                .CaptureStartupErrors(false)
                .ConfigureAppConfiguration(x => x.AddConfiguration(configuration))
                .UseStartup<Startup>()
                .UseContentRoot(Directory.GetCurrentDirectory());
        });

IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

    return builder.Build();
}
