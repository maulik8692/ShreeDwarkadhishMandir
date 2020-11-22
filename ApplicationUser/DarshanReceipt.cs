using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class DarshanReceipt : ReceiptBase
    {
        public DarshanReceipt()
        {
            ManorathType = "Darshan";
        }

        public DarshanReceipt(IValidation<IReceipt> _validation) : base(_validation)
        {
            ManorathType = "Darshan";
        }
    }
}
