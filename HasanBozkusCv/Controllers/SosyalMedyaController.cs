using HasanBozkusCv.Models.Entity;
using HasanBozkusCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HasanBozkusCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        GenericRepository<SocialMedia> repo = new GenericRepository<SocialMedia>();

        // GET: SosyalMedya
        public ActionResult Index()
        {
            var veriler = repo.List();
            return View(veriler);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(SocialMedia s)
        {
            repo.TAdd(s);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            return View(hesap);
        }

        [HttpPost]
        public ActionResult SayfaGetir(SocialMedia s)
        {
            var hesap = repo.Find(x => x.ID == s.ID);
            hesap.Ad = s.Ad;
            hesap.Link = s.Link;
            hesap.Icon = s.Icon;
            hesap.Status = true;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            hesap.Status = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
    }
}