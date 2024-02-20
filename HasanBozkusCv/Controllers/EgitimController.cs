using HasanBozkusCv.Models.Entity;
using HasanBozkusCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HasanBozkusCv.Controllers
{
    [Authorize]
    public class EgitimController : Controller
    {
        GenericRepository<Educations> repo = new GenericRepository<Educations>();

        // GET: Egitim
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EgitimEkle(Educations educations)
        {
            if(!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(educations);
            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x=> x.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }

        [HttpPost]
        public ActionResult EgitimDuzenle(Educations educations)
        {
            var y = repo.Find(x => x.ID == educations.ID);
            y.Title = educations.Title;
            y.SubTitle = educations.SubTitle;
            y.SubTitle2 = educations.SubTitle2;
            y.GNO = educations.GNO;
            y.DateTime = educations.DateTime;
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TUpdate(y);
            return RedirectToAction("Index");
        }
    }
}