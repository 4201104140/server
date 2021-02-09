using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.Table
{
    public class User : ITableObject<Guid>
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string MasterPassword { get; set; }
        public string MasterPasswordHint { get; set; }
        public string Culture { get; set; } = "en-US";
        public string SecurityStamp { get; set; }

        public void SetNewId()
        {
            Id = CoreHelpers.GenerateComb();
        }


        public Guid? GetUserId()
        {
            return Id;
        }

        
    }
}
