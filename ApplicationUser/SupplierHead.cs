using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class SupplierHead : AccountHead
    {
        public SupplierHead()
        {
            AccountTypeId = 7;
            AccountType = "Supplier";
        }

        public SupplierHead(IValidation<IAccountHead> _validation) : base(_validation)
        {
            AccountTypeId = 7;
            AccountType = "Supplier";
        }
    }
}
