using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proiect.Models;

namespace Proiect.Controllers
{
    public class ProdusController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        // GET: Produs
        public ActionResult Index()
        {
            List<Produs> produse = db.Produs.ToList();
            ViewBag.Produs = produse;
            return View();
        }
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Produs p)
        {
            if (!ModelState.IsValid)
                return View("New", p);
            db.Produs.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        public ActionResult Edit(int id)
        {
            Produs produs = db.Produs.Find(id);
            ViewBag.Produs = produs;
            return View(produs);
        }
        [HttpPost]
        public ActionResult Update(Produs p)
        {
            if (!ModelState.IsValid)
                return View("Edit", p);

            Produs produs = db.Produs.Single(s => s.ProdusId == p.ProdusId);
            produs.Denumire = p.Denumire;
            produs.Pret = p.Pret;
            produs.Recenzie = p.Recenzie;
            produs.Magazine = p.Magazine;
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Produs produs = db.Produs.Find(id);
            db.Produs.Remove(produs);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}