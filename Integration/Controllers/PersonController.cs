using System.Web.Mvc;
using Integration.Models;
using PagedList;
using Integration.Tools;

namespace Integration.Controllers
{
    public class PersonController : Controller
    {

        PersonServiceClient psc = new PersonServiceClient();
        //
        // GET: /Person/

       

        public ActionResult GetPersons(string country, string city, string region, string order_by , string order_type,int view_count = 2, int page = 1)
        {
            new Common().controlLogin(true);
            var Listpersons = psc.getPersons(country, city, region, order_by, order_type);
            ViewBag.view_count = view_count;
            ViewBag.order_by = order_by;
            ViewBag.order_type = order_type;

            return View(Listpersons.ToPagedList(page, view_count));
        }

     

       

    }
}
