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
        public decimal TotalStockTransactionQuantity { get; set; }
        public decimal CurrentBalance { get; set; }
        public double BhandarBalance { get; set; }
        public int SupplierId { get; set; }
        public int AccountHeadId { get; set; }
        public decimal Price { get; set; }
        public decimal PaidAccountBalance { get; set; }
        public decimal TotalPaidBalance { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int BhandarTransactionCodeId { get; set; }
        public int UnitId { get; set; }
        public int SamagriId { get; set; }
        public int CreatedOn { get; set; }
        public int JewelleryUnitId { get; set; }
        public decimal JewelleryQuantity { get; set; }
        public int VaishnavId { get; set; }
        public Guid TransactionId { get; set; }
        public int IncomeAccountId { get; set; }
        public int ExpensesAccountId { get; set; }
        public string ChequeBank { get; set; }
        public string ChequeBranch { get; set; }
        public string ChequeNumber { get; set; }
        public DateTime? ChequeDate { get; set; }
        public int ChequeStatus { get; set; }
        public int ReceiptId { get; set; }
        public int? ApplicationUser { get; set; }

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
