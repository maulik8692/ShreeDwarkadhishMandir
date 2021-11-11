using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumLayer
{
    public class BhandarTransactionCodeEnum
    {
        public enum BhandarTransactionCode
        {
            Opening = 1,
            Purchase = 2,
            Donation = 3,
            IssueFrom = 4,
            IssueTo = 5,
            ReciptConsumption = 6,
            ManorathConsumption = 7,
            NekConsumption = 8,
            ComplementaryConsumption = 9,
            Scrap = 10,
            SoldOut = 11,
            SamagriIssue = 12,
            IssueForSamagri = 13,
            CorrectionOfIncreased = 14,
            CorrectionOfDecreased = 15
        }
    }
}
