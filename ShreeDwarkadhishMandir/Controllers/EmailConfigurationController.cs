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
    public class EmailConfigurationController : Controller
    {
        // GET: EmailConfiguration
        [HttpPost]
        public ActionResult EmailConfiguration()
        {
            IRepository<IEmailConfiguration> dal = FactoryDalLayer<IRepository<IEmailConfiguration>>.Create("EmailConfiguration");
            List<IEmailConfiguration> emailConfigurations = dal.Search();
            return Json(emailConfigurations.FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveEmailConfiguration(EmailConfigurationRequest emailRequest)
        {
            try
            {
                IEmailConfiguration emailConfiguration = Factory<IEmailConfiguration>.Create("EmailConfiguration");
                emailConfiguration.Server = emailRequest.Server;
                emailConfiguration.Port = emailRequest.Port;
                emailConfiguration.Username = emailRequest.Username;
                emailConfiguration.Password = emailRequest.Password;
                emailConfiguration.SSL = emailRequest.SSL;
                emailConfiguration.ExchangeService = emailRequest.ExchangeService;
                emailConfiguration.IsActive = emailRequest.IsActive;
                emailConfiguration.DisplayName = emailRequest.DisplayName;
                emailConfiguration.Validate();
                emailConfiguration.CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();

                IRepository<IEmailConfiguration> dal = FactoryDalLayer<IRepository<IEmailConfiguration>>.Create("EmailConfiguration");
                dal.Save(emailConfiguration);
                return Json("Save Sucessfully.", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }
    }
}