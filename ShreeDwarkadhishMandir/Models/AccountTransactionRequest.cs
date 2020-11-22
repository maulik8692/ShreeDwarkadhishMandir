using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class AccountTransactionRequest
    {
        public int Id { get; set; }
        public int MandirId { get; set; }
        public int CreditAccountId { get; set; }
        public int DebitAccountId { get; set; }
        public string TransactionDate { get; set; }
        public decimal TransactionAmount { get; set; }
        public int CreatedBy { get; set; }
        public decimal DebitTransactionAmount { get; set; }
        public decimal CreditTransactionAmount { get; set; }
        public string CreatedName { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Description { get; set; }
    }
}