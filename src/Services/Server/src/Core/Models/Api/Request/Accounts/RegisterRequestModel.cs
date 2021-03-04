using Core.Models.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models.Api
{
    public class RegisterRequestModel /*: IValidatableObject*/
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string MasterPasswordHash { get; set; }

        public string MasterPasswordHint { get; set; }

        public string Key { get; set; }

        public string Token { get; set; }

        public User ToUser()
        {
            var user = new User
            {
                Name = Name,
                Email = Email,
                MasterPasswordHint = MasterPasswordHint,

            };

            return user;
        }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if ()
        //}
    }
}
