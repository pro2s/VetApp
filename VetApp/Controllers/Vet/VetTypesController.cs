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
    public class VetTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VetTypes
        public ActionResult Index()
        {
            return View(db.VetTypes.ToList());
        }

        // GET: VetTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VetType vetType = db.VetTypes.Find(id);
            if (vetType == null)
            {
                return HttpNotFound();
            }
            return View(vetType);
        }

        // GET: VetTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VetTypes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,IsDoctor")] VetType vetType)
        {
            if (ModelState.IsValid)
            {
                db.VetTypes.Add(vetType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vetType);
        }

        // GET: VetTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VetType vetType = db.VetTypes.Find(id);
            if (vetType == null)
            {
                return HttpNotFound();
            }
            return View(vetType);
        }

        // POST: VetTypes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,IsDoctor")] VetType vetType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vetType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vetType);
        }

        // GET: VetTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VetType vetType = db.VetTypes.Find(id);
            if (vetType == null)
            {
                return HttpNotFound();
            }
            return View(vetType);
        }

        // POST: VetTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VetType vetType = db.VetTypes.Find(id);
            db.VetTypes.Remove(vetType);
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
