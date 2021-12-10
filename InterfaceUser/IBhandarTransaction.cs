using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IBhandarTransaction
    {
        int Id { get; set; }
        int BhandarId { get; set; }
        int StoreId { get; set; }
        int BhandarTransactionCodeId { get; set; }
        int UnitId { get; set; }
        int SupplierId { get; set; }
        int SamagriId { get; set; }
        decimal Price { get; set; }
        decimal PaidAccountBalance { get; set; }
        decimal TotalPaidBalance { get; set; }
        int CreatedBy { get; set; }
        int JewelleryUnitId { get; set; }
        decimal JewelleryQuantity { get; set; }
        decimal StockTransactionQuantity { get; set; }
        decimal TotalStockTransactionQuantity { get; set; }
        decimal CurrentBalance { get; set; }
        int AccountHeadId { get; set; }
        int VaishnavId { get; set; }

        //
        Guid TransactionId { get; set; }

        string Description { get; set; }
        int IncomeAccountId { get; set; }
        int ExpensesAccountId { get; set; }
        //
        string ChequeBank { get; set; }
        string ChequeBranch { get; set; }
        string ChequeNumber { get; set; }
        DateTime? ChequeDate { get; set; }
        int ChequeStatus { get; set; }
        int ReceiptId { get; set; }
        int? ApplicationUser { get; set; }
        DateTime? FromDate { get; set; }
        DateTime? ToDate { get; set; }
        string BhandarName { get; set; }
        string StoreName { get; set; }
        string UnitDescription { get; set; }
        string UnitAbbreviation { get; set; }
        DateTime CreatedOn { get; set; }
        string TransactionCode { get; set; }
        string TransactionType { get; set; }
        int MultiplicationWith { get; set; }
        string BhandarUnitAbbreviation { get; set; }
        void Validate();
    }
}
