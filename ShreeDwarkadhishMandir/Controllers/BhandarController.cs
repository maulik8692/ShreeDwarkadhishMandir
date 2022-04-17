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
using static EnumLayer.BhandarTransactionCodeEnum;

namespace ShreeDwarkadhishMandir.Controllers
{
    [AuthorizationFilter.UserAuthorization]
    public class BhandarController : Controller
    {
        // GET: Bhandar
        public ActionResult Bhandar()
        {
            if (!CheckValidation.IsAllowedBhandar())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
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
                jsonData.total = Bhandars.IsNotNullList() ? Bhandars.First().Page : 1;
                jsonData.page = page;
                jsonData.records = Bhandars.IsNotNullList() ? Bhandars.First().Total : 1;
                jsonData.rows = Bhandars;

                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                JqGridResponse<IBhandar> jsonData = new JqGridResponse<IBhandar>();
                //jsonData.total = 1;
                //jsonData.page = page;
                //jsonData.records = 0;
                //jsonData.rows = new List<IBhandar>();
                return Json(jsonData, JsonRequestBehavior.AllowGet);
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

        public ActionResult CreateBhandar()
        {
            if (!CheckValidation.IsAllowedCreateBhandar())
            {
                return RedirectToAction("AccessDenied", "Error");
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
                BhandarRequest.UnitId = Bhandar.UnitId;
                BhandarRequest.BhandarCategoryId = Bhandar.BhandarCategoryId;
                BhandarRequest.Name = Bhandar.Name;
                BhandarRequest.Description = Bhandar.Description;
                BhandarRequest.IsActive = Bhandar.IsActive;
                BhandarRequest.Validate();
                BhandarRequest.CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();

                IBhandar BhandarResponse = Factory<IBhandar>.Create("Bhandar");
                IRepository<IBhandar> dal = FactoryDalLayer<IRepository<IBhandar>>.Create("Bhandar");
                BhandarResponse = dal.SaveWithReturn(BhandarRequest);

                if (Bhandar.AllowToChangeBalance && Bhandar.Balance > 0)
                {
                    IBhandarTransaction bhandarTransaction = Factory<IBhandarTransaction>.Create("BhandarTransaction");
                    bhandarTransaction.BhandarId = BhandarResponse.Id;
                    bhandarTransaction.UnitId = Bhandar.UnitId;
                    bhandarTransaction.StoreId = Bhandar.StoreId;
                    bhandarTransaction.BhandarTransactionCodeId = (int)BhandarTransactionCode.Opening;
                    bhandarTransaction.StockTransactionQuantity = Bhandar.Balance;
                    bhandarTransaction.Description = "Opening Balance for " + Bhandar.Name;
                    bhandarTransaction.CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();
                    bhandarTransaction.TransactionId = Guid.NewGuid();

                    IBhandarTransaction BhandarTransactionResponse = Factory<IBhandarTransaction>.Create("BhandarTransaction");
                    IRepository<IBhandarTransaction> dalBhandarTransaction = FactoryDalLayer<IRepository<IBhandarTransaction>>.Create("BhandarTransaction");
                    BhandarTransactionResponse = dalBhandarTransaction.SaveWithReturn(bhandarTransaction);
                }

                return Json("Bhandar saved successfully.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        public ActionResult GetBhandarForDropdown(int StoreId = 0)
        {
            try
            {
                IBhandar BhandarRequest = Factory<IBhandar>.Create("Bhandar");

                IRepository<IBhandar> dal = FactoryDalLayer<IRepository<IBhandar>>.Create("Bhandar");
                BhandarRequest.StoreId = StoreId;
                List<IBhandar> Bhandars = dal.DropdownWithSearch(BhandarRequest);

                return Json(Bhandars, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }
    }
}