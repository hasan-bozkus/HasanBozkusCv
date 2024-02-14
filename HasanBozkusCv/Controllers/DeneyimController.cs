using HasanBozkusCv.Models.Entity;
using HasanBozkusCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HasanBozkusCv.Controllers
{
    public class DeneyimController : Controller
    {
        DeneyimRepository repo = new DeneyimRepository();


        // GET: Deneyim
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeneyimEkle(Experience experience)
        {
            repo.TAdd(experience);
            return RedirectToAction("Index");
        }

        public ActionResult DeneyimSil(int id)
        {
            Experience t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            Experience t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult DeneyimGetir(Experience experience)
        {
            Experience t = repo.Find(x => x.ID == experience.ID);
            t.Title = experience.Title;
            t.SubTitle = experience.SubTitle;
            t.DateTime = experience.DateTime;
            t.Description = experience.Description;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}