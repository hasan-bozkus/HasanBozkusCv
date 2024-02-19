using HasanBozkusCv.Models.Entity;
using HasanBozkusCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HasanBozkusCv.Controllers
{
    public class SertifikaController : Controller
    {
        GenericRepository<Certificates> repo = new GenericRepository<Certificates>();

        // GET: Sertifika
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            ViewBag.d = id;
            return View(sertifika);
        }

        [HttpPost]
        public ActionResult SertifikaGetir(Certificates c)
        {
            var sertifika = repo.Find(x => x.ID == c.ID);
            sertifika.Descpription = c.Descpription;
            sertifika.DateTime = c.DateTime;
            
            repo.TUpdate(c);
            return RedirectToAction("Index");
        }

        
        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }

        public ActionResult SertifikaEkle(Certificates certificates)
        {
            repo.TAdd(certificates);
            return RedirectToAction("Index");
        }
    }
}