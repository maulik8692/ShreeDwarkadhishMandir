using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class BhandarTransaction : IBhandarTransaction
    {
        private IValidation<IBhandarTransaction> validation = null;

        public int BhandarId { get; set; }
        public int CreatedBy { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public double BhandarBalance { get; set; }
        public int SupplierId { get; set; }
        public int PaymentAccountHead { get; set; }
        public decimal PurchasingPrice { get; set; }
        public string Notes { get; set; }

        public BhandarTransaction(IValidation<IBhandarTransaction> _validation)
        {
            validation = _validation;
        }

        public void Validate()
        {
            validation.Validate(this);
        }
    }
}
