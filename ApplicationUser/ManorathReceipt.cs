using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class ManorathReceipt : ReceiptBase
    {
        public ManorathReceipt()
        {
            ManorathType = "Manorath";
        }

        public ManorathReceipt(IValidation<IReceipt> _validation) : base(_validation)
        {
            ManorathType = "Manorath";
        }
    }
}
