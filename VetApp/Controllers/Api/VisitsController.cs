using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VetApp.Models;

namespace VetApp.Controllers.Api
{
    public class VisitsController : ApiController
    {
        public class Event
        {
            public int id;
            public DateTime? start;
            public DateTime? end;
            public string title;
        }

        private ApplicationDbContext db; 
        public VisitsController()
        {
            db = new ApplicationDbContext();
            db.Configuration.ProxyCreationEnabled = false;
        }
        // GET: api/Visits
        // id title start end 

        public IQueryable<Event> GetVisits([FromUri]DateTime? start = null, [FromUri]DateTime? end = null)
        {
            var query = from v in db.Visits
                        select new Event
                        {
                            id = v.ID,
                            start = v.VisitDate,
                            end = DbFunctions.AddMinutes(v.VisitDate, v.VisitType.Duration),
                            title = v.VisitType.Name + " " + v.Pet.NickName, 
                        };
            return query;
        }

        // GET: api/Visits/5
        [ResponseType(typeof(Visit))]
        public IHttpActionResult GetVisit(int id)
        {
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return NotFound();
            }

            return Ok(visit);
        }

        // PUT: api/Visits/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVisit(int id, Visit visit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != visit.ID)
            {
                return BadRequest();
            }

            db.Entry(visit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Visits
        [ResponseType(typeof(Visit))]
        public IHttpActionResult PostVisit(Visit visit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Visits.Add(visit);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = visit.ID }, visit);
        }

        // DELETE: api/Visits/5
        [ResponseType(typeof(Visit))]
        public IHttpActionResult DeleteVisit(int id)
        {
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return NotFound();
            }

            db.Visits.Remove(visit);
            db.SaveChanges();

            return Ok(visit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VisitExists(int id)
        {
            return db.Visits.Count(e => e.ID == id) > 0;
        }
    }
}