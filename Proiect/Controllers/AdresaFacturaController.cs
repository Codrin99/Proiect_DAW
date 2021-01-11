using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proiect.Controllers
{
    public class AdresaFacturaController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        // GET: Produs
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [Route("{controller}/{id}")]
        public ActionResult New(int id)
        {
            ViewData["FacturaId"] = id;
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(AdresaFactura f)
        {

            if (!ModelState.IsValid)
                return View("New", f);
            db.AdresaFactura.Add(f);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            AdresaFactura adresafactura = db.AdresaFactura.Find(id);
            if (!User.IsInRole("Admin"))
                return HttpNotFound("You don't have acces to modify this ");
            return View(adresafactura);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Update(AdresaFactura f)
        {
            if (!ModelState.IsValid)
                return View("Edit", f);
            AdresaFactura adresafactura = db.AdresaFactura.Single(s => s.AdresaFacturaId == f.AdresaFacturaId);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            AdresaFactura adresafactura = db.AdresaFactura.Find(id);
            db.AdresaFactura.Remove(adresafactura);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}