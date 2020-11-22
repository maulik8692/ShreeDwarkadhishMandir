using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class Samadhaniji : ApplicationUserBase
    {
        public Samadhaniji()
        {
            UserTypeId = 5;
            UserTypeName = "Samadhaniji";
        }

        public Samadhaniji(IValidation<IApplicationUser> _validation) : base(_validation)
        {
            UserTypeId = 5;
            UserTypeName = "Samadhaniji";
        }
    }
}
