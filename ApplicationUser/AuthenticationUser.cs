using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class AuthenticationUser : ApplicationUserBase
    {
        public AuthenticationUser()
        {
            UserTypeId = 0;
            UserTypeName = string.Empty;
        }

        public AuthenticationUser(IValidation<IApplicationUser> _validation) : base(_validation)
        {
            UserTypeId = 0;
            UserTypeName = string.Empty;
        }
    }
}
