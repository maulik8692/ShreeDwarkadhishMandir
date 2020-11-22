using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class BalanceSheet : IBalanceSheet
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
        public int AccountId { get; set; }
        public int AccountGroupId { get; set; }
        public string AccountName { get; set; }
        public decimal BalanceAmount { get; set; }
        public decimal TotalPerAnnexure { get; set; }
    }
}
