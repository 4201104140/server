using Core.Enums;
using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.Table
{
    public class User : ITableObject<Guid>, ISubscriber, IStorable, IStorableSubscriber, IRevisable 
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string MasterPassword { get; set; }
        public string MasterPasswordHint { get; set; }
        public string Culture { get; set; } = "en-US";
        public string SecurityStamp { get; set; }
        public string TwoFactorProviders { get; set; }
        public string TwoFactorRecoveryCode { get; set; }
        public string EquivalentDomains { get; set; }
        public string ExcludedGlobalEquivalentDomains { get; set; }
        public DateTime AccountRevisionDate { get; internal set; } = DateTime.UtcNow;
        public string Key { get; set; }
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public bool Premium { get; set; }
        public DateTime? PremiumExpirationDate { get; set; }
        public DateTime? RenewalReminderDate { get; set; }
        public long? Storage { get; set; }
        public short? MaxStorageGb { get; set; }
        public GatewayType? Gateway { get; set; }
        public string GatewayCustomerId { get; set; }
        public string GatewaySubscriptionId { get; set; }
        public string ReferenceData { get; set; }
        public string LicenseKey { get; set; }
        public string ApiKey { get; set; }
        public KdfType Kdf { get; set; } = KdfType.PBKDF2_SHA256;
        public int KdfIterations { get; set; } = 5000;
        public DateTime CreationDate { get; internal set; } = DateTime.UtcNow;
        public DateTime RevisionDate { get; internal set; } = DateTime.UtcNow;

        public void SetNewId()
        {
            Id = CoreHelpers.GenerateComb();
        }

        public string BillingEmailAddress()
        {
            return Email?.ToLowerInvariant()?.Trim();
        }

        public string BillingName()
        {
            return Name;
        }

        public string BraintreeCustomerIdPrefix()
        {
            return "u";
        }

        public string BraintreeIdField()
        {
            return "user_id";
        }

        public string GatewayIdField()
        {
            return "userId";
        }

        public bool IsUser()
        {
            return true;
        }

        public Guid? GetUserId()
        {
            return Id;
        }

        public long StorageBytesRemaining()
        {
            if (!MaxStorageGb.HasValue)
            {
                return 0;
            }

            return StorageBytesRemaining(MaxStorageGb.Value);
        }

        public long StorageBytesRemaining(short maxStorageGb)
        {
            var maxStorageBytes = maxStorageGb * 1073741824L;
            if (!Storage.HasValue)
            {
                return maxStorageBytes;
            }

            return maxStorageBytes - Storage.Value;
        }
    }
}
