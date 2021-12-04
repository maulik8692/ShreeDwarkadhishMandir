using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class AccountHead : IAccountHead
    {
        private IValidation<IAccountHead> validation = null;

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
        public bool IsForAccountTransaction { get; set; }
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
        public bool IsDefaultRecord { get; set; }
        public AccountHead()
        {
            Id = 0;
            MandirId = 0;
            AccountName = string.Empty;
            BalanceAmount = 0;
            BankName = string.Empty;
            BankAddress = string.Empty;
            IFSCCode = string.Empty;
            AccountNumber = string.Empty;
            DateOfIssue = null;
            DateOfMaturity = null;
            InterestRate = 0;
            MaturityAmount = 0;
            IsEditable = false;
            IsActive = false;
            CreatedBy = 0;
            AnnexureOrder = 0;
            AnnexureName = string.Empty;
        }

        public AccountHead(IValidation<IAccountHead> _validation)
        {
            validation = _validation;
        }

        public void Validate()
        {
            validation.Validate(this);
        }
    }
}
