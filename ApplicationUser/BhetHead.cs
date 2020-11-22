using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class BhetHead : AccountHead
    {
        public BhetHead()
        {
            AccountTypeId = 3;
            AccountType = "Bhet";
        }

        public BhetHead(IValidation<IAccountHead> _validation) : base(_validation)
        {
            AccountTypeId = 3;
            AccountType = "Bhet";
        }
    }
}
