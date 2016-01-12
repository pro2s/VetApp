﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VetApp.Models;

namespace VetApp.Controllers
{
    public class VisitTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VisitTypes
        public ActionResult Index()
        {
            return View(db.VisitTypes.ToList());
        }

        // GET: VisitTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitType visitType = db.VisitTypes.Find(id);
            if (visitType == null)
            {
                return HttpNotFound();
            }
            return View(visitType);
        }

        // GET: VisitTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VisitTypes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,SelfRegistration,Duration")] VisitType visitType)
        {
            if (ModelState.IsValid)
            {
                db.VisitTypes.Add(visitType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(visitType);
        }

        // GET: VisitTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitType visitType = db.VisitTypes.Find(id);
            if (visitType == null)
            {
                return HttpNotFound();
            }
            return View(visitType);
        }

        // POST: VisitTypes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,SelfRegistration,Duration")] VisitType visitType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visitType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(visitType);
        }

        // GET: VisitTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitType visitType = db.VisitTypes.Find(id);
            if (visitType == null)
            {
                return HttpNotFound();
            }
            return View(visitType);
        }

        // POST: VisitTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VisitType visitType = db.VisitTypes.Find(id);
            db.VisitTypes.Remove(visitType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
