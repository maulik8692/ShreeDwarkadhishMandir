using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IBalanceSheet
    {
        int Id { get; set; }
        string GroupName { get; set; }
        string AccountGroup { get; set; }
        string NatureOfGroup { get; set; }
        decimal Debit { get; set; }
        decimal Credit { get; set; }
        decimal TotalLeft { get; set; }
        decimal TotalRight { get; set; }
        decimal AdjustAmountRight { get; set; }
        decimal AdjustAmountLeft { get; set; }
        string FinancialYear { get; set; }
        DateTime FinancialStartDate { get; set; }
        DateTime FinancialEndDate { get; set; }
        int AccountId { get; set; }
        int AccountGroupId { get; set; }
        string AccountName { get; set; }
        decimal BalanceAmount { get; set; }
        decimal TotalPerAnnexure { get; set; }
    }
}
