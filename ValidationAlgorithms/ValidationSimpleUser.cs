using CommonLayer;
using InterfaceMiddleLayer;
using System;

namespace ValidationAlgorithms
{
    public class ValidationSimpleUser : IValidation<IApplicationUser>
    {
        public void Validate(IApplicationUser anyType)
        {
            if (!anyType.MandirId.IsNotZero())
            {
                throw new Exception("Mandir is require.");
            }
            if (anyType.UserName.IsExactLength(0))
            {
                throw new Exception("User Name is require.");
            }
            if (anyType.Password.IsExactLength(0))
            {
                throw new Exception("Password is require.");
            }
            if (!anyType.Password.IsPassword())
            {
                throw new Exception("The password must be at least 8 characters, at least 1 uppercase character, at least 1 lowercase character, at least one number and a maximum of 30 characters.");
            }
            if (anyType.DisplayName.IsExactLength(0))
            {
                throw new Exception("Display Name is require.");
            }
        }
    }
}