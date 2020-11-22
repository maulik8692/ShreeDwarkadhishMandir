using System;
using System.ComponentModel.DataAnnotations;

namespace InterfaceMiddleLayer
{
    public class ApplicationUserBase : IApplicationUser
    {
        private IValidation<IApplicationUser> validation = null;

        [Key]
        public int Id { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public int MandirId { get; set; }
        public int CreatedBy { get; set; }
        public string MandirName { get; set; }
        public string Address { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }


        public ApplicationUserBase()
        {
            Id = 0;
            Password = string.Empty;
            PhoneNumber = string.Empty;
            UserName = string.Empty;
            UserTypeId = 0;
            UserTypeName = string.Empty;
            MandirId = 0;
            CreatedBy = 0;
            MandirName = string.Empty;
            Address = string.Empty;
            DisplayName = string.Empty;
            Email = string.Empty;
        }

        public ApplicationUserBase(IValidation<IApplicationUser> _validation)
        {
            validation = _validation;
        }

        public void Validate()
        {
            validation.Validate(this);
        }
    }
}