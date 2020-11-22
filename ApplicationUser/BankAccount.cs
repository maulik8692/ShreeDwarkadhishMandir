using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class BankAccount : AccountHead
    {
        public BankAccount()
        {
            AccountTypeId = 1;
            AccountType = "Bank Account";
        }

        public BankAccount(IValidation<IAccountHead> _validation) : base(_validation)
        {
            AccountTypeId = 1;
            AccountType = "Bank Account";
        }
    }
}
