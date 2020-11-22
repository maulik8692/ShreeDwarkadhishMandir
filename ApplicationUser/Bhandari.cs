using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class Bhandari : ApplicationUserBase
    {
        public Bhandari()
        {
            UserTypeId = 6;
            UserTypeName = "Bhandari";
        }

        public Bhandari(IValidation<IApplicationUser> _validation) : base(_validation)
        {
            UserTypeId = 6;
            UserTypeName = "Bhandari";
        }
    }
}
