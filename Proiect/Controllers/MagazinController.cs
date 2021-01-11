using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proiect.Controllers
{
    public class MagazinController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        // GET: Produs
        public ActionResult Index()
        {
            List<Magazin> magazin = db.Magazin.ToList();
            ViewBag.Recenzie = magazin;
            return View();
        }
        [Authorize(Roles = "Admin")]
        [Route("{controller}/{id}")]
        public ActionResult New(int id)
        {
            ViewData["ProdusId"] = id;
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Magazin m)
        {

            if (!ModelState.IsValid)
                return View("New", m);
            db.Magazin.Add(m);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Magazin magazin = db.Magazin.Find(id);
            if (!User.IsInRole("Admin"))
                return HttpNotFound("You don't have acces to modify this ");
            return View(magazin);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Update(Magazin m)
        {
            if (!ModelState.IsValid)
                return View("Edit", m);
            Magazin magazin = db.Magazin.Single(s => s.MagazinId == m.MagazinId);
            magazin.DenumireMagazin = m.DenumireMagazin;
            magazin.Oras = m.Oras;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Magazin magazin = db.Magazin.Find(id);
            db.Magazin.Remove(magazin);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult ListaMagazine()
        {
            var magazin = db.Magazin.ToList();

            ViewBag.Magazin = magazin;
            return View(magazin);
        }
    }
}