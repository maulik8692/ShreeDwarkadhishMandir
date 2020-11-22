using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMiddleLayer
{
    public interface ISamagriTransaction
    {
        int Id { get; set; }
        int SamagriId { get; set; }
        decimal Credit { get; set; }
        decimal Debit { get; set; }
        int TransactionId { get; set; }
        void Validate();
    }
}
