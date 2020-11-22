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
    public class SamagriController : Controller
    {
        // GET: Samagri
        public ActionResult Samagri()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        public JsonResult SamagriList(string sidx, string sord, int page, int rows)
        {
            try
            {
                ISamagriMaster SamagriRequest = Factory<ISamagriMaster>.Create("Samagri");
                SamagriRequest.PageNumber = page;
                SamagriRequest.PageSize = rows;

                IRepository<ISamagriMaster> dal = FactoryDalLayer<IRepository<ISamagriMaster>>.Create("Samagri");

                List<ISamagriMaster> Samagris = dal.Search(SamagriRequest);

                JqGridResponse<ISamagriMaster> jsonData = new JqGridResponse<ISamagriMaster>();
                jsonData.total = Samagris.IsNotNull() ? Samagris.First().Page : 0;
                jsonData.page = page;
                jsonData.records = Samagris.IsNotNull() ? Samagris.First().Total : 1;
                jsonData.rows = Samagris;

                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                throw;
            }
        }

        public ActionResult CreateSamagri()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult GetSamagriDetail(SamagriRequest samagriRequest)
        {
            try
            {
                ISamagriMaster samagri = Factory<ISamagriMaster>.Create("Samagri");
                samagri.Id = samagriRequest.Id;

                IRepository<ISamagriMaster> dal = FactoryDalLayer<IRepository<ISamagriMaster>>.Create("Samagri");

                ISamagriMaster samagris = dal.GetDetail(samagri);

                return Json(samagris, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult CreateSamagri(SamagriRequest samagriRequest)
        {
            try
            {
                ISamagriMaster samagri = Factory<ISamagriMaster>.Create("Samagri");
                samagri.Id = samagriRequest.Id;
                samagri.Name = samagriRequest.Name;
                samagri.Description = samagriRequest.Description;
                samagri.UnitId = samagriRequest.UnitId;
                samagri.NoOfUnit = samagriRequest.NoOfUnit;
                samagri.Balance = samagriRequest.Balance;
                samagri.MinStockValidation = samagriRequest.MinStockValidation;
                samagri.IsActive = samagriRequest.IsActive;
                samagri.Validate();
                samagri.CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();
                if (samagriRequest.SamagriBhandarRequest.IsNullList())
                {
                    throw new Exception("Please enter samagri bhandar details.");
                }

                IRepository<ISamagriMaster> dal = FactoryDalLayer<IRepository<ISamagriMaster>>.Create("Samagri");
                ISamagriMaster samagris = dal.SaveWithReturn(samagri);

                if (samagris.Id > 0)
                {
                    foreach (var item in samagriRequest.SamagriBhandarRequest.Where(x => (x.IsNew && x.IsActive) || (!x.IsNew)))
                    {
                        ISamagriBhandarDetail samagriBhandar = Factory<ISamagriBhandarDetail>.Create("SamagriBhandar");
                        samagriBhandar.Id = item.IsNew && item.IsActive ? 0 : item.Id;
                        samagriBhandar.SamagriId = samagris.Id;
                        samagriBhandar.BhandarId = item.BhandarId;
                        samagriBhandar.UnitId = item.UnitId;
                        samagriBhandar.NoOfUnit = item.NoOfUnit;
                        samagriBhandar.NoOfSamagri = samagri.NoOfUnit;
                        samagriBhandar.UnitPerSamagri = item.UnitPerSamagri;
                        samagriBhandar.MinStockValidation = samagri.MinStockValidation;
                        samagriBhandar.CreatedBy = samagri.CreatedBy;
                        samagriBhandar.IsActive = item.IsActive;

                        IRepository<ISamagriBhandarDetail> detail = FactoryDalLayer<IRepository<ISamagriBhandarDetail>>.Create("SamagriBhandar");
                        detail.Save(samagriBhandar);
                    }
                }

                return Json(samagris, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult GetSamagriBhandarList(SamagriBhandarRequest samagriBhandarRequest)
        {
            try
            {
                ISamagriBhandarDetail samagri = Factory<ISamagriBhandarDetail>.Create("SamagriBhandar");
                samagri.SamagriId = samagriBhandarRequest.SamagriId;

                IRepository<ISamagriBhandarDetail> dal = FactoryDalLayer<IRepository<ISamagriBhandarDetail>>.Create("SamagriBhandar");

                List<ISamagriBhandarDetail> samagris = dal.Search(samagri);

                return Json(samagris, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult ValidateSamagriBhandarDetail(SamagriBhandarRequest samagriBhandarDetail)
        {
            try
            {
                ISamagriBhandarDetail samagri = Factory<ISamagriBhandarDetail>.Create("SamagriBhandar");
                samagri.UnitId = samagriBhandarDetail.UnitId;
                samagri.BhandarId = samagriBhandarDetail.BhandarId;
                samagri.NoOfUnit = samagriBhandarDetail.NoOfUnit;
                samagri.Validate();

                return Json("Validation done.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }
    }
}