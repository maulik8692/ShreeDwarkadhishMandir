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
    public class ConfigurationController : Controller
    {
        public ActionResult GetCountryAll()
        {
            IRepository<ICountry> dal = FactoryDalLayer<IRepository<ICountry>>.Create("Country");
            List<ICountry> countries = dal.Search();

            return Json(countries, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetStatesByCountryId(int countryId)
        {
            IRepository<IState> dal = FactoryDalLayer<IRepository<IState>>.Create("State");
            List<IState> states = dal.Search(countryId);

            return Json(states, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCitiesByStateId(int stateId)
        {
            IRepository<ICity> dal = FactoryDalLayer<IRepository<ICity>>.Create("City");
            List<ICity> cities = dal.Search(stateId);

            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetVillagesByCityId(int cityId)
        {
            IRepository<IVillage> dal = FactoryDalLayer<IRepository<IVillage>>.Create("Village");
            List<IVillage> cities = dal.Search(cityId);

            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetOccupationAll()
        {
            IRepository<IOccupation> dal = FactoryDalLayer<IRepository<IOccupation>>.Create("Occupation");
            List<IOccupation> countries = dal.Search();

            return Json(countries, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUserType()
        {
            IRepository<IUserType> dal = FactoryDalLayer<IRepository<IUserType>>.Create("UserType");
            List<IUserType> userTypes = dal.Search();

            return Json(userTypes, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AccountHeadForBhet(AccountDropdownRequest accountDropdownRequest)
        {
            IAccountHeadDropdown accountHeadDropdownRequest = Factory<IAccountHeadDropdown>.Create("AccountHeadDropdown");

            IRepository<IAccountHeadDropdown> dal = FactoryDalLayer<IRepository<IAccountHeadDropdown>>.Create("AccountHeadDropdown");
            List<IAccountHeadDropdown> accountHeadDropdown = dal.DropdownWithSearch(accountHeadDropdownRequest);

            return Json(accountHeadDropdown, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AccountHeadForConfiguration()
        {
            IAccountHeadDropdown accountHeadDropdownRequest = Factory<IAccountHeadDropdown>.Create("AccountHeadDropdown");
            accountHeadDropdownRequest.MandirId = Function.ReadCookie(CookiesKey.AuthenticatedMandirId).ToInt();

            IRepository<IAccountHeadDropdown> dal = FactoryDalLayer<IRepository<IAccountHeadDropdown>>.Create("AccountHeadDropdown");
            List<IAccountHeadDropdown> accountHeadDropdown = dal.Search(accountHeadDropdownRequest);

            return Json(accountHeadDropdown, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ApplicationConfiguration()
        {
            return View();
        }

        public ActionResult Configuration()
        {
            if (!CheckValidation.IsAllowedConfiguration())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }

        [HttpPost]
        public ActionResult GetConfiguration()
        {
            IRepository<IAppConfiguration> appConfigurationDal = FactoryDalLayer<IRepository<IAppConfiguration>>.Create("AppConfiguration");
            List<IAppConfiguration> appConfigurations = appConfigurationDal.Search();

            List<string> notToIncludeInList = new List<string>();

            notToIncludeInList.Add(AppConfigurationKeys.EncryptionKey);
            notToIncludeInList.Add(AppConfigurationKeys.URLEncryptionKey);

            appConfigurations = appConfigurations.Where(p => !notToIncludeInList.Any(p2 => p2 == p.KeyName)).ToList();
            return Json(appConfigurations, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetConfigurationByName(string keyName)
        {
            IRepository<IAppConfiguration> appConfigurationDal = FactoryDalLayer<IRepository<IAppConfiguration>>.Create("AppConfiguration");
            List<IAppConfiguration> appConfigurations = appConfigurationDal.Search(keyName);

            List<string> notToIncludeInList = new List<string>();

            notToIncludeInList.Add(AppConfigurationKeys.EncryptionKey);
            notToIncludeInList.Add(AppConfigurationKeys.URLEncryptionKey);

            appConfigurations = appConfigurations.Where(p => !notToIncludeInList.Any(p2 => p2 == p.KeyName)).ToList();
            return Json(appConfigurations, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SetConfiguration(List<ConfigurationRequest> keyValues)
        {
            try
            {
                IRepository<IAppConfiguration> appConfigurationDal = FactoryDalLayer<IRepository<IAppConfiguration>>.Create("AppConfiguration");

                if (keyValues.IsNotNull() && keyValues.Count > 0)
                {
                    foreach (var item in keyValues)
                    {
                        IAppConfiguration appConfiguration = Factory<IAppConfiguration>.Create("AppConfiguration");
                        appConfiguration.Id = item.Id;
                        appConfiguration.KeyValue = item.KeyValue;
                        appConfigurationDal.Save(appConfiguration);
                    }
                }

                return Json("Successfully saved.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }
    }
}