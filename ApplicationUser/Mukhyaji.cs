using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class Mukhyaji : ApplicationUserBase
    {
        public Mukhyaji()
        {
            UserTypeId = 4;
            UserTypeName = "Mukhyaji";
        }

        public Mukhyaji(IValidation<IApplicationUser> _validation) : base(_validation)
        {
            UserTypeId = 4;
            UserTypeName = "Mukhyaji";
        }
    }
}
