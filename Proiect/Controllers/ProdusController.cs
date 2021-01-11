using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Proiect.Models;
using System.Data.Entity;

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
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                var produs = db.Produs.Include(i => i.Recenzie).FirstOrDefault(m => m.ProdusId == id);
                foreach(var recenzie in produs.Recenzie)
                {
                    recenzie.User = db.Users.FirstOrDefault(r => r.Id == recenzie.UserId);
                   
                }
                return View(produs);
               
            }
            return HttpNotFound("Missing id paramater");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult New()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Produs p)
        {
            if (!ModelState.IsValid)
                return View("New", p);
            db.Produs.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Produs produs = db.Produs.Find(id);
            ViewBag.Produs = produs;
            return View(produs);
        }
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Produs produs = db.Produs.Find(id);
            db.Produs.Remove(produs);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        [Route("{controller}/{id}")]
        public ActionResult AtribuireMagazin(int id)
        {
            var magazin = db.Magazin.ToList();
            ViewData["ProdusId"] = id;
            ViewBag.Magazin = magazin;
            return View(magazin);
        }
        [HttpPost]
        public ActionResult Atribui(Produs p)
        {
            if (!ModelState.IsValid)
                return View("AtribuireMagazin");
            Produs produs = db.Produs.Single(s => s.ProdusId == p.ProdusId);
            produs.MagazinId = p.MagazinId;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");

        }
    }
}