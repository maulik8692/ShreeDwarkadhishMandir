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
    public class BhandarController : Controller
    {
        // GET: Bhandar
        public ActionResult Bhandar()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        public ActionResult GetBhandarForDropdown()
        {
            try
            {
                IBhandar BhandarRequest = Factory<IBhandar>.Create("Bhandar");

                IRepository<IBhandar> dal = FactoryDalLayer<IRepository<IBhandar>>.Create("Bhandar");

                List<IBhandar> Bhandars = dal.DropdownWithSearch(0);

                return Json(Bhandars, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult BhandarDetail(BhandarRequest Bhandar)
        {
            try
            {
                IBhandar BhandarRequest = Factory<IBhandar>.Create("Bhandar");
                BhandarRequest.Id = Bhandar.Id;

                IRepository<IBhandar> dal = FactoryDalLayer<IRepository<IBhandar>>.Create("Bhandar");

                IBhandar Bhandars = dal.GetDetail(BhandarRequest);

                return Json(Bhandars, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        public JsonResult BhandarList(string sidx, string sord, int page, int rows)
        {
            try
            {
                IBhandar BhandarRequest = Factory<IBhandar>.Create("Bhandar");
                BhandarRequest.PageNumber = page;
                BhandarRequest.PageSize = rows;

                IRepository<IBhandar> dal = FactoryDalLayer<IRepository<IBhandar>>.Create("Bhandar");

                List<IBhandar> Bhandars = dal.Search(BhandarRequest);

                JqGridResponse<IBhandar> jsonData = new JqGridResponse<IBhandar>();
                jsonData.total = Bhandars.IsNotNullList() ? Bhandars.First().Page : 0;
                jsonData.page = page;
                jsonData.records = Bhandars.IsNotNullList() ? Bhandars.First().Total : 1;
                jsonData.rows = Bhandars;

                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                JqGridResponse<IBhandar> jsonData = new JqGridResponse<IBhandar>();
                jsonData.total = 1;
                jsonData.page = page;
                jsonData.records = 0;
                jsonData.rows = new List<IBhandar>();
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CreateBhandar()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult CreateBhandar(BhandarRequest Bhandar)
        {
            try
            {
                IBhandar BhandarRequest = Factory<IBhandar>.Create("Bhandar");
                BhandarRequest.Id = Bhandar.Id;
                //BhandarRequest.MandirId = Bhandar.MandirId;
                BhandarRequest.Name = Bhandar.Name;
                BhandarRequest.UnitId = Bhandar.UnitId;
                BhandarRequest.BhandarCategoryId = Bhandar.CategoryId;
                BhandarRequest.Balance = Bhandar.Balance;
                BhandarRequest.IsActive = Bhandar.IsActive;
                BhandarRequest.Validate();
                BhandarRequest.CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();

                IRepository<IBhandar> dal = FactoryDalLayer<IRepository<IBhandar>>.Create("Bhandar");
                dal.Save(BhandarRequest);

                return Json("Bhandar saved successfully.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }
    }
}