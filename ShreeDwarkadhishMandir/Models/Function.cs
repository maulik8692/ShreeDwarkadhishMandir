using CommonLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir
{
    public class Function
    {
        public static void SetLoginCookie(ApplicationUserBase applicationUserBase)
        {
            WriteCookie(CookiesKey.AuthenticatedId, applicationUserBase.Id.ToString());
            WriteCookie(CookiesKey.AuthenticatedDisplayName, applicationUserBase.DisplayName.ToString());
            WriteCookie(CookiesKey.AuthenticatedEmail, applicationUserBase.Email.ToString());
            WriteCookie(CookiesKey.AuthenticatedUserTypeId, applicationUserBase.UserTypeId.ToString());
            WriteCookie(CookiesKey.AuthenticatedMandirName, applicationUserBase.MandirName.ToString());
            WriteCookie(CookiesKey.AuthenticatedMandirId, applicationUserBase.MandirId.ToString());
        }

        public static void RemoveLoginCookie()
        {
            RemoveCookie(CookiesKey.AuthenticatedId);
            RemoveCookie(CookiesKey.AuthenticatedDisplayName);
            RemoveCookie(CookiesKey.AuthenticatedEmail);
            RemoveCookie(CookiesKey.AuthenticatedUserTypeId);
            RemoveCookie(CookiesKey.AuthenticatedMandirName);
            RemoveCookie(CookiesKey.AuthenticatedMandirId);
        }

        public static void WriteCookie(string keyname, string value)
        {
            RemoveCookie(keyname);
            //Create a Cookie with a suitable Key.
            HttpCookie httpCookie = new HttpCookie(keyname);

            //Set the Cookie value.
            httpCookie.Values[keyname] = value;

            //Set the Expiry date.
            httpCookie.Expires = DateTime.Now.AddDays(1);

            //Add the Cookie to Browser.
            HttpContext.Current.Response.Cookies.Add(httpCookie);
            
        }

        public static string ReadCookie(string keyname)
        {
            //Fetch the Cookie using its Key.
            HttpCookie httpCookie = HttpContext.Current.Request.Cookies[keyname];

            //If Cookie exists fetch its value.
            return httpCookie != null ? httpCookie.Value.Split('=')[1] : string.Empty;

        }

        public static void RemoveCookie(string keyname)
        {
            //Fetch the Cookie using its Key.
            HttpCookie httpCookie = HttpContext.Current.Request.Cookies[keyname];
            if (httpCookie.IsNotNull())
            {

                //Set the Expiry date to past date.
                httpCookie.Expires = DateTime.Now.AddDays(-1);

                //Update the Cookie in Browser.
                HttpContext.Current.Response.Cookies.Add(httpCookie); 
            }
        }
    }
}