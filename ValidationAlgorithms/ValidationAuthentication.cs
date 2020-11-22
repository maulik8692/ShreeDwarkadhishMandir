using CommonLayer;
using InterfaceMiddleLayer;
using System;

namespace ValidationAlgorithms
{
    public class ValidationAuthentication : IValidation<IApplicationUser>
    {
        public void Validate(IApplicationUser anyType)
        {
            if (anyType.UserName.IsExactLength(0))
            {
                throw new Exception("User Name is require.");
            }
            if (anyType.Password.IsExactLength(0))
            {
                throw new Exception("Password is require.");
            }
        }
    }
}