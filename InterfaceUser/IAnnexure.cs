using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface IAnnexure
    {
        int Id { get; set; }
        string GroupName { get; set; }
        int AccountGroupId { get; set; }
        string AccountGroup { get; set; }
        string NatureOfGroup { get; set; }
        int AccountId { get; set; }
        string AccountName { get; set; }
        decimal BalanceAmount { get; set; }
        string AnnexureName { get; set; }
        int AnnexureOrder { get; set; }
        decimal TotalPerAnnexure { get; set; }
    }
}
