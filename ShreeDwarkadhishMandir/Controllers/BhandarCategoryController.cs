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
    public class BhandarCategoryController : Controller
    {
        // GET: BhandarCategory
        public ActionResult BhandarCategory()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult BhandarCategoryDetail(BhandarCategoryRequest bhandarCategory)
        {
            try
            {
                IBhandarCategory bhandarCategoryRequest = Factory<IBhandarCategory>.Create("BhandarCategory");
                bhandarCategoryRequest.Id = bhandarCategory.Id;

                IRepository<IBhandarCategory> dal = FactoryDalLayer<IRepository<IBhandarCategory>>.Create("BhandarCategory");

                IBhandarCategory bhandarCategories = dal.GetDetail(bhandarCategoryRequest);

                return Json(bhandarCategories, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult GetBhandarCategoriesForDrodown()
        {
            try
            {
                IRepository<IBhandarCategory> dal = FactoryDalLayer<IRepository<IBhandarCategory>>.Create("BhandarCategory");

                List<IBhandarCategory> bhandarCategories = dal.DropdownWithSearch(0);

                return Json(bhandarCategories, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }


        public JsonResult BhandarCategoryList(string sidx, string sord, int page, int rows)
        {
            try
            {
                IBhandarCategory bhandarCategoryRequest = Factory<IBhandarCategory>.Create("BhandarCategory");
                bhandarCategoryRequest.PageNumber = page;
                bhandarCategoryRequest.PageSize = rows;

                IRepository<IBhandarCategory> dal = FactoryDalLayer<IRepository<IBhandarCategory>>.Create("BhandarCategory");

                List<IBhandarCategory> bhandarCategories = dal.Search(bhandarCategoryRequest);

                JqGridResponse<IBhandarCategory> jsonData = new JqGridResponse<IBhandarCategory>();
                jsonData.total = bhandarCategories.IsNotNull() ? bhandarCategories.First().Total : 0;
                jsonData.page = bhandarCategories.IsNotNull() ? bhandarCategories.First().Page : 1;
                jsonData.records = bhandarCategories.IsNotNull() ? bhandarCategories.First().Page : 1;
                jsonData.rows = bhandarCategories;

                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                throw;
            }
        }

        public ActionResult CreateBhandarCategory()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult CreateBhandarCategory(BhandarCategoryRequest bhandarCategory)
        {
            try
            {
                IBhandarCategory bhandarCategoryRequest = Factory<IBhandarCategory>.Create("BhandarCategory");
                bhandarCategoryRequest.CategoryName = bhandarCategory.CategoryName;
                bhandarCategoryRequest.Id = bhandarCategory.Id;
                bhandarCategoryRequest.IsActive = bhandarCategory.IsActive;
                bhandarCategoryRequest.Validate();
                bhandarCategoryRequest.CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();

                IRepository<IBhandarCategory> dal = FactoryDalLayer<IRepository<IBhandarCategory>>.Create("BhandarCategory");
                dal.Save(bhandarCategoryRequest);

                return View();
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }
    }
}