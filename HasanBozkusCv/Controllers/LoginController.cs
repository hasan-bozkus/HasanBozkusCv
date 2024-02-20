using HasanBozkusCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HasanBozkusCv.Controllers
{

    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(Admin admin)
        {

            DBCvEntities db = new DBCvEntities();
            var bilgi = db.Admin.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.UserName, false);
                Session["UserName"] = bilgi.UserName.ToString();
                return RedirectToAction("Index", "Deneyim");
            }
            return RedirectToAction("Index", "Login");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}