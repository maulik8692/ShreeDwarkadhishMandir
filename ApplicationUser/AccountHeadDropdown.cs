using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class AccountHeadDropdown : IAccountHeadDropdown
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public decimal BalanceAmount { get; set; }
        public int MandirId { get; set; }
        public decimal Nyochavar { get; set; }
        public int AccountTypeId { get; set; }
        public string ReceiptType { get; set; }
    }
}
