using HasanBozkusCv.Models.Entity;
using HasanBozkusCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HasanBozkusCv.Controllers
{
    public class HobilerimController : Controller
    {
        GenericRepository<Hobbys> repo = new GenericRepository<Hobbys>();
        // GET: Hobilerim

        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        } 
        
        [HttpPost]
        public ActionResult Index(Hobbys p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Description = p.Description;
            t.Description2 = p.Description2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}