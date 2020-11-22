using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class SystemAdministrator : ApplicationUserBase
    {
        public SystemAdministrator()
        {
            UserTypeId = 2;
            UserTypeName = "System Admin";
        }

        public SystemAdministrator(IValidation<IApplicationUser> _validation) : base(_validation)
        {
            UserTypeId = 2;
            UserTypeName = "System Admin";
        }
    }
}
