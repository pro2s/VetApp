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
    public class ExaminationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Examinations
        public ActionResult Index()
        {
            var examination = db.Examination.Include(e => e.Pet);
            return View(examination.ToList());
        }

        // GET: Examinations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examination examination = db.Examination.Find(id);
            if (examination == null)
            {
                return HttpNotFound();
            }
            return View(examination);
        }

        // GET: Examinations/Create
        public ActionResult Create()
        {
            ViewBag.PetId = new SelectList(db.Pets, "ID", "NickName");
            return View();
        }

        // POST: Examinations/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PetId,Temperature,Pulse,Weight,Lenght,Hieght,CoverState,AtClinic")] Examination examination)
        {
            if (ModelState.IsValid)
            {
                db.Examination.Add(examination);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PetId = new SelectList(db.Pets, "ID", "NickName", examination.PetId);
            return View(examination);
        }

        // GET: Examinations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examination examination = db.Examination.Find(id);
            if (examination == null)
            {
                return HttpNotFound();
            }
            ViewBag.PetId = new SelectList(db.Pets, "ID", "NickName", examination.PetId);
            return View(examination);
        }

        // POST: Examinations/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PetId,Temperature,Pulse,Weight,Lenght,Hieght,CoverState,AtClinic")] Examination examination)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examination).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PetId = new SelectList(db.Pets, "ID", "NickName", examination.PetId);
            return View(examination);
        }

        // GET: Examinations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examination examination = db.Examination.Find(id);
            if (examination == null)
            {
                return HttpNotFound();
            }
            return View(examination);
        }

        // POST: Examinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Examination examination = db.Examination.Find(id);
            db.Examination.Remove(examination);
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
