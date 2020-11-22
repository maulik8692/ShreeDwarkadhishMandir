using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAlgorithms
{
    public class ValidationBhet : IValidation<IAccountHead>
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
        }
    }
}
