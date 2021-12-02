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
    public class ApplicationUserController : Controller
    {
        // GET: ApplicationUser
        public ActionResult ApplicationUser()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        public ActionResult ApplicationUserList()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult ApplicationUserDetail(ApplicationUserRequest applicationUserRequest)
        {
            try
            {
                ApplicationUserBase applicationUser = Factory<ApplicationUserBase>.Create("Vallabhkul");
                applicationUser.Id = applicationUserRequest.Id;

                IRepository<ApplicationUserBase> dal = FactoryDalLayer<IRepository<ApplicationUserBase>>.Create("ApplicationUser");

                ApplicationUserBase applicationUserBase = dal.GetDetail(applicationUser);

                return Json(applicationUserBase, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult ApplicationUser(ApplicationUserRequest applicationUserRequest)
        {
            try
            {
                if (!applicationUserRequest.UserTypeId.IsNotZero())
                {
                    throw new Exception("User Type is require.");
                }

                ApplicationUserBase applicationUserBase = Factory<ApplicationUserBase>.Create(applicationUserRequest.UserTypeName);
                applicationUserBase.Id = applicationUserRequest.Id;
                applicationUserBase.MandirId = applicationUserRequest.MandirId;
                applicationUserBase.UserName = applicationUserRequest.UserName;
                applicationUserBase.DisplayName = applicationUserRequest.DisplayName;
                applicationUserBase.PhoneNumber = applicationUserRequest.PhoneNumber;
                applicationUserBase.Email = applicationUserRequest.Email;
                applicationUserBase.Address = applicationUserRequest.Address;
                applicationUserBase.Password = applicationUserRequest.Password;
                applicationUserBase.Validate();

                applicationUserBase.CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();

                IRepository<IAppConfiguration> appConfigurationDal = FactoryDalLayer<IRepository<IAppConfiguration>>.Create("AppConfiguration");
                List<IAppConfiguration> appConfigurations = appConfigurationDal.Search(AppConfigurationKeys.EncryptionKey);
                applicationUserBase.Password = applicationUserBase.Password.EncryptString(appConfigurations.FirstOrDefault().KeyValue, 128);

                IRepository<ApplicationUserBase> applicationUserdal = FactoryDalLayer<IRepository<ApplicationUserBase>>.Create("ApplicationUser");
                applicationUserdal.Save(applicationUserBase);

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
        public ActionResult ApplicationUserList(ApplicationUserRequest applicationUserRequest)
        {
            IRepository<ApplicationUserBase> dal = FactoryDalLayer<IRepository<ApplicationUserBase>>.Create("ApplicationUser");
            List<ApplicationUserBase> applicationUsers = dal.Search(applicationUserRequest);

            return Json(applicationUsers, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CheckUsername(string username)
        {
            IRepository<IApplicationUser> dal = FactoryDalLayer<IRepository<IApplicationUser>>.Create("ApplicationUser");
            List<IApplicationUser> applicationUsers = dal.Search(username);

            return Json(applicationUsers, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ApplicationUserDropdown()
        {
            IRepository<ApplicationUserBase> dal = FactoryDalLayer<IRepository<ApplicationUserBase>>.Create("ApplicationUser");
            List<ApplicationUserBase> applicationUsers = dal.DropdownWithSearch(0);

            return Json(applicationUsers, JsonRequestBehavior.AllowGet);
        }
    }
}