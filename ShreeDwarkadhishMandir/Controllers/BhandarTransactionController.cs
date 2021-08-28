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
    public class BhandarTransactionController : Controller
    {
        // GET: BhandarTransaction
        public ActionResult AdjustBhandar()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult AdjustBhandar(BhandarTransactionRequest bhandarTransactionRequest)
        {
            try
            {
                IBhandarTransaction bhandarTransaction = Factory<IBhandarTransaction>.Create("BhandarTransaction");
                bhandarTransaction.BhandarId = bhandarTransactionRequest.BhandarId;
                bhandarTransaction.StockTransactionQuantity = bhandarTransactionRequest.Credit;
                //bhandarTransaction.Debit = bhandarTransactionRequest.Debit;
                bhandarTransaction.SupplierId = bhandarTransactionRequest.SupplierId;
                bhandarTransaction.PaymentAccountHeadId = bhandarTransactionRequest.PaymentAccountHead;
                bhandarTransaction.PurchasingPrice = bhandarTransactionRequest.PurchasingPrice;
                bhandarTransaction.Description = bhandarTransactionRequest.Notes;
                bhandarTransaction.Validate();
                bhandarTransaction.CreatedBy  = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();

                IRepository<IBhandarTransaction> dal = FactoryDalLayer<IRepository<IBhandarTransaction>>.Create("BhandarTransaction");

                dal.Save(bhandarTransaction);

                return Json("Bhandar adjustment has been successfully.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }
    }
}