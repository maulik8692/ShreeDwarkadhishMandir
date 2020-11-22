using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class ManorathHead : AccountHead
    {
        public ManorathHead()
        {
            AccountTypeId = 4;
            AccountType = "Manorath";
        }

        public ManorathHead(IValidation<IAccountHead> _validation) : base(_validation)
        {
            AccountTypeId = 4;
            AccountType = "Manorath";
        }
    }
}
