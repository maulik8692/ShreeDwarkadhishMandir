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
using static EnumLayer.ProcedureEnum;

namespace ShreeDwarkadhishMandir.Controllers
{
    [AuthorizationFilter.UserAuthorization]
    public class AccountHeadController : Controller
    {
        // GET: AccountHead
        public ActionResult CreateAccountHead()
        {
            if (!CheckValidation.IsAllowedCreateAccountHead())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }

        public ActionResult AccountHead()
        {
            if (!CheckValidation.IsAllowedAccountHead())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }

        [HttpPost]
        public ActionResult AccountHeadDetail(AccountHeadRequest accountHeadRequest)
        {
            IAccountHead accountHeadDetail = Factory<IAccountHead>.Create("AccountHead");
            accountHeadDetail.Id = accountHeadRequest.Id;

            IRepository<IAccountHead> dal = FactoryDalLayer<IRepository<IAccountHead>>.Create("AccountHead");

            IAccountHead accountHead = dal.GetDetail(accountHeadDetail);

            return Json(accountHead, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AccountHeadDropdown(AccountDropdownRequest accountDropdownRequest)
        {
            IAccountHead accountHeadDropdownRequest = Factory<IAccountHead>.Create("AccountHead");
            accountHeadDropdownRequest.Id = accountDropdownRequest.AccountId;
            accountHeadDropdownRequest.NatureOfGroup = accountDropdownRequest.NatureOfGroup;
            accountHeadDropdownRequest.GroupName = accountDropdownRequest.GroupName;

            IRepository<IAccountHead> dal = FactoryDalLayer<IRepository<IAccountHead>>.Create("AccountHead");
            List<IAccountHead> AccountHead = dal.DropdownWithSearch(accountHeadDropdownRequest);

            return Json(AccountHead, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AccountHead(AccountHeadRequest accountHeadRequest)
        {
            try
            {
                IAccountHead saveAccountHead = Factory<IAccountHead>.Create("AccountHead");
                saveAccountHead.Id = accountHeadRequest.Id;
                saveAccountHead.MandirId = accountHeadRequest.MandirId;
                saveAccountHead.GroupId = accountHeadRequest.GroupId;
                saveAccountHead.AccountName = accountHeadRequest.AccountName;
                saveAccountHead.Alias = accountHeadRequest.Alias;
                saveAccountHead.BalanceAmount = accountHeadRequest.BalanceAmount;
                saveAccountHead.DebitCredit = accountHeadRequest.DebitCredit;
                saveAccountHead.AccountHolderName = accountHeadRequest.AccountHolderName;
                saveAccountHead.BankName = accountHeadRequest.BankName;
                saveAccountHead.BankAddress = accountHeadRequest.BankAddress;
                saveAccountHead.AccountNumber = accountHeadRequest.AccountNumber;
                saveAccountHead.IFSCCode = accountHeadRequest.IFSCCode;
                saveAccountHead.BankBranch = accountHeadRequest.BankBranch;
                saveAccountHead.DateOfIssue = accountHeadRequest.DateOfIssue;
                saveAccountHead.DateOfMaturity = accountHeadRequest.DateOfMaturity;
                saveAccountHead.InterestRate = accountHeadRequest.InterestRate;
                saveAccountHead.MaturityAmount = accountHeadRequest.MaturityAmount;
                saveAccountHead.IsEditable = accountHeadRequest.IsEditable;
                saveAccountHead.IsActive = accountHeadRequest.IsActive;
                saveAccountHead.AnnexureName = accountHeadRequest.AnnexureName;
                saveAccountHead.AnnexureOrder = accountHeadRequest.AnnexureOrder;

                saveAccountHead.Validate();
                saveAccountHead.CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();

                IRepository<IAccountHead> applicationUserdal = FactoryDalLayer<IRepository<IAccountHead>>.Create("AccountHead");
                applicationUserdal.Save(saveAccountHead);

                string output = "Account head save successfully.";

                return Json(output, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        public JsonResult AccountHeadList(string sidx, string sord, int page, int rows)
        {
            try
            {
                IAccountHead SupplierRequest = Factory<IAccountHead>.Create("AccountHead");
                SupplierRequest.PageNumber = page;
                SupplierRequest.PageSize = rows;

                IRepository<IAccountHead> dal = FactoryDalLayer<IRepository<IAccountHead>>.Create("AccountHead");

                List<IAccountHead> suppliers = dal.Search(SupplierRequest);

                JqGridResponse<IAccountHead> jsonData = new JqGridResponse<IAccountHead>();
                jsonData.total = suppliers.IsNotNullList() ? suppliers.First().Page : 1;
                jsonData.page = page;
                jsonData.records = suppliers.IsNotNullList() ? suppliers.First().Total : 1;

                jsonData.rows = suppliers;

                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                JqGridResponse<IAccountHead> jsonData = new JqGridResponse<IAccountHead>();
                jsonData.total = 1;
                jsonData.page = page;
                jsonData.records = 0;
                jsonData.rows = new List<IAccountHead>();
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetCashBankAccount()
        {
            IRepositoryDropdown<ISearchableDropdown> dal = FactoryDalLayer<IRepositoryDropdown<ISearchableDropdown>>.Create("Searchable");
            List<ISearchableDropdown> results = dal.DropdownWithSearch(ProcedureName.GetCashBankAccount.ToString());

            return Json(results, JsonRequestBehavior.AllowGet);
        }
    }
}