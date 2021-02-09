using Core.Enums;
using Core.Models.Table;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Context
{
    public interface ICurrentContext
    {
        HttpContext HttpContext { get; set; }
        Guid? UserId { get; set; }
        User User { get; set; }
        string DeviceIdentifier { get; set; }
        DeviceType? DeviceType { get; set; }
        string IpAddress { get; set; }

        Guid? InstallationId { get; set; }
        Guid? OrganizationId { get; set; }

        Task BuildAsync(HttpContext httpContext);
        Task BuildAsync(ClaimsPrincipal user);
    }
}
