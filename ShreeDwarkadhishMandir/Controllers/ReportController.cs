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
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (!CheckValidation.IsAllowedReportList())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }

        public ActionResult ManorathReceipt()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (!CheckValidation.IsAllowedManorathReceiptReport())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }

        public ActionResult ManorathReceiptReport(ReceiptRequest receiptRequest)
        {
            try
            {
                if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
                {
                    return RedirectToAction("Login", "Login");
                }
                else if (!CheckValidation.IsAllowedManorathReceiptReport())
                {
                    return RedirectToAction("AccessDenied", "Error");
                }

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
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (!CheckValidation.IsAllowedAccountTransactionReport())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

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
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (!CheckValidation.IsAllowedBalanceSheet())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

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
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (!CheckValidation.IsAllowedBalanceSheet())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

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
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (!CheckValidation.IsAllowedIncomeExpenditure())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

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
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (!CheckValidation.IsAllowedAnnexure())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }

        [HttpPost]
        public ActionResult GetAnnexure()
        {
            IRepository<IAnnexure> dal = FactoryDalLayer<IRepository<IAnnexure>>.Create("Annexure");
            List<IAnnexure> balanceSheet = dal.GetReport(string.Empty);
            return Json(balanceSheet, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BhandarTransaction()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (!CheckValidation.IsAllowedBhandarTransaction())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }

        public ActionResult BhandarTransactionReport(SamagriTransactionRequest SamagriTransactionRequest)
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (!CheckValidation.IsAllowedBhandarTransaction())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View(SamagriTransactionRequest);
        }

        [HttpPost]
        public ActionResult GetBhandarTransactionReport(SamagriTransactionRequest SamagriTransactionRequest)
        {
            try
            {
                IBhandarTransaction request = SamagriTransactionRequest.Report();
                List<IBhandarTransaction> BhandarTransactionResponse = new List<IBhandarTransaction>();
                IRepository<IBhandarTransaction> dalBhandarTransaction = FactoryDalLayer<IRepository<IBhandarTransaction>>.Create("BhandarTransaction");
                BhandarTransactionResponse =  dalBhandarTransaction.GetReport(request);
                return Json(BhandarTransactionResponse, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }
    }
}