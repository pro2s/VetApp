using System;
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
    public class AnimalTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AnimalTypes
        public ActionResult Index()
        {
            return View(db.AnimalTypes.ToList());
        }

        // GET: AnimalTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalType animalType = db.AnimalTypes.Find(id);
            if (animalType == null)
            {
                return HttpNotFound();
            }
            return View(animalType);
        }

        // GET: AnimalTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnimalTypes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] AnimalType animalType)
        {
            if (ModelState.IsValid)
            {
                db.AnimalTypes.Add(animalType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(animalType);
        }

        // GET: AnimalTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalType animalType = db.AnimalTypes.Find(id);
            if (animalType == null)
            {
                return HttpNotFound();
            }
            return View(animalType);
        }

        // POST: AnimalTypes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] AnimalType animalType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animalType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(animalType);
        }

        // GET: AnimalTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalType animalType = db.AnimalTypes.Find(id);
            if (animalType == null)
            {
                return HttpNotFound();
            }
            return View(animalType);
        }

        // POST: AnimalTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnimalType animalType = db.AnimalTypes.Find(id);
            db.AnimalTypes.Remove(animalType);
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
