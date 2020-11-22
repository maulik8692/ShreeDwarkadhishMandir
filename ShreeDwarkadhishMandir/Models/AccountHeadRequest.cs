using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public class AccountHeadRequest
    {
        public int Id { get; set; }
        public int MandirId { get; set; }
        public int GroupId { get; set; }
        public string AccountName { get; set; }
        public string MandirName { get; set; }
        public string Alias { get; set; }
        public decimal BalanceAmount { get; set; }
        public string DebitCredit { get; set; }
        public string AccountHolderName { get; set; }
        public string BankBranch { get; set; }
        public string BankName { get; set; }
        public string BankAddress { get; set; }
        public string IFSCCode { get; set; }
        public string AccountNumber { get; set; }
        public DateTime? DateOfIssue { get; set; }
        public DateTime? DateOfMaturity { get; set; }
        public decimal InterestRate { get; set; }
        public decimal MaturityAmount { get; set; }
        public bool IsActive { get; set; }
        public bool IsEditable { get; set; }
        public bool IsDelete { get; set; }
        public int CreatedBy { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int Records { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string GroupName { get; set; }
        public string NatureOfGroup { get; set; }
        public int AnnexureOrder { get; set; }
        public string AnnexureName { get; set; }
    }
}