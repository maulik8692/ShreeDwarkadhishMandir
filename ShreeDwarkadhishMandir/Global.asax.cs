using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CommonLayer;
using ShreeDwarkadhishMandir.Models;

namespace ShreeDwarkadhishMandir
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //Exception ex = Server.GetLastError();
            
            //Log.Write(ex);

            int statusCode = 404;
            //if (ex is HttpException)
            //{
            //    statusCode = ((HttpException)ex).GetHttpCode();
            //}

            //if (ex.IsNotNull())
            //{
            //    string errorlineNo = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
            //    string errormsg = ex.GetType().Name.ToString();
            //    string extype = ex.GetType().ToString();
            //    string exurl = HttpContext.Current.Request.Url.ToString();

            //    Session["statusCode"] = statusCode;
            //    Session["errorlineNo"] = errorlineNo;
            //    Session["errormsg"] = errormsg;
            //    Session["extype"] = extype;
            //    Session["exurl"] = exurl; 
            //}

            //Server.ClearError();
            Response.Redirect("/Error/Error");
        }
    }
}