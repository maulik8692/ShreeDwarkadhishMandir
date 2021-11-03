using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommonLayer;
using FactoryMiddleLayer;
using InterfaceMiddleLayer;
using static EnumLayer.BhandarTransactionCodeEnum;

namespace ShreeDwarkadhishMandir.Models
{
    public class SamagriTransactionRequest
    {
        public int BhandarId { get; set; }
        public int CreatedBy { get; set; }
        public decimal StockTransactionQuantity { get; set; }
        public decimal CurrentBalance { get; set; }
        public int SupplierId { get; set; }
        public int AccountHeadId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int BhandarTransactionCodeId { get; set; }
        public int UnitId { get; set; }
        public int SamagriId { get; set; }
        public int CreatedOn { get; set; }
        public int JewelleryUnitId { get; set; }
        public decimal JewelleryQuantity { get; set; }
        public int VaishnavId { get; set; }
        public int IncomeAccountId { get; set; }
        public int ExpensesAccountId { get; set; }
        public string ChequeBank { get; set; }
        public string ChequeBranch { get; set; }
        public string ChequeNumber { get; set; }
        public DateTime? ChequeDate { get; set; }
        public int ChequeStatus { get; set; }
        public List<SamagriTransactionRequest> ItemDetails { get; set; }

        public List<IBhandarTransaction> Purchase()
        {
            if (this.ItemDetails.IsNotNullList())
            {
                List<IBhandarTransaction> bhandarTransactions = new List<IBhandarTransaction>();
                foreach (var item in this.ItemDetails)
                {
                    IBhandarTransaction bhandarTransaction = Factory<IBhandarTransaction>.Create("BhandarTransaction");
                    bhandarTransaction.IncomeAccountId = this.IncomeAccountId;
                    bhandarTransaction.BhandarId = item.BhandarId;
                    bhandarTransaction.PaidAccountBalance = this.CurrentBalance;
                    bhandarTransaction.TotalPaidBalance = this.Price;
                    bhandarTransaction.Description = this.Description;
                    bhandarTransaction.StoreId = item.StoreId;
                    bhandarTransaction.BhandarTransactionCodeId = (int)BhandarTransactionCode.Purchase;
                    bhandarTransaction.UnitId = item.UnitId;
                    bhandarTransaction.StockTransactionQuantity = item.StockTransactionQuantity;
                    bhandarTransaction.Price = item.Price;
                    bhandarTransaction.ExpensesAccountId = item.ExpensesAccountId;

                    bhandarTransaction.ChequeBranch = this.ChequeBranch;
                    bhandarTransaction.ChequeBank = this.ChequeBank;
                    bhandarTransaction.ChequeDate = this.ChequeDate;
                    bhandarTransaction.ChequeNumber = this.ChequeNumber;
                    bhandarTransaction.ChequeStatus = this.ChequeStatus;

                    bhandarTransaction.Validate();
                    bhandarTransactions.Add(bhandarTransaction);
                }

                bhandarTransactions.ForEach(x => x.CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt());

                return bhandarTransactions;
            }
            else
            {
                throw new Exception("There must be atlease one item of purchase.");
            }
        }

        public List<IBhandarTransaction> Scrapped()
        {
            if (this.ItemDetails.IsNotNullList())
            {
                List<IBhandarTransaction> bhandarTransactions = new List<IBhandarTransaction>();
                foreach (var item in this.ItemDetails)
                {
                    IBhandarTransaction bhandarTransaction = Factory<IBhandarTransaction>.Create("BhandarTransaction");
                    bhandarTransaction.BhandarId = item.BhandarId;
                    bhandarTransaction.UnitId = item.UnitId;
                    bhandarTransaction.StoreId = item.StoreId;
                    bhandarTransaction.CurrentBalance = item.CurrentBalance;
                    bhandarTransaction.BhandarTransactionCodeId = (int)BhandarTransactionCode.Scrap;
                    bhandarTransaction.StockTransactionQuantity = item.StockTransactionQuantity;
                    bhandarTransaction.Description = this.Description;
                    bhandarTransaction.Validate();
                    bhandarTransactions.Add(bhandarTransaction);
                }

                bhandarTransactions.ForEach(x => x.CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt());

                return bhandarTransactions;
            }
            else
            {
                throw new Exception("There must be atlease one item for Scrapped.");
            }
        }

        public List<IBhandarTransaction> Donation()
        {
            if (this.ItemDetails.IsNotNullList())
            {
                List<IBhandarTransaction> bhandarTransactions = new List<IBhandarTransaction>();
                foreach (var item in this.ItemDetails)
                {
                    IBhandarTransaction bhandarTransaction = Factory<IBhandarTransaction>.Create("BhandarTransaction");
                    bhandarTransaction.BhandarId = item.BhandarId;
                    bhandarTransaction.VaishnavId = this.VaishnavId;
                    bhandarTransaction.UnitId = item.UnitId;
                    bhandarTransaction.StoreId = item.StoreId;
                    bhandarTransaction.CurrentBalance = item.CurrentBalance;
                    bhandarTransaction.BhandarTransactionCodeId = (int)BhandarTransactionCode.Donation;
                    bhandarTransaction.StockTransactionQuantity = item.StockTransactionQuantity;
                    bhandarTransaction.Description = this.Description;
                    bhandarTransaction.Validate();
                    bhandarTransactions.Add(bhandarTransaction);
                }

                bhandarTransactions.ForEach(x => x.CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt());

                return bhandarTransactions;
            }
            else
            {
                throw new Exception("There must be atlease one item for Donation.");
            }
        }
    }
}