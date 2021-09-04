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
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Store()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        public JsonResult StoreList(string sidx, string sord, int page, int rows)
        {
            try
            {
                IStore StoreRequest = Factory<IStore>.Create("Store");
                StoreRequest.PageNumber = page;
                StoreRequest.PageSize = rows;
                StoreRequest.Name = string.Empty;

                IRepository<IStore> dal = FactoryDalLayer<IRepository<IStore>>.Create("Store");

                List<IStore> Stores = dal.Search(StoreRequest);

                JqGridResponse<IStore> jsonData = new JqGridResponse<IStore>();
                jsonData.total = Stores.IsNotNullList() ? Stores.First().Page : 1;
                jsonData.page = page;
                jsonData.records = Stores.IsNotNullList() ? Stores.First().Total : 1;
                jsonData.rows = Stores;

                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                JqGridResponse<IStore> jsonData = new JqGridResponse<IStore>();
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CreateStore()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult StoreDetail(StoreRequest Store)
        {
            try
            {
                IStore StoreRequest = Factory<IStore>.Create("Store");
                StoreRequest.Id = Store.Id;

                IRepository<IStore> dal = FactoryDalLayer<IRepository<IStore>>.Create("Store");

                IStore bhandarCategories = dal.GetDetail(StoreRequest);

                return Json(bhandarCategories, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }


        [HttpPost]
        public ActionResult CreateStore(StoreRequest Store)
        {
            try
            {
                IRepository<IStore> dal = FactoryDalLayer<IRepository<IStore>>.Create("Store");
                IStore StoreRequest = Store.GetRequestParameter();
                dal.Save(StoreRequest);

                return Json("Store saved successfully.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(406, ex.Message);
            }
        }
    }
}