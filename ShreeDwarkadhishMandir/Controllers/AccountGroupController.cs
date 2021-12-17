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
    public class AccountGroupController : Controller
    {
        // GET: AccountGroup
        public ActionResult AccountGroup()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (!CheckValidation.IsAllowedAccountGroup())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }

        public ActionResult GetDefaultGroups()
        {
            IRepository<IDefaultGroups> dal = FactoryDalLayer<IRepository<IDefaultGroups>>.Create("DefaultGroups");
            List<IDefaultGroups> defaultGroups = dal.DropdownWithSearch(string.Empty);

            return Json(defaultGroups, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAccountGroupsForDropdown()
        {
            IRepository<IAccountGroup> dal = FactoryDalLayer<IRepository<IAccountGroup>>.Create("AccountGroup");
            List<IAccountGroup> accountGroups = dal.DropdownWithSearch(string.Empty);

            return Json(accountGroups, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AccountGroupList(string sidx, string sord, int page, int rows)
        {
            try
            {
                IAccountGroup AccountGroupRequest = Factory<IAccountGroup>.Create("AccountGroup");
                AccountGroupRequest.PageNumber = page;
                AccountGroupRequest.PageSize = rows;

                IRepository<IAccountGroup> dal = FactoryDalLayer<IRepository<IAccountGroup>>.Create("AccountGroup");

                List<IAccountGroup> AccountGroups = dal.Search(AccountGroupRequest);

                JqGridResponse<IAccountGroup> jsonData = new JqGridResponse<IAccountGroup>();
                jsonData.total = AccountGroups.IsNotNullList() ? AccountGroups.First().Total : 0;
                jsonData.page = AccountGroups.IsNotNullList() ? AccountGroups.First().Page : 1;
                jsonData.records = AccountGroups.IsNotNullList() ? AccountGroups.First().Page : 1;
                jsonData.rows = AccountGroups;

                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                JqGridResponse<IAccountGroup> jsonData = new JqGridResponse<IAccountGroup>();
                jsonData.total = 1;
                jsonData.page = page;
                jsonData.records = 0;
                jsonData.rows = new List<IAccountGroup>();
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CreateAccountGroup()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (!CheckValidation.IsAllowedCreateAccountGroup())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }

        [HttpPost]
        public ActionResult AccountGroupDetail(AccountGroupRequest AccountGroup)
        {
            try
            {
                IAccountGroup AccountGroupRequest = Factory<IAccountGroup>.Create("AccountGroup");
                AccountGroupRequest.Id = AccountGroup.Id;

                IRepository<IAccountGroup> dal = FactoryDalLayer<IRepository<IAccountGroup>>.Create("AccountGroup");

                IAccountGroup AccountGroups = dal.GetDetail(AccountGroupRequest);

                return Json(AccountGroups, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult CreateAccountGroup(AccountGroupRequest accountGroup)
        {
            try
            {
                IAccountGroup AccountGroupRequest = Factory<IAccountGroup>.Create("AccountGroup");
                AccountGroupRequest.Id = accountGroup.Id;
                AccountGroupRequest.GroupName = accountGroup.GroupName;
                AccountGroupRequest.AliasName = accountGroup.AliasName;
                AccountGroupRequest.DefaultGroupId = accountGroup.DefaultGroupId;
                AccountGroupRequest.GroupType = accountGroup.GroupType;
                AccountGroupRequest.IsActive = accountGroup.IsActive;
                AccountGroupRequest.IsEditable = accountGroup.IsEditable;
                AccountGroupRequest.IsDelete = false;
                AccountGroupRequest.Validate();
                AccountGroupRequest.CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();

                IRepository<IAccountGroup> dal = FactoryDalLayer<IRepository<IAccountGroup>>.Create("AccountGroup");
                dal.SaveWithReturn(AccountGroupRequest);

                return Json("AccountGroup saved successfully.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }
    }
}