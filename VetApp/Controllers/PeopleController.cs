using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VetApp.Models;

namespace VetApp.Controllers
{
    public class PeopleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UserManager<ApplicationUser> manager;
        private ApplicationUser currentUser;

        protected override void OnActionExecuting(ActionExecutingContext filterContext) 
        {
            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            manager = new UserManager<ApplicationUser>(store);
            
            currentUser = manager.FindById(User.Identity.GetUserId());
        }

        // GET: People
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return View(db.People.ToList());
            }
            else if (currentUser.Person != null)
            {
                return RedirectToAction("Details", new { id = currentUser.Person.ID });
            }
            else
            {
                return RedirectToAction("Index", "Manage");
            }
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            if (!User.IsInRole("Admin")) 
            {
                return RedirectToAction("Details", new { id = currentUser.Person.ID });
            }

            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BirthDate,Name,MiddleName,LastName,Phone,Address,Confirmed")] Person person)
        {
            if (ModelState.IsValid)
            {
                if (currentUser.Person != null)
                {
                    if (User.IsInRole("Admin"))
                    {
                        db.People.Add(person);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Manage");
                    }
                }
                else
                {
                    db.People.Add(person);
                    db.SaveChanges();
                    currentUser.Person = person;
                    
                    manager.Update(currentUser);
                    return RedirectToAction("Index", "Manage");
                }
            }

            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            
            if (!User.IsInRole("Admin") && currentUser.Person.ID != id)
            {
                return RedirectToAction("Edit", new { id = currentUser.Person.ID });
            }

            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BirthDate,Name,MiddleName,LastName,Phone,Address,Confirmed")] Person person)
        {
            if (ModelState.IsValid)
            {
                int person_id = currentUser.Person.ID;
                if (!User.IsInRole("Admin") && person.ID != person_id)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            int person_id = currentUser.Person.ID;
            if (!User.IsInRole("Admin") && person_id != id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var person = db.Set<Person>().Include(m => m.Accounts)
                .SingleOrDefault(m => m.ID == id);
            db.Set<Person>().Remove(person);
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
