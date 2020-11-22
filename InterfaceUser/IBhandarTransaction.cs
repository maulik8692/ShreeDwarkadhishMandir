using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IBhandarTransaction
    {
        int BhandarId { get; set; }
        int CreatedBy { get; set; }
        decimal Credit { get; set; }
        decimal Debit { get; set; }

        int SupplierId { get; set; }
        int PaymentAccountHead { get; set; }
        decimal PurchasingPrice { get; set; }
        string Notes { get; set; }

        void Validate();
    }
}
