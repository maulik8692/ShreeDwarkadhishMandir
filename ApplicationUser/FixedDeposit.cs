using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class FixedDeposit : AccountHead
    {
        public FixedDeposit()
        {
            AccountTypeId = 2;
            AccountType = "Fixed Depositt";
        }

        public FixedDeposit(IValidation<IAccountHead> _validation) : base(_validation)
        {
            AccountTypeId = 2;
            AccountType = "Fixed Deposit";
        }
    }
}
