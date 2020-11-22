using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAlgorithms
{
    public class ValidationBankAccount : IValidation<IAccountHead>
    {
        public void Validate(IAccountHead anyType)
        {
            if (!anyType.MandirId.IsNotZero())
            {
                throw new Exception("Mandir is require.");
            }
            if (anyType.AccountName.IsExactLength(0))
            {
                throw new Exception("Account Name is require.");
            }
            if (anyType.BankName.IsExactLength(0))
            {
                throw new Exception("Bank Name is require.");
            }
            if (anyType.BankAddress.IsExactLength(0))
            {
                throw new Exception("Bank Address is require.");
            }
            if (anyType.IFSCCode.IsExactLength(0))
            {
                throw new Exception("IFSC Code is require.");
            }
            if (anyType.AccountNumber.IsExactLength(0))
            {
                throw new Exception("Account Number is require.");
            }
            if (!anyType.BalanceAmount.IsNotZero())
            {
                throw new Exception("Amount is require.");
            }
        }
    }
}
