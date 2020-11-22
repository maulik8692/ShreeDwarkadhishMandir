using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAlgorithms
{
    public class ValidationAccountTransaction : IValidation<IAccountTransaction>
    {
        public void Validate(IAccountTransaction anyType)
        {
            if (!anyType.MandirId.IsNotZero())
            {
                throw new Exception("Mandir is require.");
            }
            if (!anyType.CreditAccountId.IsNotZero())
            {
                throw new Exception("Credit Account is require.");
            }
            if (!anyType.DebitAccountId.IsNotZero())
            {
                throw new Exception("Debit Account is require.");
            }
            if (anyType.TransactionDate.IsNull() || !anyType.TransactionDate.IsDate())
            {
                throw new Exception("Transaction Date is require.");
            }
            if (!anyType.TransactionAmount.IsNotZero())
            {
                throw new Exception("Transaction Amount is require.");
            }
        }
    }
}
