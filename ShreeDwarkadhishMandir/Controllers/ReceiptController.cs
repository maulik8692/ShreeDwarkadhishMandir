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
    public class ReceiptController : Controller
    {
        // GET: Receipt
        public ActionResult Receipt()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult CheckReceiptConfiguration()
        {
            try
            {
                IReceipt receiptConfiguration = Factory<IReceipt>.Create("Receipt");

                IRepository<IReceipt> dal = FactoryDalLayer<IRepository<IReceipt>>.Create("Receipt");

                receiptConfiguration.ReceiptConfigurationExists = dal.CheckData(receiptConfiguration);

                return Json(receiptConfiguration, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult SaveManorathReceipt(ReceiptRequest receiptRequest)
        {
            try
            {
                IReceipt receipt = Factory<IReceipt>.Create("Receipt");
                receipt.Nek = receiptRequest.Nek;
                receipt.ManorathId = receiptRequest.ManorathId;
                receipt.ManorathType = receiptRequest.ManorathType;
                receipt.TrasactionType = receiptRequest.TrasactionType;
                receipt.VaishnavId = receiptRequest.VaishnavId;
                receipt.ManorathiName = receiptRequest.ManorathiName;
                receipt.Email = receiptRequest.Email;
                receipt.MobileNo = receiptRequest.MobileNo;
                receipt.ManorathDate = receiptRequest.ManorathDate;
                receipt.ChequeBank = receiptRequest.ChequeBank;
                receipt.ChequeBranch = receiptRequest.ChequeBranch;
                receipt.ChequeNumber = receiptRequest.ChequeNumber;
                receipt.ChequeDate = receiptRequest.ChequeDate;
                receipt.ChequeStatus = receiptRequest.ChequeStatus;

                receipt.ManorathTithi = receiptRequest.ManorathTithi;
                receipt.ManorathTithiMaas = receiptRequest.ManorathTithiMaas;
                receipt.ManorathTithiPaksh = receiptRequest.ManorathTithiPaksh;
                receipt.Description = receiptRequest.Description;
                receipt.Validate();
                receipt.CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();
                IRepository<IReceipt> dal = FactoryDalLayer<IRepository<IReceipt>>.Create("Receipt");
                IReceipt IReceiptResponse = dal.SaveWithReturn(receipt);
                return Json(IReceiptResponse, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        public ActionResult ReceiptDetail()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult ReceiptDetail(ReceiptRequest receiptRequest)
        {
            try
            {
                IReceipt IReceipt = Factory<IReceipt>.Create("Receipt");
                IReceipt.Id = receiptRequest.Id;

                IRepository<IReceipt> dal = FactoryDalLayer<IRepository<IReceipt>>.Create("Receipt");
                IReceipt IReceiptResponse = dal.GetDetail(IReceipt);
                return Json(IReceiptResponse, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        public ActionResult ReceiptList()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        public JsonResult GetReceiptList(string sidx, string sord, int page, int rows)
        {
            try
            {
                IReceipt IReceipt = Factory<IReceipt>.Create("Receipt");
                IReceipt.MandirId = Function.ReadCookie(CookiesKey.AuthenticatedMandirId).ToInt();
                IReceipt.PageNumber = page;
                IReceipt.PageSize = rows;

                IRepository<IReceipt> dal = FactoryDalLayer<IRepository<IReceipt>>.Create("Receipt");
                List<IReceipt> IReceiptResponse = dal.Search(IReceipt);

                JqGridResponse<IReceipt> jsonData = new JqGridResponse<IReceipt>();
                jsonData.total = IReceiptResponse.IsNotNull() ? IReceiptResponse.First().Page : 0;
                jsonData.page = page;//IReceiptResponse.IsNotNull() ? IReceiptResponse.First().Page : 1;
                jsonData.records = IReceiptResponse.IsNotNull() ? IReceiptResponse.First().Total : 1;
                jsonData.rows = IReceiptResponse;
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                JqGridResponse<IReceipt> jsonData = new JqGridResponse<IReceipt>();
                jsonData.total = 1;
                jsonData.page = page;//IReceiptResponse.IsNotNull() ? IReceiptResponse.First().Page : 1;
                jsonData.records = 0;
                jsonData.rows = new List<IReceipt>();
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
        }

        
    }
}