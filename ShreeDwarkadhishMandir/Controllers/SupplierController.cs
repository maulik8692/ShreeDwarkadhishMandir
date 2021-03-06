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
    public class SupplierController : Controller
    {
        // GET: Supplier
        public ActionResult Supplier()
        {
            return View();
        }

        public ActionResult GetSuppliersForDropdown()
        {
            try
            {
                ISupplier SupplierRequest = Factory<ISupplier>.Create("Supplier");

                IRepository<ISupplier> dal = FactoryDalLayer<IRepository<ISupplier>>.Create("Supplier");

                List<ISupplier> suppliers = dal.DropdownWithSearch(0);

                return Json(suppliers, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult SupplierDetail(SupplierRequest supplier)
        {
            try
            {
                ISupplier SupplierRequest = Factory<ISupplier>.Create("Supplier");
                SupplierRequest.SupplierId = supplier.SupplierId;

                IRepository<ISupplier> dal = FactoryDalLayer<IRepository<ISupplier>>.Create("Supplier");

                ISupplier suppliers = dal.GetDetail(SupplierRequest);

                return Json(suppliers, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        public JsonResult SupplierList(string sidx, string sord, int page, int rows)
        {
            try
            {
                ISupplier SupplierRequest = Factory<ISupplier>.Create("Supplier");
                SupplierRequest.PageNumber = page;
                SupplierRequest.PageSize = rows;

                IRepository<ISupplier> dal = FactoryDalLayer<IRepository<ISupplier>>.Create("Supplier");

                List<ISupplier> suppliers = dal.Search(SupplierRequest);

                JqGridResponse<ISupplier> jsonData = new JqGridResponse<ISupplier>();
                jsonData.total = suppliers.IsNotNull() ? suppliers.First().Page : 1;
                jsonData.page = page;
                jsonData.records = suppliers.IsNotNull() ? suppliers.First().Total : 1;
                jsonData.rows = suppliers;

                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                throw;
            }
        }

        public ActionResult CreateSupplier()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult CreateSupplier(SupplierRequest supplier)
        {
            try
            {
                ISupplier SupplierRequest = Factory<ISupplier>.Create("Supplier");
                SupplierRequest.MandirId = supplier.MandirId;
                SupplierRequest.SupplierId = supplier.SupplierId;
                SupplierRequest.SupplierName = supplier.SupplierName;
                SupplierRequest.Address = supplier.Address;
                SupplierRequest.CountryId = supplier.CountryId;
                SupplierRequest.StateId = supplier.StateId;
                SupplierRequest.CityId = supplier.CityId;
                SupplierRequest.VillageId = supplier.VillageId;
                SupplierRequest.PostalCode = supplier.PostalCode;
                SupplierRequest.MobileNo = supplier.MobileNo;
                SupplierRequest.Email = supplier.Email;
                SupplierRequest.IsActive = supplier.IsActive;
                SupplierRequest.Validate();
                SupplierRequest.CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();

                IRepository<ISupplier> dal = FactoryDalLayer<IRepository<ISupplier>>.Create("Supplier");
                dal.Save(SupplierRequest);

                return Json("Supplier saved successfully.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }
    }
}