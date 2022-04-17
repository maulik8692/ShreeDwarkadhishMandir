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
    [AuthorizationFilter.UserAuthorization]
    public class MandirController : Controller
    {
        // GET: Mandir
        public ActionResult Mandir()
        {
            if (!CheckValidation.IsAllowedMandir())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }

        public ActionResult MandirList()
        {
            if (!CheckValidation.IsAllowedMandirList())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Mandir(MandirRequest mandirRequest)
        {
            try
            {
                IMandir mandir = Factory<IMandir>.Create("Mandir");
                mandir.Id = mandirRequest.Id;
                mandir.Name = mandirRequest.Name;
                mandir.Address = mandirRequest.Address;
                mandir.CountryId = mandirRequest.CountryId;
                mandir.StateId = mandirRequest.StateId;
                mandir.CityId = mandirRequest.CityId;
                mandir.VillageId = mandirRequest.VillageId;
                mandir.PostalCode = mandirRequest.PostalCode;
                mandir.PhoneNumber = mandirRequest.PhoneNumber;
                mandir.Email = mandirRequest.Email;
                mandir.ImageUrl = mandirRequest.ImageUrl;
                mandir.GurudevName = mandirRequest.GurudevName;
                mandir.RegistrationNumber = mandirRequest.RegistrationNumber;
                mandir.CreatedBy = mandirRequest.CreatedBy;
                mandir.CreatedOn = mandirRequest.CreatedOn;
                mandir.Validate();
                mandir.CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();
                IRepository<IMandir> dal = FactoryDalLayer<IRepository<IMandir>>.Create("Mandir");
                dal.Save(mandir);

                string output = "Welcome to the Admin User";

                return Json(output, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult MandirDetail(MandirRequest mandirRequest)
        {
            try
            {
                IMandir mandirDetail = Factory<IMandir>.Create("Mandir");
                mandirDetail.Id = mandirRequest.Id;
                
                IRepository<IMandir> dal = FactoryDalLayer<IRepository<IMandir>>.Create("Mandir");
                IMandir mandir = dal.GetDetail(mandirDetail);

                return Json(mandir, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult MandirList(MandirRequest mandirRequest)
        {
            IMandir mandir = Factory<IMandir>.Create("Mandir");
            mandir.Id = mandirRequest.Id;
            mandir.Name = mandirRequest.Name;
            mandir.Address = mandirRequest.Address;
            mandir.CountryId = mandirRequest.CountryId;
            mandir.StateId = mandirRequest.StateId;
            mandir.CityId = mandirRequest.CityId;
            mandir.VillageId = mandirRequest.VillageId;
            mandir.PostalCode = mandirRequest.PostalCode;
            mandir.PhoneNumber = mandirRequest.PhoneNumber;
            mandir.Email = mandirRequest.Email;
            mandir.CreatedBy = mandirRequest.CreatedBy;
            mandir.CreatedOn = mandirRequest.CreatedOn;

            IRepository<IMandir> dal = FactoryDalLayer<IRepository<IMandir>>.Create("Mandir");
            List<IMandir> mandirs = dal.Search(mandir);

            return Json(mandirs, JsonRequestBehavior.AllowGet);
        }
    }
}