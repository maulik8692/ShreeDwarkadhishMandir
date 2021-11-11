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
            if (anyType.StockTransactionQuantity > 0 && anyType.Description.IsExactLength(0))
            {
                throw new Exception("Please enter Description.");
            }

            if (anyType.BhandarTransactionCodeId == (int)BhandarTransactionCode.Purchase && !anyType.IncomeAccountId.IsPositive())
            {
                throw new Exception("Please select Paid From account.");
            }
            if (anyType.BhandarTransactionCodeId == (int)BhandarTransactionCode.Purchase && !anyType.ExpensesAccountId.IsPositive())
            {
                throw new Exception("Expenses Account is missing in one or more item.");
            }
            if (anyType.BhandarTransactionCodeId == (int)BhandarTransactionCode.Purchase && !anyType.Price.IsPositive())
            {
                throw new Exception("Purchase cost is missing in one or more item.");
            }
            if (anyType.BhandarTransactionCodeId == (int)BhandarTransactionCode.Purchase && !anyType.PaidAccountBalance.IsPositive())
            {
                throw new Exception("Purchase account does not having enough Balance.");
            }
            if (anyType.BhandarTransactionCodeId == (int)BhandarTransactionCode.Purchase && !anyType.TotalPaidBalance.IsPositive())
            {
                throw new Exception("Purchase account does not having enough Balance.");
            }
            if (anyType.BhandarTransactionCodeId == (int)BhandarTransactionCode.Purchase && anyType.TotalPaidBalance > anyType.PaidAccountBalance)
            {
                throw new Exception("Purchase account does not having enough Balance.");
            }

            if (
                (
                    anyType.BhandarTransactionCodeId == (int)BhandarTransactionCode.Scrap 
                    ||
                    anyType.BhandarTransactionCodeId == (int)BhandarTransactionCode.IssueForSamagri
                ) 
                && anyType.CurrentBalance < anyType.StockTransactionQuantity)
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

            if (anyType.BhandarTransactionCodeId == (int)BhandarTransactionCode.IssueFrom && anyType.CurrentBalance < anyType.TotalStockTransactionQuantity)
            {
                throw new Exception("Total Transaction Quantity must be less than or equal to current balance.");
            }
        }
    }
}
