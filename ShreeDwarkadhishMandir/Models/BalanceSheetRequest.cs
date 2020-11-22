using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class BalanceSheetRequest
    {
        public int Id { get; set; }
        public string AccountGroup { get; set; }
        public string GroupName { get; set; }
        public string NatureOfGroup { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal TotalLeft { get; set; }
        public decimal TotalRight { get; set; }
        public decimal AdjustAmountRight { get; set; }
        public decimal AdjustAmountLeft { get; set; }
        public string FinancialYear { get; set; }
        public DateTime FinancialStartDate { get; set; }
        public DateTime FinancialEndDate { get; set; }
    }
}