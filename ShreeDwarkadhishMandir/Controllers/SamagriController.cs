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
                ISamagri SamagriRequest = Factory<ISamagri>.Create("Samagri");
                SamagriRequest.PageNumber = page;
                SamagriRequest.PageSize = rows;

                IRepository<ISamagri> dal = FactoryDalLayer<IRepository<ISamagri>>.Create("Samagri");

                List<ISamagri> Samagris = dal.Search(SamagriRequest);

                JqGridResponse<ISamagri> jsonData = new JqGridResponse<ISamagri>();
                jsonData.total = Samagris.IsNotNullList() ? Samagris.First().Page : 0;
                jsonData.page = page;
                jsonData.records = Samagris.IsNotNullList() ? Samagris.First().Total : 1;
                jsonData.rows = Samagris;

                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                JqGridResponse<ISamagri> jsonData = new JqGridResponse<ISamagri>();
                jsonData.total = 1;
                jsonData.page = page;
                jsonData.records = 0;
                jsonData.rows = new List<ISamagri>();
                return Json(jsonData, JsonRequestBehavior.AllowGet);
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
                ISamagri samagri = Factory<ISamagri>.Create("Samagri");
                samagri.Id = samagriRequest.Id;

                IRepository<ISamagri> dal = FactoryDalLayer<IRepository<ISamagri>>.Create("Samagri");

                ISamagri samagris = dal.GetDetail(samagri);

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
                ISamagri samagri = Factory<ISamagri>.Create("Samagri");
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
                if (samagriRequest.SamagriDetailRequest.IsNullList())
                {
                    throw new Exception("Please enter samagri bhandar details.");
                }

                IRepository<ISamagri> dal = FactoryDalLayer<IRepository<ISamagri>>.Create("Samagri");
                ISamagri samagris = dal.SaveWithReturn(samagri);

                if (samagris.Id > 0)
                {
                    foreach (var item in samagriRequest.SamagriDetailRequest.Where(x => (x.IsNew && x.IsActive) || (!x.IsNew)))
                    {
                        ISamagriDetail samagriDetail = Factory<ISamagriDetail>.Create("SamagriBhandar");
                        samagriDetail.Id = item.IsNew && item.IsActive ? 0 : item.Id;
                        samagriDetail.SamagriId = samagris.Id;
                        samagriDetail.BhandarId = item.BhandarId;
                        samagriDetail.UnitId = item.UnitId;
                        samagriDetail.NoOfUnit = item.NoOfUnit;
                        samagriDetail.NoOfSamagri = samagri.NoOfUnit;
                        samagriDetail.UnitPerSamagri = item.UnitPerSamagri;
                        samagriDetail.MinStockValidation = samagri.MinStockValidation;
                        samagriDetail.CreatedBy = samagri.CreatedBy;
                        //samagriDetail.IsActive = item.IsActive;

                        IRepository<ISamagriDetail> detail = FactoryDalLayer<IRepository<ISamagriDetail>>.Create("SamagriDetail");
                        detail.Save(samagriDetail);
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
        public ActionResult GetSamagriDetailList(SamagriDetailRequest SamagriDetailRequest)
        {
            try
            {
                ISamagriDetail samagri = Factory<ISamagriDetail>.Create("SamagriDetail");
                samagri.SamagriId = SamagriDetailRequest.SamagriId;

                IRepository<ISamagriDetail> dal = FactoryDalLayer<IRepository<ISamagriDetail>>.Create("SamagriDetail");

                List<ISamagriDetail> samagris = dal.Search(samagri);

                return Json(samagris, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult ValidateSamagriDetail(SamagriDetailRequest SamagriDetail)
        {
            try
            {
                ISamagriDetail samagri = Factory<ISamagriDetail>.Create("SamagriDetail");
                samagri.UnitId = SamagriDetail.UnitId;
                samagri.BhandarId = SamagriDetail.BhandarId;
                samagri.NoOfUnit = SamagriDetail.NoOfUnit;
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