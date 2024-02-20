using HasanBozkusCv.Models.Entity;
using HasanBozkusCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HasanBozkusCv.Controllers
{
    public class AdminController : Controller
    { 
        GenericRepository<Admin> repo = new GenericRepository<Admin>();
    
        // GET: Admin
        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }

        [HttpGet]
        public ActionResult AdminDuzenle(int id)
        {
            Admin t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult AdminDuzenle(Admin admin)
        {
            Admin t = repo.Find(x => x.ID == admin.ID);
            t.UserName = admin.UserName;
            t.Password = admin.Password;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminEkle(Admin admin)
        {
            repo.TAdd(admin);
            return RedirectToAction("Index");
        }        

        public ActionResult AdminSil(int id)
        {
            Admin t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        
    }
}