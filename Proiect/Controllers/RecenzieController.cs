﻿using Proiect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Proiect.Controllers
{
    public class RecenzieController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        // GET: Produs
        public ActionResult Index()
        {
            List<Recenzie> recenzie = db.Recenzie.ToList();
            ViewBag.Recenzie = recenzie;
            return View();
        }
        [Authorize(Roles = "User,Admin")]
        [Route( "{controller}/{id}")]
        public ActionResult New(int id)
        {
            ViewData["ProdusId"] = id;

            return View();
        }
        [Authorize(Roles = "User,Admin")]
        [HttpPost]
        public ActionResult Create(Recenzie r)
        {
            
            if (!ModelState.IsValid)
                return View("New", r);
            db.Recenzie.Add(r);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "User,Admin")]
        public ActionResult Edit(int id)
        {   
            Recenzie recenzie = db.Recenzie.Find(id);
            if(!User.IsInRole("Admin"))
                if (recenzie.UserId!= User.Identity.GetUserId())
                    return HttpNotFound("You don't have acces to modify this ");
            return View(recenzie);
        }
        [Authorize(Roles = "User,Admin")]
        [HttpPost]
        public ActionResult Update(Recenzie r)
        {
            if (!ModelState.IsValid)
                return View("Edit", r);
            Console.WriteLine(r.UserId);
            Recenzie recenzie = db.Recenzie.Single(s => s.RecenzieId == r.RecenzieId);
            recenzie.Descriere = r.Descriere;
            recenzie.Rating = r.Rating;

            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "User,Admin")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Recenzie recenzie = db.Recenzie.Find(id);
            db.Recenzie.Remove(recenzie);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}