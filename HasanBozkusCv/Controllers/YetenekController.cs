using HasanBozkusCv.Models.Entity;
using HasanBozkusCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HasanBozkusCv.Controllers
{
    public class YetenekController : Controller
    {
        GenericRepository<Skills> repo = new GenericRepository<Skills>();

        // GET: Yetenek
        public ActionResult Index()
        {
            var yetenek = repo.List();
            return View(yetenek);
        }

        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View();
        }

        public ActionResult YetenekEkle(Skills skills)
        {
            repo.TAdd(skills);
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x=> x.ID == id);
            repo.TDelete(yetenek);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            return View(yetenek);
        }

        [HttpPost]
        public ActionResult YetenekDuzenle(Skills skills)
        {
            var y = repo.Find(x => x.ID == skills.ID);
            y.Skill = skills.Skill;
            y.Ratio = skills.Ratio;
            repo.TUpdate(y);
            return RedirectToAction("Index");
        }
    }
}