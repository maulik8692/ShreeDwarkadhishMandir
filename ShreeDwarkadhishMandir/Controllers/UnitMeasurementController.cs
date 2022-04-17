using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using CommonLayer;

using FactoryDal;

using FactoryMiddleLayer;

using InterfaceDal;

using InterfaceMiddleLayer;

using ShreeDwarkadhishMandir.Models;

namespace ShreeDwarkadhishMandir.Controllers
{
    [AuthorizationFilter.UserAuthorization]
    public class UnitMeasurementController : Controller
    {
        // GET: UnitMeasurement
        public ActionResult UnitMeasurement()
        {
            if (!CheckValidation.IsAllowedUnitMeasurement())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }

        [HttpPost]
        public ActionResult UnitMeasurementDetail(UnitMeasurementRequest unitMeasurement)
        {
            try
            {
                IUnitOfMeasurement unitMeasurementRequest = Factory<IUnitOfMeasurement>.Create("UnitOfMeasurement");
                unitMeasurementRequest.Id = unitMeasurement.Id;

                IRepository<IUnitOfMeasurement> dal = FactoryDalLayer<IRepository<IUnitOfMeasurement>>.Create("UnitOfMeasurement");

                IUnitOfMeasurement unitMeasurements = dal.GetDetail(unitMeasurementRequest);

                return Json(unitMeasurements, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        public JsonResult UnitMeasurementList(string sidx, string sord, int page, int rows)
        {
            try
            {
                IUnitOfMeasurement unitMeasurementRequest = Factory<IUnitOfMeasurement>.Create("UnitOfMeasurement");
                unitMeasurementRequest.PageNumber = page;
                unitMeasurementRequest.PageSize = rows;

                IRepository<IUnitOfMeasurement> dal = FactoryDalLayer<IRepository<IUnitOfMeasurement>>.Create("UnitOfMeasurement");

                List<IUnitOfMeasurement> unitMeasurements = dal.Search(unitMeasurementRequest);

                JqGridResponse<IUnitOfMeasurement> jsonData = new JqGridResponse<IUnitOfMeasurement>();
                // Total Page
                jsonData.total = unitMeasurements.IsNotNullList() ? unitMeasurements.First().Page : 0; //unitMeasurements.IsNotNull() ? unitMeasurements.First().Total : 0;
                // Current Page
                jsonData.page = page;//unitMeasurements.IsNotNull() ? unitMeasurements.First().Page : 1;
                //
                jsonData.records = unitMeasurements.IsNotNullList() ? unitMeasurements.First().Total : 1;
                jsonData.rows = unitMeasurements;

                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                JqGridResponse<IUnitOfMeasurement> jsonData = new JqGridResponse<IUnitOfMeasurement>();
                jsonData.total = 1;
                jsonData.page = page;
                jsonData.records = 0;
                jsonData.rows = new List<IUnitOfMeasurement>();
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult UnitOfMeasurementDropdown(int bhandarId = 0)
        {
            IRepository<IUnitOfMeasurement> dal = FactoryDalLayer<IRepository<IUnitOfMeasurement>>.Create("UnitOfMeasurement");
            List<IUnitOfMeasurement> accountHeadDropdown = dal.DropdownWithSearch(bhandarId);

            return Json(accountHeadDropdown, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateUnitMeasurement()
        {
            if (!CheckValidation.IsAllowedCreateUnitMeasurement())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }

        [HttpPost]
        public ActionResult CreateUnitMeasurement(UnitMeasurementRequest unitMeasurement)
        {
            try
            {
                IUnitOfMeasurement bhandarCategoryRequest = Factory<IUnitOfMeasurement>.Create("UnitOfMeasurement");
                bhandarCategoryRequest.UnitAbbreviation = unitMeasurement.UnitAbbreviation;
                bhandarCategoryRequest.UnitDescription = unitMeasurement.UnitDescription;
                bhandarCategoryRequest.Id = unitMeasurement.Id;
                bhandarCategoryRequest.IsActive = unitMeasurement.IsActive;
                bhandarCategoryRequest.Validate();
                bhandarCategoryRequest.CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();

                IRepository<IUnitOfMeasurement> dal = FactoryDalLayer<IRepository<IUnitOfMeasurement>>.Create("UnitOfMeasurement");
                dal.Save(bhandarCategoryRequest);

                string output = "Unit Of Measurement save successfully.";

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