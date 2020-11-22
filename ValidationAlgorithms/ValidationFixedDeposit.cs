using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAlgorithms
{
    public class ValidationFixedDeposit : IValidation<IAccountHead>
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
            if (anyType.AccountNumber.IsExactLength(0))
            {
                throw new Exception("Account Number is require.");
            }
            if (!anyType.DateOfIssue.IsDate())
            {
                throw new Exception("Date of Issue is require.");
            }
            if (!anyType.DateOfMaturity.IsDate())
            {
                throw new Exception("Date of Maturity is require.");
            }
            if (!anyType.InterestRate.IsNotZero())
            {
                throw new Exception("Rate of Interest is require.");
            }
            if (!anyType.MaturityAmount.IsNotZero())
            {
                throw new Exception("Maturity Amount is require.");
            }
        }
    }
}
