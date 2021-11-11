using CommonLayer;
using FactoryDal;
using FactoryMiddleLayer;
using InterfaceDal;
using InterfaceMiddleLayer;
using ShreeDwarkadhishMandir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
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
        public ActionResult Issue(SamagriTransactionRequest SamagriTransactionRequest)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    List<IBhandarTransaction> bhandarTransactions = SamagriTransactionRequest.Issue();

                    List<IBhandarTransaction> BhandarTransactionResponse = new List<IBhandarTransaction>();

                    IRepository<IBhandarTransaction> dalBhandarTransaction = FactoryDalLayer<IRepository<IBhandarTransaction>>.Create("BhandarTransaction");

                    foreach (var item in bhandarTransactions)
                    {
                        IBhandarTransaction bhandarTransactionResponse = dalBhandarTransaction.SaveWithReturn(item);
                    }

                    scope.Complete();
                }

                return Json("Bhandar has been Issued successfully.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        public ActionResult IssueForSamagri()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }
        [HttpPost]
        public ActionResult IssueForSamagri(SamagriTransactionRequest SamagriTransactionRequest)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    List<IBhandarTransaction> bhandarTransactions = SamagriTransactionRequest.IssueForSamagri();

                    List<IBhandarTransaction> BhandarTransactionResponse = new List<IBhandarTransaction>();

                    IRepository<IBhandarTransaction> dalBhandarTransaction = FactoryDalLayer<IRepository<IBhandarTransaction>>.Create("BhandarTransaction");

                    foreach (var item in bhandarTransactions)
                    {
                        IBhandarTransaction bhandarTransactionResponse = dalBhandarTransaction.SaveWithReturn(item);
                    }

                    scope.Complete();
                }

                return Json("Bhandar has been Issued successfully.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }


        public ActionResult Scrapped()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }
        [HttpPost]
        public ActionResult Scrapped(SamagriTransactionRequest SamagriTransactionRequest)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    List<IBhandarTransaction> bhandarTransactions = SamagriTransactionRequest.Scrapped();

                    List<IBhandarTransaction> BhandarTransactionResponse = new List<IBhandarTransaction>();

                    IRepository<IBhandarTransaction> dalBhandarTransaction = FactoryDalLayer<IRepository<IBhandarTransaction>>.Create("BhandarTransaction");

                    foreach (var item in bhandarTransactions)
                    {
                        IBhandarTransaction bhandarTransactionResponse = dalBhandarTransaction.SaveWithReturn(item);
                    }

                    scope.Complete();
                }

                return Json("Bhandar has been scrapped successfully.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        public ActionResult SoldOut()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }
        [HttpPost]
        public ActionResult SoldOut(SamagriTransactionRequest SamagriTransactionRequest)
        {
            try
            {
                IBhandarTransaction bhandarTransaction = Factory<IBhandarTransaction>.Create("BhandarTransaction");
                bhandarTransaction.BhandarId = SamagriTransactionRequest.BhandarId;
                bhandarTransaction.UnitId = SamagriTransactionRequest.UnitId;
                bhandarTransaction.StoreId = SamagriTransactionRequest.StoreId;
                bhandarTransaction.Price = SamagriTransactionRequest.Price;
                bhandarTransaction.CurrentBalance = SamagriTransactionRequest.CurrentBalance;
                bhandarTransaction.BhandarTransactionCodeId = (int)BhandarTransactionCode.SoldOut;
                bhandarTransaction.StockTransactionQuantity = SamagriTransactionRequest.StockTransactionQuantity;
                bhandarTransaction.Description = SamagriTransactionRequest.Description;
                bhandarTransaction.Validate();
                bhandarTransaction.CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();

                IBhandarTransaction BhandarTransactionResponse = Factory<IBhandarTransaction>.Create("BhandarTransaction");

                IRepository<IBhandarTransaction> dalBhandarTransaction = FactoryDalLayer<IRepository<IBhandarTransaction>>.Create("BhandarTransaction");
                BhandarTransactionResponse = dalBhandarTransaction.SaveWithReturn(bhandarTransaction);

                return Json("Bhandar has been sold out successfully.", JsonRequestBehavior.AllowGet);
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
        public ActionResult Purchase(SamagriTransactionRequest SamagriTransactionRequest)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    List<IBhandarTransaction> bhandarTransactions = SamagriTransactionRequest.Purchase();

                    List<IBhandarTransaction> BhandarTransactionResponse = new List<IBhandarTransaction>();

                    IRepository<IBhandarTransaction> dalBhandarTransaction = FactoryDalLayer<IRepository<IBhandarTransaction>>.Create("BhandarTransaction");

                    foreach (var item in bhandarTransactions)
                    {
                        IBhandarTransaction bhandarTransactionResponse = dalBhandarTransaction.SaveWithReturn(item);
                    }

                    scope.Complete();
                }

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
        public ActionResult Donation(SamagriTransactionRequest SamagriTransactionRequest)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    List<IBhandarTransaction> bhandarTransactions = SamagriTransactionRequest.Donation();

                    List<IBhandarTransaction> BhandarTransactionResponse = new List<IBhandarTransaction>();

                    IRepository<IBhandarTransaction> dalBhandarTransaction = FactoryDalLayer<IRepository<IBhandarTransaction>>.Create("BhandarTransaction");

                    foreach (var item in bhandarTransactions)
                    {
                        IBhandarTransaction bhandarTransactionResponse = dalBhandarTransaction.SaveWithReturn(item);
                    }

                    scope.Complete();
                }

                return Json("Bhandar Donation has been saved successfully.", JsonRequestBehavior.AllowGet);
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