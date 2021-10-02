using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EnumLayer.BhandarTransactionCodeEnum;

namespace ValidationAlgorithms
{
    public class ValidationBhandarTransaction : IValidation<IBhandarTransaction>
    {
        public void Validate(IBhandarTransaction anyType)
        {
            if (!anyType.StoreId.IsNotZero())
            {
                throw new Exception("Please select Store.");
            }
            if (!anyType.BhandarId.IsNotZero())
            {
                throw new Exception("Please select Bhandar.");
            }
            if (!anyType.UnitId.IsNotZero())
            {
                throw new Exception("Please select Unit Of Measurement.");
            }

            if (anyType.StockTransactionQuantity == 0)
            {
                throw new Exception("Stock Transaction Quantity is require.");
            }
            if (anyType.AccountHeadId > 0 && anyType.Price == 0)
            {
                throw new Exception("Please enter Purchasing amount.");
            }
            if (anyType.Price > 0 && anyType.AccountHeadId == 0)
            {
                throw new Exception("Please select payment account head.");
            }
            if (anyType.StockTransactionQuantity > 0 && anyType.Description.IsExactLength(0))
            {
                throw new Exception("Please enter Description.");
            }
            if (anyType.BhandarTransactionCodeId == (int)BhandarTransactionCode.Scrap && anyType.CurrentBalance < anyType.StockTransactionQuantity)
            {
                throw new Exception("Transaction Quantity must be less than or equal to current balance.");
            }
            if (anyType.BhandarTransactionCodeId == (int)BhandarTransactionCode.Donation && !anyType.VaishnavId.IsNotZero())
            {
                throw new Exception("Please select Vaishnav name.");
            }
            if (anyType.BhandarTransactionCodeId == (int)BhandarTransactionCode.SoldOut && !anyType.Price.IsPositive())
            {
                throw new Exception("Please enter proper sold out price.");
            }
        }
    }
}
