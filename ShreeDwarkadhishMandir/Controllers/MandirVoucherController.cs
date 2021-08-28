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
    public class MandirVoucherController : Controller
    {

        public ActionResult MandirVoucher()
        {
            return View();
        }

        public ActionResult GetMandirVouchersForDropdown()
        {
            try
            {
                IMandirVoucher MandirVoucherRequest = Factory<IMandirVoucher>.Create("MandirVoucher");

                IRepository<IMandirVoucher> dal = FactoryDalLayer<IRepository<IMandirVoucher>>.Create("MandirVoucher");

                List<IMandirVoucher> MandirVouchers = dal.DropdownWithSearch(0);

                return Json(MandirVouchers, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult MandirVoucherDetail(MandirVoucherRequest MandirVoucher)
        {
            try
            {
                IMandirVoucher MandirVoucherRequest = Factory<IMandirVoucher>.Create("MandirVoucher");
                MandirVoucherRequest.Id = MandirVoucher.Id;

                IRepository<IMandirVoucher> dal = FactoryDalLayer<IRepository<IMandirVoucher>>.Create("MandirVoucher");

                IMandirVoucher MandirVouchers = dal.GetDetail(MandirVoucherRequest);

                return Json(MandirVouchers, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        public JsonResult MandirVoucherList(string sidx, string sord, int page, int rows)
        {
            try
            {
                IMandirVoucher MandirVoucherRequest = Factory<IMandirVoucher>.Create("MandirVoucher");
                MandirVoucherRequest.PageNumber = page;
                MandirVoucherRequest.PageSize = rows;

                IRepository<IMandirVoucher> dal = FactoryDalLayer<IRepository<IMandirVoucher>>.Create("MandirVoucher");

                List<IMandirVoucher> MandirVouchers = dal.Search(MandirVoucherRequest);

                JqGridResponse<IMandirVoucher> jsonData = new JqGridResponse<IMandirVoucher>();
                jsonData.total = MandirVouchers.IsNotNullList() ? MandirVouchers.First().Page : 1;
                jsonData.page = page;
                jsonData.records = MandirVouchers.IsNotNullList() ? MandirVouchers.First().Total : 1;
                jsonData.rows = MandirVouchers;

                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                JqGridResponse<IMandirVoucher> jsonData = new JqGridResponse<IMandirVoucher>();
                jsonData.total = 1;
                jsonData.page = page;
                jsonData.records = 0;
                jsonData.rows = new List<IMandirVoucher>();
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CreateMandirVoucher()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult CreateMandirVoucher(MandirVoucherRequest mandirVoucherRequest)
        {
            try
            {
                IMandirVoucher MandirVoucherRequest = Factory<IMandirVoucher>.Create("MandirVoucher");
                MandirVoucherRequest.VoucherNo = mandirVoucherRequest.VoucherNo;
                MandirVoucherRequest.VoucherDate = mandirVoucherRequest.VoucherDate;
                MandirVoucherRequest.AccountId = mandirVoucherRequest.AccountId;
                MandirVoucherRequest.VoucherAmount = mandirVoucherRequest.VoucherAmount;
                MandirVoucherRequest.Description = mandirVoucherRequest.Description;
                MandirVoucherRequest.VoucherType = mandirVoucherRequest.VoucherType;
                MandirVoucherRequest.Validate();
                MandirVoucherRequest.CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();

                IRepository<IMandirVoucher> dal = FactoryDalLayer<IRepository<IMandirVoucher>>.Create("MandirVoucher");
                dal.Save(MandirVoucherRequest);

                return Json("Mandir voucher saved successfully.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }
    }
}