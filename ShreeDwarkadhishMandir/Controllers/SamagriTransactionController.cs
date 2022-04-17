﻿using CommonLayer;
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
    [AuthorizationFilter.UserAuthorization]
    public class SamagriTransactionController : Controller
    {
        // GET: SamagriTransaction
        public ActionResult SamagriTransaction()
        {
            if (!CheckValidation.IsAllowedSamagriTransaction())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }

        public ActionResult Issue()
        {
            if (!CheckValidation.IsAllowedIssue())
            {
                return RedirectToAction("AccessDenied", "Error");
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
            if (!CheckValidation.IsAllowedIssueForSamagri())
            {
                return RedirectToAction("AccessDenied", "Error");
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
            if (!CheckValidation.IsAllowedScrapped())
            {
                return RedirectToAction("AccessDenied", "Error");
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
            if (!CheckValidation.IsAllowedSoldOut())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }
        [HttpPost]
        public ActionResult SoldOut(SamagriTransactionRequest SamagriTransactionRequest)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    List<IBhandarTransaction> bhandarTransactions = SamagriTransactionRequest.SoldOut();

                    List<IBhandarTransaction> BhandarTransactionResponse = new List<IBhandarTransaction>();

                    IRepository<IBhandarTransaction> dalBhandarTransaction = FactoryDalLayer<IRepository<IBhandarTransaction>>.Create("BhandarTransaction");

                    foreach (var item in bhandarTransactions)
                    {
                        IBhandarTransaction bhandarTransactionResponse = dalBhandarTransaction.SaveWithReturn(item);
                    }

                    scope.Complete();
                }

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
            if (!CheckValidation.IsAllowedPurchase())
            {
                return RedirectToAction("AccessDenied", "Error");
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
            if (!CheckValidation.IsAllowedDonation())
            {
                return RedirectToAction("AccessDenied", "Error");
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
            if (!CheckValidation.IsAllowedComplementary())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }
        [HttpPost]
        public ActionResult Complementary(SamagriTransactionRequest SamagriTransactionRequest)
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

        public ActionResult Nek()
        {
            if (!CheckValidation.IsAllowedNek())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }
        [HttpPost]
        public ActionResult Nek(SamagriTransactionRequest SamagriTransactionRequest)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    List<IBhandarTransaction> bhandarTransactions = SamagriTransactionRequest.NekConsumption();

                    List<IBhandarTransaction> BhandarTransactionResponse = new List<IBhandarTransaction>();

                    IRepository<IBhandarTransaction> dalBhandarTransaction = FactoryDalLayer<IRepository<IBhandarTransaction>>.Create("BhandarTransaction");

                    foreach (var item in bhandarTransactions)
                    {
                        IBhandarTransaction bhandarTransactionResponse = dalBhandarTransaction.SaveWithReturn(item);
                    }

                    scope.Complete();
                }

                return Json("Nek has been saved successfully.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }
    }
}