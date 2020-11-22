using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class BhetReceipt : ReceiptBase
    {
        public BhetReceipt()
        {
            ManorathType = "Bhet";
        }

        public BhetReceipt(IValidation<IReceipt> _validation) : base(_validation)
        {
            ManorathType = "Bhet";
        }
    }
}
