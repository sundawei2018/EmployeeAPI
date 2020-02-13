using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EmployeeTaskAPI.Models;

namespace EmployeeTaskAPI.Controllers
{
    public class ETasksController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/ETasks
        public IQueryable<ETask> GetTasks()
        {
            return db.Tasks;
        }

        // GET: api/ETasks/5
        [ResponseType(typeof(ETask))]
        public IHttpActionResult GetETask(int id)
        {
            ETask eTask = db.Tasks.Find(id);
            if (eTask == null)
            {
                return NotFound();
            }

            return Ok(eTask);
        }

        // PUT: api/ETasks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutETask(int id, ETask eTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eTask.TaskId)
            {
                return BadRequest();
            }

            db.Entry(eTask).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ETaskExists(id))
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

        // POST: api/ETasks
        [ResponseType(typeof(ETask))]
        public IHttpActionResult PostETask(ETask eTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tasks.Add(eTask);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = eTask.TaskId }, eTask);
        }

        // DELETE: api/ETasks/5
        [ResponseType(typeof(ETask))]
        public IHttpActionResult DeleteETask(int id)
        {
            ETask eTask = db.Tasks.Find(id);
            if (eTask == null)
            {
                return NotFound();
            }

            db.Tasks.Remove(eTask);
            db.SaveChanges();

            return Ok(eTask);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ETaskExists(int id)
        {
            return db.Tasks.Count(e => e.TaskId == id) > 0;
        }
    }
}