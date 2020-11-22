using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class Annexure : IAnnexure
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public int AccountGroupId { get; set; }
        public string AccountGroup { get; set; }
        public string NatureOfGroup { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public decimal BalanceAmount { get; set; }
        public string AnnexureName { get; set; }
        public int AnnexureOrder { get; set; }
        public decimal TotalPerAnnexure { get; set; }
    }
}
