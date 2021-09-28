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
using static EnumLayer.BhandarTransactionCodeEnum;

namespace ShreeDwarkadhishMandir.Controllers
{
    public class SamagriTransactionController : Controller
    {
        // GET: SamagriTransaction
        public ActionResult SamagriTransaction()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        public ActionResult Issue()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Issue(int id)
        {
            try
            {
                return Json("Samagri saved successfully.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        public ActionResult Scraped()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Scraped(SamagriTransactionRequest SamagriTransactionRequest)
        {
            try
            {
                IBhandarTransaction bhandarTransaction = Factory<IBhandarTransaction>.Create("BhandarTransaction");
                bhandarTransaction.BhandarId = SamagriTransactionRequest.BhandarId;
                bhandarTransaction.UnitId = SamagriTransactionRequest.UnitId;
                bhandarTransaction.StoreId = SamagriTransactionRequest.StoreId;
                bhandarTransaction.CurrentBalance = SamagriTransactionRequest.CurrentBalance;
                bhandarTransaction.BhandarTransactionCodeId = (int)BhandarTransactionCode.Scrap;
                bhandarTransaction.StockTransactionQuantity = SamagriTransactionRequest.StockTransactionQuantity;
                bhandarTransaction.Description = SamagriTransactionRequest.Description;
                bhandarTransaction.Validate();
                bhandarTransaction.CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();

                IBhandarTransaction BhandarTransactionResponse = Factory<IBhandarTransaction>.Create("BhandarTransaction");

                IRepository<IBhandarTransaction> dalBhandarTransaction = FactoryDalLayer<IRepository<IBhandarTransaction>>.Create("BhandarTransaction");
                BhandarTransactionResponse = dalBhandarTransaction.SaveWithReturn(bhandarTransaction);

                return Json("Bhandar has been scrapped successfully.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        public ActionResult Purchase()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }
        [HttpPost]
        public ActionResult Purchase(int id)
        {
            try
            {
                return Json("Samagri saved successfully.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        public ActionResult Donation()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }
        [HttpPost]
        public ActionResult Donation(int id)
        {
            try
            {
                return Json("Samagri saved successfully.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        public ActionResult Complementary()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }
        [HttpPost]
        public ActionResult Complementary(int id)
        {
            try
            {
                return Json("Samagri saved successfully.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

    }
}