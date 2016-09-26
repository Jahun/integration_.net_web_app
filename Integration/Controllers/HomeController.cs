using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Integration.Models;
using Integration.Tools;


namespace Integration.Controllers
{
    public class HomeController : Controller
    {
        PersonServiceClient psc = new PersonServiceClient();

        public ActionResult Index()
        {
            new Common().controlLogin(true);
            return View();
        }


        public ActionResult GetDetails(string id)
        {
            new Common().controlLogin(true);
            return Json(psc.getDetails(id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCountries()
        {
            new Common().controlLogin(true);
            return Json(psc.getCountries(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCities(string id)
        {
            new Common().controlLogin(true);
            return Json(psc.getCities(id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRegions(string id)
        {
            new Common().controlLogin(true);
            return Json(psc.getRegions(id), JsonRequestBehavior.AllowGet);
        }

    }
}
