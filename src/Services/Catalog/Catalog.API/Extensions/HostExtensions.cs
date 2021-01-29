﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using System;

namespace Catalog.API.Extensions
{
    public static class HostExtensions
    {

        public static IHost MigrateDbContext<TContext>(this IHost host, Action<TContext, IServiceProvider> seeder) where TContext : DbContext
        {
            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;

            var context = services.GetService<TContext>();

            try
            {
                var retry = Policy.Handle<SqlException>()
                            .WaitAndRetry(new TimeSpan[]
                            {
                                TimeSpan.FromSeconds(3),
                                TimeSpan.FromSeconds(5),
                                TimeSpan.FromSeconds(8),
                            });

                //if the sql server container is not created on run docker compose this
                //migration can't fail for network related exception. The retry options for DbContext only 
                //apply to transient exceptions
                // Note that this is NOT applied when running some orchestrators (let the orchestrator to recreate the failing service)
                retry.Execute(() => InvokeSeeder(seeder, context, services));
            }
            catch (Exception ex)
            {

            }

            return host;
        }

        private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext context, IServiceProvider services)
            where TContext : DbContext
        {
            context.Database.Migrate();
            seeder(context, services);
        }
    }
}