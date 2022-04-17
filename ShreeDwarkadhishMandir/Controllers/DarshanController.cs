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
    public class DarshanController : Controller
    {
        // GET: Darshan
        public ActionResult DarshanTime()
        {
            if (!CheckValidation.IsAllowedDarshanTime())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }

        [HttpPost]
        public ActionResult GetDarshanTime(string darshanDate)
        {
            IRepository<IDarshan> dal = FactoryDalLayer<IRepository<IDarshan>>.Create("Darshan");
            DateTime? dateTime = null;

            if (darshanDate.IsNotNullString())
            {
                dateTime = Convert.ToDateTime(darshanDate);
            }

            List<IDarshan> darshan = dal.Search(dateTime);

            return Json(darshan, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateDarshan()
        {
            if (!CheckValidation.IsAllowedDarshanTime())
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            return View();
        }

        [HttpPost]
        public ActionResult CreateDarshan(List<DarshanRequest> darshans)
        {
            try
            {
                if (darshans.Count > 0 && darshans.FirstOrDefault().FromDarshanDate.IsNotNull())
                {
                    int differenceOfDays = (darshans.FirstOrDefault().ToDarshanDate.Value - darshans.FirstOrDefault().FromDarshanDate.Value).TotalDays.ToInt();

                    for (int i = 0; i < (differenceOfDays + 1); i++)
                    {
                        foreach (var item in darshans)
                        {
                            if (item.FromTime.IsNotNull() && item.ToTime.IsNotNull())
                            {
                                IDarshan darshan = Factory<IDarshan>.Create("Darshan");
                                
                                darshan.AdditionalNote = item.AdditionalNote;
                                darshan.DarshanId = item.DarshanId;
                                darshan.FromDarshanDate = item.FromDarshanDate.Value.AddDays(i);
                                darshan.ToTime = item.FromDarshanDate.Value.Add(item.ToTime.Value.TimeOfDay);
                                darshan.FromTime = item.FromDarshanDate.Value.Add(item.FromTime.Value.TimeOfDay);
                                darshan.ToDarshanDate = item.ToDarshanDate;
                                darshan.Validate();
                                IRepository<IDarshan> dal = FactoryDalLayer<IRepository<IDarshan>>.Create("Darshan");
                                dal.Save(darshan);
                            }
                            else if ((item.FromTime.IsDate() && !item.ToTime.IsDate()) || (!item.FromTime.IsDate() && item.ToTime.IsDate()))
                            {
                                throw new Exception("Darshan from time and to time both require.");
                            }
                        }
                    }
                }

                return View();
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                throw;
            }
        }
    }
}