using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkRepos = Core.Repositories.EntityFramework;

namespace Core.Utilities
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSqlServerRepositories(this IServiceCollection services)
        {

            var useEf = false;

            if (useEf)
            {
                services.AddDbContext<EntityFrameworkRepos.DatabaseContext>(options =>
                {

                });
            }
        }
    }
}
