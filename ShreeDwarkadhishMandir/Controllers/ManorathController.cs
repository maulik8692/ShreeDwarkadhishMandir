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
    public class ManorathController : Controller
    {
        // GET: Manorath
        public ActionResult CreateManorath()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        public ActionResult Manorath()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult ManorathDetail(ManorathRequest ManorathRequest)
        {
            IManorath ManorathDetail = Factory<IManorath>.Create("Manorath");
            ManorathDetail.Id = ManorathRequest.Id;

            IRepository<IManorath> dal = FactoryDalLayer<IRepository<IManorath>>.Create("Manorath");

            IManorath Manorath = dal.GetDetail(ManorathDetail);

            return Json(Manorath, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ManorathDropdown(AccountDropdownRequest accountDropdownRequest)
        {
            IManorath ManorathDropdownRequest = Factory<IManorath>.Create("Manorath");

            IRepository<IManorath> dal = FactoryDalLayer<IRepository<IManorath>>.Create("Manorath");
            List<IManorath> Manorath = dal.DropdownWithSearch(ManorathDropdownRequest);

            return Json(Manorath, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Manorath(ManorathRequest ManorathRequest)
        {
            try
            {
                IManorath saveManorath = Factory<IManorath>.Create("Manorath");
                saveManorath.Id = ManorathRequest.Id;
                saveManorath.ManorathName = ManorathRequest.ManorathName;
                saveManorath.Nyochhawar = ManorathRequest.Nyochhawar;
                saveManorath.CashAccountId = ManorathRequest.CashAccountId;
                saveManorath.ChequeAccountId = ManorathRequest.ChequeAccountId;
                saveManorath.VaishnavAccountId = ManorathRequest.VaishnavAccountId;
                saveManorath.IsActive = ManorathRequest.IsActive;
                saveManorath.ManorathType = ManorathRequest.ManorathType;
                saveManorath.DarshanId = ManorathRequest.DarshanId;
                saveManorath.Validate();
                saveManorath.CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();

                IRepository<IManorath> applicationUserdal = FactoryDalLayer<IRepository<IManorath>>.Create("Manorath");
                applicationUserdal.SaveWithReturn(saveManorath);

                string output = "Manorath save successfully.";

                return Json(output, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        public JsonResult ManorathList(string sidx, string sord, int page, int rows)
        {
            try
            {
                IManorath SupplierRequest = Factory<IManorath>.Create("Manorath");
                SupplierRequest.PageNumber = page;
                SupplierRequest.PageSize = rows;

                IRepository<IManorath> dal = FactoryDalLayer<IRepository<IManorath>>.Create("Manorath");

                List<IManorath> suppliers = dal.Search(SupplierRequest);

                JqGridResponse<IManorath> jsonData = new JqGridResponse<IManorath>();
                jsonData.total = !suppliers.IsNullList() ?  suppliers.First().Total : 0;
                jsonData.page = !suppliers.IsNullList() ? suppliers.First().Page : 1;
                jsonData.records = !suppliers.IsNullList() ? suppliers.First().Page : 1;
                jsonData.rows = suppliers;

                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                throw;
            }
        }

    }
}