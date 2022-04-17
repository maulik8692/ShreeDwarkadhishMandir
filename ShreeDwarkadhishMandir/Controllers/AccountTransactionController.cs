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
    [AuthorizationFilter.UserAuthorization]
    public class AccountTransactionController : Controller
    {
        // GET: AccountTransaction
        public ActionResult AccountTransaction()
        {
            if (!CheckValidation.IsAllowedAccountTransaction())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }

        public ActionResult TransactionList()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AccountTransaction(AccountTransactionRequest accountTransactionRequest)
        {
            try
            {
                IAccountTransaction accountTransaction = Factory<IAccountTransaction>.Create("AccountTransaction");
                accountTransaction.Id = accountTransactionRequest.Id;
                accountTransaction.MandirId = accountTransactionRequest.MandirId;
                accountTransaction.CreditAccountId = accountTransactionRequest.CreditAccountId;
                accountTransaction.DebitAccountId = accountTransactionRequest.DebitAccountId;
                accountTransaction.TransactionAmount = accountTransactionRequest.TransactionAmount;
                accountTransaction.Description = accountTransactionRequest.Description;
                if (accountTransactionRequest.TransactionDate.IsDate())
                {
                    accountTransaction.TransactionDate = accountTransactionRequest.TransactionDate.ToDateTime("dd-MMM-yyyy"); 
                }
                else
                {
                    throw new Exception("Transaction Date is require.");
                }
                accountTransaction.Validate();

                accountTransaction.CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();


                IRepository<IAccountTransaction> dal = FactoryDalLayer<IRepository<IAccountTransaction>>.Create("AccountTransaction");
                dal.Save(accountTransaction);

                string output = "Welcome to the Admin User";

                return Json(output, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }
    }
}