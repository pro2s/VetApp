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
    public class VetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vets
        public ActionResult Index()
        {
            var vets = db.Vets.Include(v => v.Person).Include(v => v.VetType);
            return View(vets.ToList());
        }

        // GET: Vets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vet vet = db.Vets.Find(id);
            if (vet == null)
            {
                return HttpNotFound();
            }
            return View(vet);
        }

        // GET: Vets/Create
        public ActionResult Create()
        {
            ViewBag.PersonId = new SelectList(db.People, "ID", "Name");
            ViewBag.VetTypeId = new SelectList(db.VetTypes, "ID", "Name");
            return View();
        }

        // POST: Vets/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,PersonId,VetTypeId")] Vet vet)
        {
            if (ModelState.IsValid)
            {
                db.Vets.Add(vet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonId = new SelectList(db.People, "ID", "Name", vet.PersonId);
            ViewBag.VetTypeId = new SelectList(db.VetTypes, "ID", "Name", vet.VetTypeId);
            return View(vet);
        }

        // GET: Vets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vet vet = db.Vets.Find(id);
            if (vet == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonId = new SelectList(db.People, "ID", "Name", vet.PersonId);
            ViewBag.VetTypeId = new SelectList(db.VetTypes, "ID", "Name", vet.VetTypeId);
            return View(vet);
        }

        // POST: Vets/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,PersonId,VetTypeId")] Vet vet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonId = new SelectList(db.People, "ID", "Name", vet.PersonId);
            ViewBag.VetTypeId = new SelectList(db.VetTypes, "ID", "Name", vet.VetTypeId);
            return View(vet);
        }

        // GET: Vets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vet vet = db.Vets.Find(id);
            if (vet == null)
            {
                return HttpNotFound();
            }
            return View(vet);
        }

        // POST: Vets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vet vet = db.Vets.Find(id);
            db.Vets.Remove(vet);
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
