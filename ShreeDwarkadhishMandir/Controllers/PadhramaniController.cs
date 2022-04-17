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
    [AuthorizationFilter.UserAuthorization]
    public class PadhramaniController : Controller
    {
        // GET: Padhramani
        public ActionResult Padhramani()
        {
            if (!CheckValidation.IsAllowedPadhramani())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }

        [HttpPost]
        public ActionResult GetPadhramaniRequestById(PadhramaniJsonRequest padhramaniRequest)
        {
            IPadhramaniRequest padhramani = Factory<IPadhramaniRequest>.Create("PadhramaniRequest");

            try
            {
                padhramani.RequestNumber = padhramaniRequest.RequestNumber;

                IRepository<IPadhramaniRequest> vaishnavsDal = FactoryDalLayer<IRepository<IPadhramaniRequest>>.Create("PadhramaniRequest");
                padhramani = vaishnavsDal.GetDetail(padhramani);

                return Json(padhramani, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                padhramani.Id = 0;
            }

            return View(padhramani);
        }

        [HttpPost]
        public ActionResult GetPadhramaniRequestList(PadhramaniJsonRequest padhramaniRequest)
        {
            IPadhramaniRequest padhramani = Factory<IPadhramaniRequest>.Create("PadhramaniRequest");

            try
            {
                padhramani.VallabhId = padhramaniRequest.VallabhId;
                padhramani.CountryId = padhramaniRequest.CountryId;
                padhramani.StateId = padhramaniRequest.StateId;
                padhramani.CityId = padhramaniRequest.CityId;
                padhramani.VillageId = padhramaniRequest.VillageId;
                padhramani.RequestNumber = padhramaniRequest.RequestNumber;
                padhramani.PadhramaniDate = padhramaniRequest.PadhramaniDate;
                padhramani.RequestStatus = padhramaniRequest.RequestStatus;
                padhramani.PadhramaniDate = padhramaniRequest.PadhramaniDate;
                padhramani.IsCompled = padhramaniRequest.IsCompled;

                IRepository<IPadhramaniRequest> vaishnavsDal = FactoryDalLayer<IRepository<IPadhramaniRequest>>.Create("PadhramaniRequest");
                List<IPadhramaniRequest> padhramanis = vaishnavsDal.Search(padhramani);

                for (int i = 0; i < 1000; i++)
                {
                    padhramani.VaishnavId = "VaishnavId" + i.ToString();
                    padhramanis.Add(padhramani);
                }

                DatatableResponse datatableResponse = new DatatableResponse();
                datatableResponse.draw = 1;
                datatableResponse.recordsTotal = 10;
                datatableResponse.recordsFiltered = 100;
                datatableResponse.data = padhramanis;
                return Json(padhramanis, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                padhramani.Id = 0;
            }

            return View(padhramani);
        }

        [HttpPost]
        public ActionResult SavePadhramaniRequest(PadhramaniJsonRequest padhramaniRequest)
        {
            try
            {
                IPadhramaniRequest padhramani = Factory<IPadhramaniRequest>.Create("PadhramaniRequest");
                padhramani.Id = padhramaniRequest.Id;
                padhramani.VallabhId = padhramaniRequest.VallabhId;

                IRepository<IAppConfiguration> appConfigurationDal = FactoryDalLayer<IRepository<IAppConfiguration>>.Create("AppConfiguration");
                List<IAppConfiguration> appConfigurations = appConfigurationDal.Search(AppConfigurationKeys.URLEncryptionKey);

                if (padhramaniRequest.VaishnavUserId.IsNotNullString())
                {
                    padhramani.VaishnavUserId = padhramaniRequest.VaishnavUserId.DecryptString(appConfigurations.FirstOrDefault().KeyValue, 128).ToInt();
                }

                padhramani.Id = padhramaniRequest.Id;
                padhramani.Address = padhramaniRequest.Address;
                padhramani.CityId = padhramaniRequest.CityId;
                padhramani.CountryId = padhramaniRequest.CountryId;
                padhramani.StateId = padhramaniRequest.StateId;
                padhramani.VillageId = padhramaniRequest.VillageId;
                padhramani.PostalCode = padhramaniRequest.PostalCode;
                padhramani.RequestStatus = padhramaniRequest.RequestStatus;
                padhramani.PadhramaniDate = padhramaniRequest.PadhramaniDate;

                padhramani.CreatedUserId = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();

                padhramani.RequestedVaishnavId = padhramani.CreatedUserId == 0 ? padhramani.VaishnavUserId : 0;

                padhramani.CompletionDate = padhramaniRequest.CompletionDate;
                padhramani.IsCompled = padhramaniRequest.IsCompled;

                padhramani.Validate();

                IRepository<IPadhramaniRequest> vaishnavsDal = FactoryDalLayer<IRepository<IPadhramaniRequest>>.Create("PadhramaniRequest");
                vaishnavsDal.Save(padhramani);

                return Json(string.Empty, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        public JsonResult GetPadhramaniRequestList(string sidx, string sord, int page, int rows) //Gets the todo Lists.
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            IPadhramaniRequest padhramani = Factory<IPadhramaniRequest>.Create("PadhramaniRequest");

            IRepository<IPadhramaniRequest> vaishnavsDal = FactoryDalLayer<IRepository<IPadhramaniRequest>>.Create("PadhramaniRequest");
            List<IPadhramaniRequest> padhramanis = vaishnavsDal.Search(padhramani);

            var jsonData = new
            {
                total = 10,
                page,
                records = 1000,
                rows = padhramanis
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PadhramaniRequest()
        {
            if (!CheckValidation.IsAllowedPadhramaniRequest())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }
    }
}