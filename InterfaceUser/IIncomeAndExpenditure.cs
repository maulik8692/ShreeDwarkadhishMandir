using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IIncomeAndExpenditure
    {
        int Id { get; set; }
        string AccountName { get; set; }
        string NatureOfGroup { get; set; }
        decimal Debit { get; set; }
        decimal Credit { get; set; }
        decimal TotalRight { get; set; }
        decimal TotalLeft { get; set; }
    }
}
