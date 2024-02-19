using HasanBozkusCv.Models.Entity;
using HasanBozkusCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HasanBozkusCv.Controllers
{
    public class İletisimController : Controller
    {
        GenericRepository<Contacts> repo = new GenericRepository<Contacts>();

        // GET: İletisim
        public ActionResult Index()
        {
            var iletisim = repo.List();
            return View(iletisim);
        }
    }
}