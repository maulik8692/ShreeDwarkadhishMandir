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
        public decimal StockTransactionQuantity { get; set; }
        //public decimal Debit { get; set; }
        public double BhandarBalance { get; set; }
        public int SupplierId { get; set; }
        public int PaymentAccountHeadId { get; set; }
        public decimal PurchasingPrice { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int BhandarTransactionCodeId { get; set; }
        public int UnitId { get; set; }
        public int SamagriId { get; set; }
        public int CreatedOn { get; set; }
        public int JewelleryUnitId { get; set; }
        public decimal JewelleryQuantity { get; set; }

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
