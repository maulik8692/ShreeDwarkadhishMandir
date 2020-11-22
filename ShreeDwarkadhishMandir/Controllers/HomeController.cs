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
using System.Web;
using System.Web.Mvc;

namespace ShreeDwarkadhishMandir.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt() == 0)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult DashboardData()
        {
            try
            {
                IDashboard dashboard = Factory<IDashboard>.Create("Dashboard");

                dashboard.MandirId = Function.ReadCookie(CookiesKey.AuthenticatedMandirId).ToInt();

                IRepository<IDashboard> dashboarddal = FactoryDalLayer<IRepository<IDashboard>>.Create("Dashboard");
                dashboard= dashboarddal.GetDetail(dashboard);

                return Json(dashboard, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return new HttpStatusCodeResult(410, ex.Message);
            }
        }

    }
}