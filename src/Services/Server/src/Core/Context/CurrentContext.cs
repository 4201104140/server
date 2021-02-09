using Core.Enums;
using Core.Models.Table;
using Core.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Context
{
    public class CurrentContext : ICurrentContext
    {
        private bool _builtHttpContext;
        private bool _builtClaimsPrincipal;

        public virtual HttpContext HttpContext { get; set; }
        public virtual Guid? UserId { get; set; }
        public virtual User User { get; set; }
        public virtual string DeviceIdentifier { get; set; }
        public virtual DeviceType? DeviceType { get; set; }
        public virtual string IpAddress { get; set; }

        public virtual Guid? InstallationId { get; set; }
        public virtual Guid? OrganizationId { get; set; }

        public async virtual Task BuildAsync(HttpContext httpContext)
        {
            if (_builtHttpContext)
            {
                return;
            }

            _builtHttpContext = true;
            HttpContext = httpContext;
            
            if (DeviceIdentifier == null && httpContext.Request.Headers.ContainsKey("Device-Identifier"))
            {
                DeviceIdentifier = httpContext.Response.Headers["Device-Identifier"];
            }

            if (httpContext.Request.Headers.ContainsKey("Device-Type") &&
                Enum.TryParse(httpContext.Request.Headers["Device-Type"].ToString(), out DeviceType dType))
            {
                DeviceType = dType;
            }
            await Task.CompletedTask;
        }

        public async virtual Task BuildAsync(ClaimsPrincipal user)
        {
            if (_builtClaimsPrincipal)
            {
                return;
            }

            _builtClaimsPrincipal = true;
            IpAddress = HttpContext.GetIpAddress();
            await Task.CompletedTask;
        }
    }
}
