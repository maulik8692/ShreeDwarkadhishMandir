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
    public class UnitConversionController : Controller
    {
        // GET: UnitConversion
        public ActionResult UnitConversion()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (!CheckValidation.IsAllowedUnitConversion())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }

        public JsonResult UnitConversionList(string sidx, string sord, int page, int rows)
        {
            try
            {
                IUnitConversion unitConversionRequest = Factory<IUnitConversion>.Create("UnitConversion");
                unitConversionRequest.PageNumber = page;
                unitConversionRequest.PageSize = rows;
                unitConversionRequest.MainUnitDescription = string.Empty;

                IRepository<IUnitConversion> dal = FactoryDalLayer<IRepository<IUnitConversion>>.Create("UnitConversion");

                List<IUnitConversion> unitConversions = dal.Search(unitConversionRequest);

                JqGridResponse<IUnitConversion> jsonData = new JqGridResponse<IUnitConversion>();
                jsonData.total = unitConversions.IsNotNullList() ? unitConversions.First().Page : 1;
                jsonData.page = page;
                jsonData.records = unitConversions.IsNotNullList() ? unitConversions.First().Total : 1;
                jsonData.rows = unitConversions;

                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                JqGridResponse<IUnitConversion> jsonData = new JqGridResponse<IUnitConversion>();
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CreateUnitConversion()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (!CheckValidation.IsAllowedCreateUnitConversion())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }

        [HttpPost]
        public ActionResult CreateUnitConversion(UnitConversionRequest UnitConversion)
        {
            try
            {
                IRepository<IUnitConversion> dal = FactoryDalLayer<IRepository<IUnitConversion>>.Create("UnitConversion");
                IUnitConversion unitConversionRequest = UnitConversion.GetRequestParameter(dal);
                dal.Save(unitConversionRequest);

                return Json("Unit Conversion saved successfully.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(406, ex.Message);
            }
        }
    }
}