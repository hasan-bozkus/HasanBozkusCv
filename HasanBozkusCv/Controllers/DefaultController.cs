using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HasanBozkusCv.Models.Entity;

namespace HasanBozkusCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        DBCvEntities db = new DBCvEntities();

        // GET: Default
        public ActionResult Index()
        {
            var degerler = db.Abouts.ToList();
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalMedya = db.SocialMedia.Where(x => x.Status == true).ToList();
            return PartialView(sosyalMedya);
        }

        public PartialViewResult Deneyim()
        {
            var deneyimler = db.Experience.ToList();
            return PartialView(deneyimler);
        }

        public PartialViewResult Egitimler()
        {
            var egitimler = db.Educations.ToList();
            return PartialView(egitimler);
        }

        public PartialViewResult Yetenekler()
        {
            var yetenekler = db.Skills.ToList();
            return PartialView(yetenekler);
        }

        public PartialViewResult Hobiler()
        {
            var hobiler = db.Hobbys.ToList();
            return PartialView(hobiler);
        }


        public PartialViewResult Sertifikalar()
        {
            var sertifikalar = db.Certificates.ToList();
            return PartialView(sertifikalar);
        }

        [HttpGet]
        public PartialViewResult İletisim()
        {
            var iletisim = db.Contacts.ToList();
            return PartialView(iletisim);
        }

        [HttpPost]
        public PartialViewResult İletisim(Contacts contacts)
        {
            contacts.DateTime = Convert.ToDateTime(DateTime.UtcNow.ToShortDateString());
            db.Contacts.Add(contacts);
            db.SaveChanges();
            return PartialView();
        }

    }
}