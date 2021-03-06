﻿using System;
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
    public class UnitMeasurementController : Controller
    {
        // GET: UnitMeasurement
        public ActionResult UnitMeasurement()
        {
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
                jsonData.total = unitMeasurements.IsNotNull() ? unitMeasurements.First().Page : 0; //unitMeasurements.IsNotNull() ? unitMeasurements.First().Total : 0;
                // Current Page
                jsonData.page = page;//unitMeasurements.IsNotNull() ? unitMeasurements.First().Page : 1;
                //
                jsonData.records = unitMeasurements.IsNotNull() ? unitMeasurements.First().Total : 1;
                jsonData.rows = unitMeasurements;

                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                throw;
            }
        }

        [HttpPost]
        public ActionResult UnitOfMeasurementDropdown()
        {
            IRepository<IUnitOfMeasurement> dal = FactoryDalLayer<IRepository<IUnitOfMeasurement>>.Create("UnitOfMeasurement");
            List<IUnitOfMeasurement> accountHeadDropdown = dal.DropdownWithSearch(0);

            return Json(accountHeadDropdown, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateUnitMeasurement()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
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