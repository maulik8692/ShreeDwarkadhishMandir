using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IAccountHeadDropdown
    {
        int AccountId { get; set; }
        string AccountName { get; set; }
        decimal BalanceAmount { get; set; }
        decimal Nyochavar { get; set; }
        int MandirId { get; set; }
        int AccountTypeId { get; set; }
        string ReceiptType { get; set; }
    }
}
