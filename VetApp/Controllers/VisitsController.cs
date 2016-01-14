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
    public class VisitsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Visits
        public ActionResult Index()
        {
            var visits = db.Visits.Include(v => v.Examination).Include(v => v.Pet).Include(v => v.Vet).Include(v => v.VisitType);
            return View(visits.ToList());
        }

        // GET: Visits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }


        private void CreateViewBag()
        {
            ViewBag.ExaminationId = new SelectList(db.Examination, "ID", "CoverState");
            ViewBag.PetId = new SelectList(db.Pets, "ID", "NickName");
            ViewBag.VetId = new SelectList(db.Vets, "ID", "Description");
            ViewBag.VisitTypeId = new SelectList(db.VisitTypes, "ID", "Name");
        }

        // GET: Visits/Create
        public ActionResult Create(bool partial = false)
        {
            CreateViewBag();
            
            Visit model = new Visit();
            model.VisitDate = DateTime.Now;

            if (partial)
            {
                return PartialView(model);
            }
            else
            {
                return View(model);
            }
        }
        
        
        // POST: Visits/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,VisitDate,Status,VisitTypeId,PetId,VetId,ExaminationId")] Visit visit)
        {
            if (ModelState.IsValid)
            {
                db.Visits.Add(visit);
                db.SaveChanges();
                if (!ControllerContext.IsChildAction)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    // return entered data or other view or view with empty visit
                    CreateViewBag();
                    return PartialView(visit);
                }
            }

            CreateViewBag();
            return View(visit);
        }

        // GET: Visits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExaminationId = new SelectList(db.Examination, "ID", "CoverState", visit.ExaminationId);
            ViewBag.PetId = new SelectList(db.Pets, "ID", "NickName", visit.PetId);
            ViewBag.VetId = new SelectList(db.Vets, "ID", "Description", visit.VetId);
            ViewBag.VisitTypeId = new SelectList(db.VisitTypes, "ID", "Name", visit.VisitTypeId);
            return View(visit);
        }

        // POST: Visits/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,VisitDate,Status,VisitTypeId,PetId,VetId,ExaminationId")] Visit visit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExaminationId = new SelectList(db.Examination, "ID", "CoverState", visit.ExaminationId);
            ViewBag.PetId = new SelectList(db.Pets, "ID", "NickName", visit.PetId);
            ViewBag.VetId = new SelectList(db.Vets, "ID", "Description", visit.VetId);
            ViewBag.VisitTypeId = new SelectList(db.VisitTypes, "ID", "Name", visit.VisitTypeId);
            return View(visit);
        }

        // GET: Visits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }

        // POST: Visits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visit visit = db.Visits.Find(id);
            db.Visits.Remove(visit);
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
