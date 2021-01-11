using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proiect.Controllers
{
    public class FacturaController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        // GET: Produs
        public ActionResult Index()
        {
            List<Factura> factura = db.Factura.ToList();
            ViewBag.Factura = factura;
            return View();
        }
        [Authorize(Roles = "Admin")]
        [Route("{controller}/{id}")]
        public ActionResult New(int id)
        {
            ViewData["ProdusId"] = id;
            Produs produs = db.Produs.Find(id);
            ViewData["Pret"] = produs.Pret;
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Factura f)
        {

            if (!ModelState.IsValid)
                return View("New", f);
            db.Factura.Add(f);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Factura factura = db.Factura.Find(id);
            if (!User.IsInRole("Admin"))
                return HttpNotFound("You don't have acces to modify this ");
            return View(factura);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Update(Factura f)
        {
            if (!ModelState.IsValid)
                return View("Edit", f);
            Factura factura = db.Factura.Single(s => s.FacturaId == f.FacturaId);
            factura.Valoare = f.Valoare;
            factura.Adresa = f.Adresa;
            factura.NumeClient = f.NumeClient;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Factura factura = db.Factura.Find(id);
            db.Factura.Remove(factura);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult ListaFacturi()
        {
            var facturi = db.Factura.ToList();

            ViewBag.Factura = facturi;
            return View(facturi);
        }
    }
}