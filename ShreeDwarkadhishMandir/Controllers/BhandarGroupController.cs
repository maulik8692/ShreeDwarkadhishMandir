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
    public class BhandarGroupController : Controller
    {
        // GET: BhandarGroup
        public ActionResult BhandarGroup()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        public ActionResult CreateBhandarGroup()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult GetBhandarGroupDropdown()
        {
            try
            {
                IRepository<IBhandarGroup> dal = FactoryDalLayer<IRepository<IBhandarGroup>>.Create("BhandarGroup");

                List<IBhandarGroup> bhandarGroups = dal.DropdownWithSearch(0);

                return Json(bhandarGroups, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult BhandarGroupDetail(BhandarGroupRequest bhandarGroup)
        {
            try
            {
                IBhandarGroup BhandarRequest = Factory<IBhandarGroup>.Create("BhandarGroup");
                BhandarRequest.Id = bhandarGroup.Id;

                IRepository<IBhandarGroup> dal = FactoryDalLayer<IRepository<IBhandarGroup>>.Create("BhandarGroup");

                IBhandarGroup Bhandars = dal.GetDetail(BhandarRequest);

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
                IBhandarGroup BhandarRequest = Factory<IBhandarGroup>.Create("BhandarGroup");
                BhandarRequest.PageNumber = page;
                BhandarRequest.PageSize = rows;
                BhandarRequest.MandirId = Function.ReadCookie(CookiesKey.AuthenticatedMandirId).ToInt();
                BhandarRequest.Name = string.Empty;

                IRepository<IBhandarGroup> dal = FactoryDalLayer<IRepository<IBhandarGroup>>.Create("BhandarGroup");

                List<IBhandarGroup> Bhandars = dal.Search(BhandarRequest);

                JqGridResponse<IBhandarGroup> jsonData = new JqGridResponse<IBhandarGroup>();
                jsonData.total = Bhandars.IsNotNullList() ? Bhandars.First().Page : 1;
                jsonData.page = page;
                jsonData.records = Bhandars.IsNotNullList() ? Bhandars.First().Total : 1;
                jsonData.rows = Bhandars;

                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                JqGridResponse<IBhandarGroup> jsonData = new JqGridResponse<IBhandarGroup>();
                //jsonData.total = 1;
                //jsonData.page = page;
                //jsonData.records = 0;
                //jsonData.rows = new List<IBhandarGroup>();
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult CreateBhandarGroup(BhandarGroupRequest bhandarGroup)
        {
            try
            {
                IBhandarGroup BhandarRequest = Factory<IBhandarGroup>.Create("BhandarGroup");
                BhandarRequest.Id = bhandarGroup.Id;
                BhandarRequest.MandirId = bhandarGroup.MandirId;
                BhandarRequest.Name = bhandarGroup.Name;
                BhandarRequest.GroupCode = bhandarGroup.GroupCode;
                BhandarRequest.Description = bhandarGroup.Description;
                BhandarRequest.IsActive = bhandarGroup.IsActive;
                BhandarRequest.GroupType = bhandarGroup.GroupType;
                BhandarRequest.Validate();
                BhandarRequest.CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();

                IRepository<IBhandarGroup> dal = FactoryDalLayer<IRepository<IBhandarGroup>>.Create("BhandarGroup");
                dal.Save(BhandarRequest);

                return Json("Bhandar Group saved successfully.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(406, ex.Message);
            }
        }
    }
}