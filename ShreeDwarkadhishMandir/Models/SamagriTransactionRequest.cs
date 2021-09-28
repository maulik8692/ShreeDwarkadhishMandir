using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class SamagriTransactionRequest
    {
        public int BhandarId { get; set; }
        public int CreatedBy { get; set; }
        public decimal StockTransactionQuantity { get; set; }
        public decimal CurrentBalance { get; set; }
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
    }
}