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
    public class PetTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PetTypes
        public ActionResult Index()
        {
            var petTypes = db.PetTypes.Include(p => p.AnimalType).Include(p => p.Breed).Include(p => p.Cover);
            return View(petTypes.ToList());
        }

        // GET: PetTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetType petType = db.PetTypes.Find(id);
            if (petType == null)
            {
                return HttpNotFound();
            }
            return View(petType);
        }

        // GET: PetTypes/Create
        public ActionResult Create()
        {
            ViewBag.AnimalTypeId = new SelectList(db.AnimalTypes, "ID", "Name");
            ViewBag.BreedId = new SelectList(db.Breeds, "ID", "Name");
            ViewBag.CoverId = new SelectList(db.Covers, "ID", "Name");
            return View();
        }

        // POST: PetTypes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,AnimalTypeId,CoverId,BreedId")] PetType petType)
        {
            if (ModelState.IsValid)
            {
                db.PetTypes.Add(petType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnimalTypeId = new SelectList(db.AnimalTypes, "ID", "Name", petType.AnimalTypeId);
            ViewBag.BreedId = new SelectList(db.Breeds, "ID", "Name", petType.BreedId);
            ViewBag.CoverId = new SelectList(db.Covers, "ID", "Name", petType.CoverId);
            return View(petType);
        }

        // GET: PetTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetType petType = db.PetTypes.Find(id);
            if (petType == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnimalTypeId = new SelectList(db.AnimalTypes, "ID", "Name", petType.AnimalTypeId);
            ViewBag.BreedId = new SelectList(db.Breeds, "ID", "Name", petType.BreedId);
            ViewBag.CoverId = new SelectList(db.Covers, "ID", "Name", petType.CoverId);
            return View(petType);
        }

        // POST: PetTypes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,AnimalTypeId,CoverId,BreedId")] PetType petType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(petType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnimalTypeId = new SelectList(db.AnimalTypes, "ID", "Name", petType.AnimalTypeId);
            ViewBag.BreedId = new SelectList(db.Breeds, "ID", "Name", petType.BreedId);
            ViewBag.CoverId = new SelectList(db.Covers, "ID", "Name", petType.CoverId);
            return View(petType);
        }

        // GET: PetTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetType petType = db.PetTypes.Find(id);
            if (petType == null)
            {
                return HttpNotFound();
            }
            return View(petType);
        }

        // POST: PetTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PetType petType = db.PetTypes.Find(id);
            db.PetTypes.Remove(petType);
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
