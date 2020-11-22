using CommonLayer;
using FactoryDal;
using FactoryMiddleLayer;
using InterfaceDal;
using InterfaceMiddleLayer;
using ShreeDwarkadhishMandir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShreeDwarkadhishMandir.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult ReportList()
        {
            return View();
        }

        public ActionResult ManorathReceipt()
        {
            return View();
        }

        public ActionResult ManorathReceiptReport(ReceiptRequest receiptRequest)
        {
            try
            {
                return View(receiptRequest);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult GetManorathReceiptReport(ReceiptRequest receiptRequest)
        {
            try
            {
                IReceipt IReceipt = Factory<IReceipt>.Create("Receipt");
                IReceipt.MandirId = Function.ReadCookie(CookiesKey.AuthenticatedMandirId).ToInt();
                IReceipt.FromDate = receiptRequest.FromDate;
                IReceipt.ToDate = receiptRequest.ToDate;
                IReceipt.ManorathFromDate = receiptRequest.ManorathFromDate;
                IReceipt.ManorathToDate = receiptRequest.ManorathToDate;
                IReceipt.AccountId = receiptRequest.AccountId;
                IReceipt.OnlyManorath = receiptRequest.OnlyManorath;
                IReceipt.CreatedBy = receiptRequest.CreatedBy;

                IRepository<IReceipt> dal = FactoryDalLayer<IRepository<IReceipt>>.Create("Receipt");
                List<IReceipt> IReceiptResponse = dal.GetReport(IReceipt);
                return Json(IReceiptResponse, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                List<IReceipt> IReceiptResponse = new List<IReceipt>();
                return Json(IReceiptResponse, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AccountTransaction()
        {
            return View();
        }

        public ActionResult AccountTransactionReport(AccountTransactionRequest accountTransactionRequest)
        {
            try
            {
                return View(accountTransactionRequest);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult GetAccountTransactionReport(AccountTransactionRequest accountTransactionRequest)
        {
            try
            {
                IAccountTransaction accountTransaction = Factory<IAccountTransaction>.Create("AccountTransaction");
                accountTransaction.MandirId = Function.ReadCookie(CookiesKey.AuthenticatedMandirId).ToInt();
                accountTransaction.FromDate = accountTransactionRequest.FromDate;
                accountTransaction.ToDate = accountTransactionRequest.ToDate;
                accountTransaction.AccountId = accountTransactionRequest.AccountId;

                IRepository<IAccountTransaction> dal = FactoryDalLayer<IRepository<IAccountTransaction>>.Create("AccountTransaction");
                List<IAccountTransaction> accountTransactionResponse = dal.GetReport(accountTransaction);
                return Json(accountTransactionResponse, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        public ActionResult BalanceSheet()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetBalanceSheet()
        {
            IRepository<IBalanceSheet> dal = FactoryDalLayer<IRepository<IBalanceSheet>>.Create("BalanceSheet");
            List<IBalanceSheet> balanceSheet = dal.GetReport(string.Empty);
            return Json(balanceSheet, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BalanceSheetDetails(int GroupId)
        {
            BalanceSheetRequest balanceSheet = new BalanceSheetRequest();
            balanceSheet.Id = GroupId;
            return View(balanceSheet);
        }

        [HttpPost]
        public ActionResult GetBalanceSheetDetails(BalanceSheetRequest balanceSheetRequest)
        {
            IRepository<IBalanceSheet> dal = FactoryDalLayer<IRepository<IBalanceSheet>>.Create("BalanceSheet");
            List<IBalanceSheet> balanceSheet = dal.Search(balanceSheetRequest.Id);
            return Json(balanceSheet, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IncomeExpenditure()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetIncomeExpenditure()
        {
            IRepository<IIncomeAndExpenditure> dal = FactoryDalLayer<IRepository<IIncomeAndExpenditure>>.Create("IncomeAndExpenditure");
            List<IIncomeAndExpenditure> balanceSheet = dal.GetReport(string.Empty);
            return Json(balanceSheet, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Annexure()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetAnnexure()
        {
            IRepository<IAnnexure> dal = FactoryDalLayer<IRepository<IAnnexure>>.Create("Annexure");
            List<IAnnexure> balanceSheet = dal.GetReport(string.Empty);
            return Json(balanceSheet, JsonRequestBehavior.AllowGet);
        }
    }
}