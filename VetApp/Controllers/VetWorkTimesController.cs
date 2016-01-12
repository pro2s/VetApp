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
    public class VetWorkTimesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IEnumerable<SelectListItem> GetWorkTimes()
        {

            var worktimes = db.WorkTimes.ToList()
                .Select(s => new SelectListItem
                {
                    Value = s.ID.ToString(),
                    Text = string.Format(
                           "c {0:D2}:{1:D2} по {2:D2}:{3:D2}",
                           s.start / 60,
                           s.start % 60,
                           s.end / 60,
                           s.end % 60)
                });
            return worktimes;               
        }
        // GET: VetWorkTimes
        public ActionResult Index()
        {
            var vetWorkTimes = db.VetWorkTimes.Include(v => v.Vet).Include(v => v.WorkTime);
            return View(vetWorkTimes.ToList());
        }

        // GET: VetWorkTimes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VetWorkTime vetWorkTime = db.VetWorkTimes.Find(id);
            if (vetWorkTime == null)
            {
                return HttpNotFound();
            }
            return View(vetWorkTime);
        }

        // GET: VetWorkTimes/Create
        public ActionResult Create()
        {
            ViewBag.VetId = new SelectList(db.Vets, "ID", "Description");
            
            ViewBag.WorkTimeId = new SelectList(GetWorkTimes(), "Value", "Text");

            return View();
        }

        // POST: VetWorkTimes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Day,VetId,WorkTimeId")] VetWorkTime vetWorkTime)
        {
            if (ModelState.IsValid)
            {
                db.VetWorkTimes.Add(vetWorkTime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VetId = new SelectList(db.Vets, "ID", "Description", vetWorkTime.VetId);
            ViewBag.WorkTimeId = new SelectList(db.WorkTimes, "ID", "WorkTime", vetWorkTime.WorkTimeId);
            return View(vetWorkTime);
        }

        // GET: VetWorkTimes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VetWorkTime vetWorkTime = db.VetWorkTimes.Find(id);
            if (vetWorkTime == null)
            {
                return HttpNotFound();
            }
            ViewBag.VetId = new SelectList(db.Vets, "ID", "Description", vetWorkTime.VetId);
            ViewBag.WorkTimeId = new SelectList(db.WorkTimes, "ID", "ID", vetWorkTime.WorkTimeId);
            return View(vetWorkTime);
        }

        // POST: VetWorkTimes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Day,VetId,WorkTimeId")] VetWorkTime vetWorkTime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vetWorkTime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VetId = new SelectList(db.Vets, "ID", "Description", vetWorkTime.VetId);
            ViewBag.WorkTimeId = new SelectList(db.WorkTimes, "ID", "ID", vetWorkTime.WorkTimeId);
            return View(vetWorkTime);
        }

        // GET: VetWorkTimes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VetWorkTime vetWorkTime = db.VetWorkTimes.Find(id);
            if (vetWorkTime == null)
            {
                return HttpNotFound();
            }
            return View(vetWorkTime);
        }

        // POST: VetWorkTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VetWorkTime vetWorkTime = db.VetWorkTimes.Find(id);
            db.VetWorkTimes.Remove(vetWorkTime);
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
