using CommonLayer;
using FactoryDal;
using FactoryMiddleLayer;
using InterfaceDal;
using InterfaceMiddleLayer;
using ShreeDwarkadhishMandir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ShreeDwarkadhishMandir.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            Function.RemoveLoginCookie();
            return View();
        }

        [HttpPost]
        public ActionResult DoLogin(LoginRequest loginRequest)
        {
            try
            {
                ApplicationUserBase applicationUser = Factory<ApplicationUserBase>.Create("AuthenticationUser");
                applicationUser.UserName = loginRequest.UserName;
                applicationUser.Password = loginRequest.Password;
                applicationUser.Validate();

                IRepository<IAppConfiguration> appConfigurationDal = FactoryDalLayer<IRepository<IAppConfiguration>>.Create("AppConfiguration");
                List<IAppConfiguration> appConfigurations = appConfigurationDal.Search(AppConfigurationKeys.EncryptionKey);
                applicationUser.Password = applicationUser.Password.EncryptString(appConfigurations.FirstOrDefault().KeyValue, 128);

                IRepository<ApplicationUserBase> applicationUserdal = FactoryDalLayer<IRepository<ApplicationUserBase>>.Create("AuthenticationUser");
                List<ApplicationUserBase> authenticatedUser= applicationUserdal.Search(applicationUser);

                if (authenticatedUser.FirstOrDefault()==null || authenticatedUser.FirstOrDefault().Id==0)
                {
                    throw new Exception("The username or password you entered is incorrect.");
                }

                Function.SetLoginCookie(authenticatedUser.FirstOrDefault());
                return Json(authenticatedUser, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }
    }
}