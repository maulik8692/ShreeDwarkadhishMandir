using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleLayer
{
    public class SamagriTransaction : ISamagriTransaction
    {
        public int Id { get; set; }
        public int SamagriId { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public int TransactionId { get; set; }

        public void Validate()
        {
        }
    }
}
