﻿using InterfaceMiddleLayer;

namespace MiddleLayer
{
    public class VallabhKul : ApplicationUserBase
    {
        public VallabhKul()
        {
            UserTypeId = 1;
            UserTypeName = "Vallabh";
        }

        public VallabhKul(IValidation<IApplicationUser> _validation) : base(_validation)
        {
            UserTypeId = 1;
            UserTypeName = "Vallabh";
        }
    }
}