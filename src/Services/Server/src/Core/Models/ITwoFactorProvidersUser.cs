using Core.Enums;
using System;
using System.Collections.Generic;

namespace Core.Models
{
    public interface ITwoFactorProvidersUser
    {
        string TwoFactorProviders { get; }
        Dictionary<TwoFactorProviderType, TwoFactorProvider> GetTwoFactorProviders();
        Guid? GetUserId();
        bool GetPremium();
    }
}
