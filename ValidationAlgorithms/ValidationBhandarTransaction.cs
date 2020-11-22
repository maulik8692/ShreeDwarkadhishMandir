using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAlgorithms
{
    public class ValidationBhandarTransaction : IValidation<IBhandarTransaction>
    {
        public void Validate(IBhandarTransaction anyType)
        {
            if (anyType.Credit == 0 && anyType.Debit == 0)
            {
                throw new Exception("Either credit amount or debit amount is require.");
            }
            if (anyType.Credit > 0 && anyType.SupplierId == 0)
            {
                throw new Exception("Please select supplier.");
            }
            if (anyType.PaymentAccountHead > 0 && anyType.PurchasingPrice == 0)
            {
                throw new Exception("Please enter Purchasing amount.");
            }
            if (anyType.PurchasingPrice > 0 && anyType.PaymentAccountHead == 0)
            {
                throw new Exception("Please select payment account head.");
            }
            if (anyType.Debit > 0 && anyType.Notes.IsExactLength(0))
            {
                throw new Exception("Please provide some notes for debit bhandar.");
            }
        }
    }
}
