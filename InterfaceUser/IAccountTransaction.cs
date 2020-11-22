using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IAccountTransaction
    {
        int Id { get; set; }
        int MandirId { get; set; }
        int CreditAccountId { get; set; }
        int DebitAccountId { get; set; }
        DateTime TransactionDate { get; set; }
        decimal TransactionAmount { get; set; }
        decimal DebitTransactionAmount { get; set; }
        decimal CreditTransactionAmount { get; set; }
        int CreatedBy { get; set; }
        //
        string CreatedName { get; set; }
        int AccountId { get; set; }
        string AccountName { get; set; }
        DateTime? FromDate { get; set; }
        DateTime? ToDate { get; set; }
        string Description { get; set; }
        void Validate();
    }
}
