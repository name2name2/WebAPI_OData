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
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using WebAPI_TestNew20160816.Models;

namespace WebAPI_TestNew20160816.Controllers
{
    /*
    To add a route for this controller, merge these statements into the Register method of the WebApiConfig class. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using WebAPI_TestNew20160816.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<T4>("T4");
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class T4Controller : ODataController
    {
        private T4Context db = new T4Context();

        // GET odata/T4
        [Queryable]
        public IQueryable<T4> GetT4()
        {
            return db.T4;
        }

        // GET odata/T4(5)
        [Queryable]
        public SingleResult<T4> GetT4([FromODataUri] string key)
        {
            return SingleResult.Create(db.T4.Where(t4 => t4.AgentID == key));
        }

        // PUT odata/T4(5)
        public async Task<IHttpActionResult> Put([FromODataUri] string key, T4 t4)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != t4.AgentID)
            {
                return BadRequest();
            }

            db.Entry(t4).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!T4Exists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(t4);
        }

        // POST odata/T4
        public async Task<IHttpActionResult> Post(T4 t4)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.T4.Add(t4);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (T4Exists(t4.AgentID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(t4);
        }

        // PATCH odata/T4(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<T4> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            T4 t4 = await db.T4.FindAsync(key);
            if (t4 == null)
            {
                return NotFound();
            }

            patch.Patch(t4);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!T4Exists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(t4);
        }

        // DELETE odata/T4(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] string key)
        {
            T4 t4 = await db.T4.FindAsync(key);
            if (t4 == null)
            {
                return NotFound();
            }

            db.T4.Remove(t4);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool T4Exists(string key)
        {
            return db.T4.Count(e => e.AgentID == key) > 0;
        }
    }
}
