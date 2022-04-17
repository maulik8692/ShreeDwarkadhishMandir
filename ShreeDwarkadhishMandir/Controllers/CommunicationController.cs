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
    public class CommunicationController : Controller
    {
        // GET: Communication
        public ActionResult Communication()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Communication(CommunicationRequest communicationRequest)
        {
            try
            {
                ICommunication emailConfiguration = Factory<ICommunication>.Create("Communication");
                emailConfiguration.EmailContent = communicationRequest.EmailContent;
                emailConfiguration.EmailSubject = communicationRequest.EmailSubject;
                emailConfiguration.Validate();
                emailConfiguration.CreatedBy = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();
                IRepository<ICommunication> dal = FactoryDalLayer<IRepository<ICommunication>>.Create("Communication");
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