using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HasanBozkusCv.Models.Entity;

namespace HasanBozkusCv.Controllers
{
    public class DefaultController : Controller
    {
        DBCvEntities db = new DBCvEntities();

        // GET: Default
        public ActionResult Index()
        {
            var degerler = db.Abouts.ToList();
            return View(degerler);
        }

        public PartialViewResult Deneyim()
        {
            var deneyimler = db.Experience.ToList();
            return PartialView(deneyimler);
        }
    }
}