using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class BhandarTransactionRequest
    {
        public int BhandarId { get; set; }
        public int CreatedBy { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public int SupplierId { get; set; }
        public int PaymentAccountHead { get; set; }
        public decimal PurchasingPrice { get; set; }
        public string Notes { get; set; }
    }
}