using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
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
        public ActionResult SamagriDetail(SamagriRequest samagriRequest)
        {
            try
            {
                ISamagri _samagriRequest = Factory<ISamagri>.Create("Samagri");
                _samagriRequest.Id = samagriRequest.Id;
                IRepository<ISamagri> dal = FactoryDalLayer<IRepository<ISamagri>>.Create("Samagri");
                ISamagri samagri = dal.GetDetail(_samagriRequest);

                ISamagriDetail samagriDetail = Factory<ISamagriDetail>.Create("SamagriDetail");
                samagriDetail.SamagriId = samagriRequest.Id;
                samagriDetail.Quantity = samagriRequest.OutputQuantity;
                samagriDetail.UnitId = samagriRequest.UnitId;

                IRepository<ISamagriDetail> detail = FactoryDalLayer<IRepository<ISamagriDetail>>.Create("SamagriDetail");
                List<ISamagriDetail> SamagriDetails = detail.Search(samagriDetail);

                samagri.SamagriDetails = SamagriDetails;

                return Json(samagri, JsonRequestBehavior.AllowGet);
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
                using (TransactionScope scope = new TransactionScope())
                {
                    samagriRequest.GetRequestParameter();
                    ISamagri samagri = Factory<ISamagri>.Create("Samagri");
                    samagri = samagriRequest.Samagri;
                    int CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();
                    samagri.CreatedBy = CreatedBy;

                    IRepository<ISamagri> dal = FactoryDalLayer<IRepository<ISamagri>>.Create("Samagri");
                    ISamagri samagris = dal.SaveWithReturn(samagri);

                    if (samagris.Id > 0)
                    {

                        List<ISamagriDetail> SamagriDetails = samagriRequest.SamagriDetails;
                        foreach (var item in SamagriDetails)
                        {
                            ISamagriDetail samagriDetail = Factory<ISamagriDetail>.Create("SamagriDetail");
                            IRepository<ISamagriDetail> detail = FactoryDalLayer<IRepository<ISamagriDetail>>.Create("SamagriDetail");
                            item.SamagriId = samagris.Id;
                            item.CreatedBy = CreatedBy;
                            detail.Save(item);
                        }
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
        public ActionResult GetSamagriDropdown()
        {
            try
            {
                IRepository<ISamagri> dal = FactoryDalLayer<IRepository<ISamagri>>.Create("Samagri");

                List<ISamagri> samagris = dal.DropdownWithSearch(0);

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
                samagri.Quantity = SamagriDetailRequest.Quantity;
                samagri.UnitId = SamagriDetailRequest.UnitId;

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