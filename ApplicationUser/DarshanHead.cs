using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class DarshanHead : AccountHead
    {
        public DarshanHead()
        {
            AccountTypeId = 6;
            AccountType = "Darshan";
        }

        public DarshanHead(IValidation<IAccountHead> _validation) : base(_validation)
        {
            AccountTypeId = 6;
            AccountType = "Darshan";
        }
    }
}
