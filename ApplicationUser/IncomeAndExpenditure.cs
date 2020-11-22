using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class IncomeAndExpenditure : IIncomeAndExpenditure
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string NatureOfGroup { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal TotalLeft { get; set; }
        public decimal TotalRight { get; set; }
    }
}
