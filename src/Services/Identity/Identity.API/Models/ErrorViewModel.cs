using IdentityServer4.Models;

namespace Services.Identity.API.Models
{
    public record ErrorViewModel
    {
        public ErrorMessage Error { get; set; }
    }
}
