﻿using HasanBozkusCv.Models.Entity;
using HasanBozkusCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HasanBozkusCv.Controllers
{
    public class HakkımdaController : Controller
    {
        GenericRepository<Abouts> repo = new GenericRepository<Abouts>();

        // GET: Hakkımda

        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }

        [HttpPost]
        public ActionResult Index(Abouts p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Name = p.Name;
            t.Surname = p.Surname;
            t.Address = p.Address;
            t.Mail = p.Mail;
            t.Phone = p.Phone;
            t.Description = p.Description;
            t.Image = p.Image;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}