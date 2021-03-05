using Grand.Core.Configuration;
using Grand.Core.DependencyInjection;
using Grand.Core.Routing;
using Grand.Core.TypeFinders;
using Grand.Framework.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grand.Framework.Infrastructure
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public class DependencyInjection : IDependencyInjection
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="ServiceCollection">Service Collection</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(IServiceCollection serviceCollection, ITypeFinder typeFinder, GrandConfig config)
        {
            RegisterFramework(serviceCollection);
        }

        /// <summary>
        /// Gets order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 0; }
        }

        private void RegisterFramework(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IRoutePublisher, RoutePublisher>();
        }
    }
}
