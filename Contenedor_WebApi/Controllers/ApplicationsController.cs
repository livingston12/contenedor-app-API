using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Contenedor_WebApi.Models;

namespace Contenedor_WebApi.Controllers
{
    [RoutePrefix("api/apps")]
    public class ApplicationsController : ApiController
    {
        private App_contenedorEntities db = new App_contenedorEntities();

        // GET: api/Applications
        [Route("getAll")]
        public IQueryable<Application> GetApplications()
        {
           
            return db.Applications;
        }

        // GET: api/Applications/5
        [Route("getbyid")]
        [ResponseType(typeof(Application))]        
        public async Task<IHttpActionResult> GetApplication(int id)
        {
            Application application = await db.Applications.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }

            return Ok(application);
        }

        // PUT: api/Applications/5
        [Route("put")]
        [ResponseType(typeof(void))]
        public async  Task<IHttpActionResult> PutApplication(int id, Application application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != application.id_app)
            {
                return BadRequest();
            }

            db.Entry(application).State = EntityState.Modified;

            try
            {
               await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExists(id).Result)
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

        // POST: api/Applications
        [Route("post")]
        [ResponseType(typeof(Application))]
        public async Task<IHttpActionResult> PostApplication(Application application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Applications.Add(application);
            await db.SaveChangesAsync();

            return Ok(application);
            //return CreatedAtRoute("DefaultApi", new { id = application.id_app }, application);
        }

        // DELETE: api/Applications/5
        [Route("delete")]
        [ResponseType(typeof(Application))]
        public async Task<IHttpActionResult> DeleteApplication(int id)
        {
            Application application = await db.Applications.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }

            db.Applications.Remove(application);
            await db.SaveChangesAsync();

            return Ok(application);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private async Task<bool> ApplicationExists(int id)
        {
            return await db.Applications.CountAsync(e => e.id_app == id) > 0;
        }
    }
}