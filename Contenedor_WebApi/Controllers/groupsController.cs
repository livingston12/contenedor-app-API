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
    [RoutePrefix("api/groups")]
    public class groupsController : ApiController
    {
        private App_contenedorEntities db = new App_contenedorEntities();

        // GET: api/groups
        [Route("getAll")]
        public IQueryable<group> Getgroups()
        {
            return db.groups;
        }

        // GET: api/groups/5
        [ResponseType(typeof(group)),Route("getbyid")]
        public async Task<IHttpActionResult> Getgroup(int id)
        {
            group group = await db.groups.FindAsync(id);
            if (group == null)
            {
                return NotFound();
            }

            return Ok(group);
        }

        // PUT: api/groups/5
        [ResponseType(typeof(void)),Route("Put")]
        public async Task<IHttpActionResult> Putgroup(int id, group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != group.id_group)
            {
                return BadRequest();
            }

            db.Entry(group).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!groupExists(id))
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

        // POST: api/groups
        [ResponseType(typeof(group)),Route("Post")]
        public async Task<IHttpActionResult> Postgroup(group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.groups.Add(group);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = group.id_group }, group);
        }

        // DELETE: api/groups/5
        [ResponseType(typeof(group)), Route("Delete")]
        public async Task<IHttpActionResult> Deletegroup(int id)
        {
            group group = await db.groups.FindAsync(id);
            if (group == null)
            {
                return NotFound();
            }

            db.groups.Remove(group);
            await db.SaveChangesAsync();

            return Ok(group);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool groupExists(int id)
        {
            return db.groups.Count(e => e.id_group == id) > 0;
        }
    }
}