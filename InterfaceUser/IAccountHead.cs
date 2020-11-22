using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IAccountHead
    {
        int Id { get; set; }
        int MandirId { get; set; }
        int GroupId { get; set; }
        string AccountName { get; set; }
        string MandirName { get; set; }
        string Alias { get; set; }
        decimal BalanceAmount { get; set; }
        string DebitCredit { get; set; }
        string AccountHolderName { get; set; }
        string BankBranch { get; set; }
        string BankName { get; set; }
        string BankAddress { get; set; }
        string IFSCCode { get; set; }
        string AccountNumber { get; set; }
        DateTime? DateOfIssue { get; set; }
        DateTime? DateOfMaturity { get; set; }
        decimal InterestRate { get; set; }
        decimal MaturityAmount { get; set; }
        int CreatedBy { get; set; }
        bool IsActive { get; set; }
        bool IsEditable { get; set; }
        bool IsDelete { get; set; }
        bool IsForAccountTransaction { get; set; } 
        int Total { get; set; }
        int Page { get; set; }
        int Records { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
        string GroupName { get; set; }
        string NatureOfGroup { get; set; }
        int AnnexureOrder { get; set; }
        string AnnexureName { get; set; }
        void Validate();
    }
}
