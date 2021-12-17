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
    public class VaishnavController : Controller
    {
        // GET: Vaishnav
        public ActionResult Vaishnav(string id = "")
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (!CheckValidation.IsAllowedVaishnav())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }

        [HttpPost]
        public ActionResult GetVaishnavById(VaishnavRequest vaishnavRequest)
        {
            IVaishnav vaishnav = Factory<IVaishnav>.Create("Vaishnav");

            try
            {
                IRepository<IAppConfiguration> appConfigurationDal = FactoryDalLayer<IRepository<IAppConfiguration>>.Create("AppConfiguration");
                List<IAppConfiguration> appConfigurations = appConfigurationDal.Search(AppConfigurationKeys.URLEncryptionKey);

                if (vaishnavRequest.EncryptedId.IsNotNullString())
                {
                    vaishnav.Id = vaishnavRequest.EncryptedId.DecryptString(appConfigurations.FirstOrDefault().KeyValue, 128).ToInt();
                }

                vaishnav.VaishnavId = vaishnavRequest.VaishnavId;

                IRepository<IVaishnav> vaishnavsDal = FactoryDalLayer<IRepository<IVaishnav>>.Create("Vaishnav");
                vaishnav = vaishnavsDal.GetDetail(vaishnav);

                vaishnav.EncryptedId = vaishnav.Id.ToString().EncryptString(appConfigurations.FirstOrDefault().KeyValue, 128);

                return Json(vaishnav, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                vaishnav.Id = 0;
            }

            return View(vaishnav);
        }

        [HttpPost]
        public ActionResult Vaishnav(VaishnavRequest vaishnavRequest)
        {
            try
            {
                IVaishnav vaishnavs = Factory<IVaishnav>.Create("Vaishnav");
                vaishnavs.Address = vaishnavRequest.Address;
                vaishnavs.AddtionalNote = vaishnavRequest.AddtionalNote;
                vaishnavs.BloodGroup = vaishnavRequest.BloodGroup;
                vaishnavs.CityId = vaishnavRequest.CityId;
                vaishnavs.CountryId = vaishnavRequest.CountryId;
                vaishnavs.DateOfBirth = vaishnavRequest.DateOfBirth;
                vaishnavs.Email = vaishnavRequest.Email;
                vaishnavs.FirstName = vaishnavRequest.FirstName;
                vaishnavs.Gender = vaishnavRequest.Gender;
                if (vaishnavRequest.EncryptedId.IsNotNullString())
                {
                    IRepository<IAppConfiguration> appConfigurationDal = FactoryDalLayer<IRepository<IAppConfiguration>>.Create("AppConfiguration");
                    List<IAppConfiguration> appConfigurations = appConfigurationDal.Search(AppConfigurationKeys.URLEncryptionKey);
                    vaishnavs.Id = vaishnavRequest.EncryptedId.DecryptString(appConfigurations.FirstOrDefault().KeyValue, 128).ToInt();
                }

                vaishnavs.LastName = vaishnavRequest.LastName;
                vaishnavs.MaritalStatus = vaishnavRequest.MaritalStatus;
                vaishnavs.MiddleName = vaishnavRequest.MiddleName;
                vaishnavs.MobileNo = vaishnavRequest.MobileNo;
                vaishnavs.Nickname = vaishnavRequest.Nickname;
                vaishnavs.Occupation = vaishnavRequest.Occupation;
                vaishnavs.OccupationAddress = vaishnavRequest.OccupationAddress;
                vaishnavs.OccupationCityId = vaishnavRequest.OccupationCityId;
                vaishnavs.OccupationCountryId = vaishnavRequest.OccupationCountryId;
                vaishnavs.OccupationDetail = vaishnavRequest.OccupationDetail;
                vaishnavs.OccupationStateId = vaishnavRequest.OccupationStateId;
                vaishnavs.OccupationVillageId = vaishnavRequest.OccupationVillageId;
                vaishnavs.OccupationPostalCode = vaishnavRequest.OccupationPostalCode;
                vaishnavs.OfficePhone = vaishnavRequest.OfficePhone;
                vaishnavs.ResidencePhone = vaishnavRequest.ResidencePhone;
                vaishnavs.StateId = vaishnavRequest.StateId;
                vaishnavs.VillageId = vaishnavRequest.VillageId;
                vaishnavs.PostalCode = vaishnavRequest.PostalCode;
                vaishnavs.IsActive = vaishnavRequest.IsActive;
                vaishnavs.Validate();

                vaishnavs.CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();

                IRepository<IVaishnav> vaishnavsDal = FactoryDalLayer<IRepository<IVaishnav>>.Create("Vaishnav");
                vaishnavsDal.Save(vaishnavs);

                return Json(string.Empty, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        public ActionResult VaishnavJan()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }
            else if (!CheckValidation.IsAllowedVaishnavJan())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }

        //[HttpPost]
        //public ActionResult VaishnavJan(VaishnavRequest vaishnavRequest)
        //{
        //    try
        //    {
        //        IVaishnav vaishnav = Factory<IVaishnav>.Create("Vaishnav");
        //        vaishnav.Id = vaishnavRequest.Id;
        //        vaishnav.MobileNo = vaishnavRequest.MobileNo;
        //        IRepository<IVaishnav> vaishnavsDal = FactoryDalLayer<IRepository<IVaishnav>>.Create("Vaishnav");
        //        List<IVaishnav> vaishnavs = vaishnavsDal.Search(vaishnav);

        //        IRepository<IAppConfiguration> appConfigurationDal = FactoryDalLayer<IRepository<IAppConfiguration>>.Create("AppConfiguration");
        //        List<IAppConfiguration> appConfigurations = appConfigurationDal.Search(AppConfigurationKeys.URLEncryptionKey);

        //        foreach (var item in vaishnavs)
        //        {
        //            item.EncryptedId = item.Id.ToString().EncryptString(appConfigurations.FirstOrDefault().KeyValue, 128);

        //        }

        //        return Json(vaishnavs, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new HttpStatusCodeResult(410, ex.Message);
        //    }
        //}

        public JsonResult VaishnavList(string sidx, string sord, int page, int rows, string vaishnavId)
        {
            try
            {
                IVaishnav SupplierRequest = Factory<IVaishnav>.Create("Vaishnav");
                SupplierRequest.PageNumber = page;
                SupplierRequest.PageSize = rows;
                SupplierRequest.VaishnavId = vaishnavId;

                IRepository<IVaishnav> dal = FactoryDalLayer<IRepository<IVaishnav>>.Create("Vaishnav");

                List<IVaishnav> vaishnavs = dal.Search(SupplierRequest);

                IRepository<IAppConfiguration> appConfigurationDal = FactoryDalLayer<IRepository<IAppConfiguration>>.Create("AppConfiguration");
                List<IAppConfiguration> appConfigurations = appConfigurationDal.Search(AppConfigurationKeys.URLEncryptionKey);

                foreach (var item in vaishnavs)
                {
                    item.EncryptedId = item.Id.ToString().EncryptString(appConfigurations.FirstOrDefault().KeyValue, 128);
                }

                JqGridResponse<IVaishnav> jsonData = new JqGridResponse<IVaishnav>();
                jsonData.total = vaishnavs.IsNotNullList() ? vaishnavs.First().Page : 1;
                jsonData.page = page;
                jsonData.records = vaishnavs.IsNotNullList() ? vaishnavs.First().Total : 1;
                jsonData.rows = vaishnavs;

                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                List<IVaishnav> suppliers = new List<IVaishnav>();
                JqGridResponse<IVaishnav> jsonData = new JqGridResponse<IVaishnav>();
                jsonData.total = 1;
                jsonData.page = page;
                jsonData.records = 1;
                jsonData.rows = suppliers;

                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult CheckEmailMobile(VaishnavRequest vaishnavRequest)
        {
            try
            {
                IVaishnav vaishnav = Factory<IVaishnav>.Create("Vaishnav");
                vaishnav.Id = vaishnavRequest.Id;
                vaishnav.MobileNo = vaishnavRequest.MobileNo;
                vaishnav.Email = vaishnavRequest.Email;
                IRepository<IVaishnav> vaishnavsDal = FactoryDalLayer<IRepository<IVaishnav>>.Create("Vaishnav");
                bool isValid = vaishnavsDal.CheckData(vaishnav);

                return Json(isValid, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }
    }
}