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
using AccountOwnership.Models;

namespace AccountOwnership.Controllers
{
    public class RecordController : ApiController
    {
        private AccountOwnershipContext db = new AccountOwnershipContext();

        // GET: api/Record
        public IQueryable<Record> GetRecords()
        {
            var records = db.Records
                .Include(x => x.Client)
                .Include(x => x.EVP)
                .Include(x => x.SVP)
                .Include(x => x.VP)
                .Include(x => x.ED);
            
            return records;
        }

        // GET: api/Record/5
        [ResponseType(typeof(Record))]
        public async Task<IHttpActionResult> GetRecord(int id)
        {
            Record record = await db.Records.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }
            var recordFound = db.Records
                .Where(x => x.Id == record.Id)
                .Include(x => x.Client)
                .Include(x => x.EVP)
                .Include(x => x.SVP)
                .Include(x => x.VP)
                .Include(x => x.ED);

            return Ok(recordFound);
        }

        // PUT: api/Record/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRecord(int id, Record record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != record.Id)
            {
                return BadRequest();
            }

            db.Entry(record).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordExists(id))
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

        // POST: api/Record
        [ResponseType(typeof(Record))]
        public async Task<IHttpActionResult> PostRecord(Record record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(record.EVP).State = EntityState.Unchanged;
            db.Entry(record.SVP).State = EntityState.Unchanged;
            db.Entry(record.VP).State = EntityState.Unchanged;
            db.Entry(record.ED).State = EntityState.Unchanged;
            db.Entry(record.Status).State = EntityState.Unchanged;
            db.Entry(record.Client).State = EntityState.Unchanged;

            db.Records.Add(record);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = record.Id }, record);
        }

        // DELETE: api/Record/5
        [ResponseType(typeof(Record))]
        public async Task<IHttpActionResult> DeleteRecord(int id)
        {
            Record record = await db.Records.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }

            db.Records.Remove(record);
            await db.SaveChangesAsync();

            return Ok(record);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecordExists(int id)
        {
            return db.Records.Count(e => e.Id == id) > 0;
        }
    }
}