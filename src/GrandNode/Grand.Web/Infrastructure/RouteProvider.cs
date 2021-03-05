using Grand.Core.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grand.Web.Infrastructure
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(IEndpointRouteBuilder routeBuilder)
        {
            var pattern = "";

            routeBuilder.MapControllers();
        }

        public int Priority => 0;
    }
}
