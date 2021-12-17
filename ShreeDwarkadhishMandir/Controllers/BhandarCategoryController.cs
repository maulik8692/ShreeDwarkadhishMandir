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
            else if (!CheckValidation.IsAllowedBhandarCategory())
            {
                return RedirectToAction("AccessDenied", "Error");
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
                bhandarCategoryRequest.Name = string.Empty;

                IRepository<IBhandarCategory> dal = FactoryDalLayer<IRepository<IBhandarCategory>>.Create("BhandarCategory");

                List<IBhandarCategory> bhandarCategories = dal.Search(bhandarCategoryRequest);

                JqGridResponse<IBhandarCategory> jsonData = new JqGridResponse<IBhandarCategory>();
                jsonData.total = bhandarCategories.IsNotNullList() ? bhandarCategories.First().Total : 1;
                jsonData.page = bhandarCategories.IsNotNullList() ? bhandarCategories.First().Page : 1;
                jsonData.records = bhandarCategories.IsNotNullList() ? bhandarCategories.First().Page : 1;
                jsonData.rows = bhandarCategories;

                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                JqGridResponse<IBhandarCategory> jsonData = new JqGridResponse<IBhandarCategory>();
                //jsonData.total = 1;
                //jsonData.page = page;
                //jsonData.records = 0;
                //jsonData.rows = new List<IBhandarCategory>();
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CreateBhandarCategory()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (!CheckValidation.IsAllowedCreateBhandarCategory())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }

        [HttpPost]
        public ActionResult CreateBhandarCategory(BhandarCategoryRequest bhandarCategory)
        {
            try
            {
                IBhandarCategory bhandarCategoryRequest = Factory<IBhandarCategory>.Create("BhandarCategory");
                bhandarCategoryRequest.Name = bhandarCategory.Name;
                bhandarCategoryRequest.CategoryCode = bhandarCategory.CategoryCode;
                bhandarCategoryRequest.GroupId = bhandarCategory.GroupId;
                bhandarCategoryRequest.Description = bhandarCategory.Description;
                bhandarCategoryRequest.Id = bhandarCategory.Id;
                bhandarCategoryRequest.IsActive = bhandarCategory.IsActive;
                bhandarCategoryRequest.Validate();
                bhandarCategoryRequest.CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();

                IRepository<IBhandarCategory> dal = FactoryDalLayer<IRepository<IBhandarCategory>>.Create("BhandarCategory");
                dal.Save(bhandarCategoryRequest);

                return Json("Bhandar Group saved successfully.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }
    }
}