using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAlgorithms
{
    public class ValidationReceipt : IValidation<IReceipt>
    {
        public void Validate(IReceipt anyType)
        {
            if (anyType.TrasactionType == "Cheque" && anyType.ChequeBank.IsExactLength(0))
            {
                throw new Exception("Please provie Cheque Bank name.");
            }

            if (anyType.TrasactionType == "Cheque" && anyType.ChequeBranch.IsExactLength(0))
            {
                throw new Exception("Please provie Cheque Branch name.");
            }

            if (anyType.TrasactionType == "Cheque" && anyType.ChequeNumber.IsExactLength(0))
            {
                throw new Exception("Please provie Cheque Number.");
            }

            if (anyType.TrasactionType == "Cheque" && anyType.ChequeDate.ToSafeString().IsExactLength(0))
            {
                throw new Exception("Please provie Cheque Date.");
            }

            if (anyType.ManorathType == 4 && !anyType.VaishnavId.ToInt().IsNotZero())
            {
                throw new Exception("Please select vaishnav.");
            }

            if (anyType.ManorathType == 4 && anyType.ManorathTithiMaas.IsExactLength(0))
            {
                throw new Exception("Please select manorath tithi maas.");
            }

            if (anyType.ManorathType == 4 && anyType.ManorathTithiPaksh.IsExactLength(0))
            {
                throw new Exception("Please select manorath tithi paksh.");
            }

            if (anyType.ManorathType == 4 && anyType.ManorathTithi.IsExactLength(0))
            {
                throw new Exception("Please select manorath tithi.");
            }

            if (!anyType.Nek.IsNotZero())
            {
                throw new Exception("Please enter Nyochavar.");
            }
        }
    }
}
