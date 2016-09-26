using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Integration.Models;
using Integration.Tools;
using Integration.Tools;

namespace Integration.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index(string form)
        {

            if (form == "registration") { return RedirectToAction("registration"); } else { return RedirectToAction("login"); }
        }

        public ActionResult Login()
        {
            new Common().controlLogin(false, true);
            return View();
        }


        public ActionResult Registration()
        {
            new Common().controlLogin(false, true);
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetLogin()
        {

            string email = Request["email"];
            string password = Request["password"];
            string message = "";
            if (email != null && password != null)
            {
                string hash_id = Common.createHashId(email, password);
                if (Account.exist(hash_id) != 0)
                {
                    new Common().setUserCookie(hash_id);
                }
                else
                {
                    message = "<i style='color:red '>Email or password is not valid!!!</i>";
                }

            }
            ViewBag.message = message;
            return View("login");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetRegistration()
        {

            string name = Common.filterString(Request["name"]);
            string email = Request["email"];
            string password = Request["password"];
            string message = "";
            if (name != null && email != null && password != null)
            {
                User user = new User();
                user.name = name;
                user.email = email;
                user.password = Common.md5(password);
                user.hash_id = Common.createHashId(email, password);
                string reg = Account.register(user);

                if (reg == "true")
                {
                    new Common().setUserCookie(user.hash_id);
                }
                else
                {
                    message = reg;
                }

            }
            ViewBag.message = message;

            return View("registration");
        }
        public ActionResult Logout()
        {

            new Common().setUserCookie(null, -1);
            return null;
        }
    }
}
