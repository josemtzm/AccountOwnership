using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AccountOwnership.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace AccountOwnership.Controllers
{
    public class RecordController : ApiController
    {
        private AccountOwnershipContext db = new AccountOwnershipContext();

        // GET: api/Record
        public IQueryable<Record> GetRecords()
        {
            var records = db.Records
                .Include(x => x.EVP)
                .Include(x => x.SVP)
                .Include(x => x.VP)
                .Include(x => x.ED)
                .Include(x => x.TAM)
                .Include(x => x.Finance)
                .Include(x => x.eWFM)
                .Include(x => x.POC)
                .Include(x => x.Status)
                .Include(x => x.Client)
                .Include(x => x.Client.Parent)
                .OrderBy(x => x.Client.Name);
            
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
                .Include(x => x.EVP)
                .Include(x => x.SVP)
                .Include(x => x.VP)
                .Include(x => x.ED)
                .Include(x => x.TAM)
                .Include(x => x.Finance)
                .Include(x => x.eWFM)
                .Include(x => x.POC)
                .Include(x => x.Status)
                .Include(x => x.Client);

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

            //Record existing = await db.Records.FindAsync(record.Id);
            //existing = record;
            //db.Records.AddOrUpdate<Record>(record);
            //db.Entry(record).State = EntityState.Modified;

            Record rec = await db.Records.FindAsync(id);
            rec.StartTime = record.StartTime;
            rec.EVP = record.EVP;
            rec.SVP = record.SVP;
            rec.VP = record.VP;
            rec.ED = record.ED;
            rec.TAM = record.TAM;
            rec.Finance = record.Finance;
            rec.eWFM = record.eWFM;
            rec.POC = record.POC;
            rec.EndTime = record.EndTime;
            rec.LastModifiedDate = record.LastModifiedDate;
            rec.GoLiveDate = record.GoLiveDate;
            rec.CloseDate = record.CloseDate;
            rec.Status = record.Status;
            rec.Client = record.Client;

            db.Entry(rec.EVP).State = EntityState.Unchanged;
            db.Entry(rec.SVP).State = EntityState.Unchanged;
            db.Entry(rec.VP).State = EntityState.Unchanged;
            db.Entry(rec.ED).State = EntityState.Unchanged;
            db.Entry(rec.TAM).State = EntityState.Unchanged;
            db.Entry(rec.Finance).State = EntityState.Unchanged;
            db.Entry(rec.eWFM).State = EntityState.Unchanged;
            db.Entry(rec.POC).State = EntityState.Unchanged;
            db.Entry(rec.Status).State = EntityState.Unchanged;
            db.Entry(rec.Client).State = EntityState.Unchanged;

            try
            {
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex);
                return StatusCode(HttpStatusCode.NotModified);
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex);
                return StatusCode(HttpStatusCode.NotModified);
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex);
                return StatusCode(HttpStatusCode.NotModified);
            }
            //return StatusCode(HttpStatusCode.NoContent);
            //try
            //{
            //    db.Entry(record).State = EntityState.Modified;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //    return StatusCode(HttpStatusCode.NotModified);
            //}
            //try
            //{
            //    await db.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!RecordExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        return StatusCode(HttpStatusCode.NotModified);
            //    }
            //}
            //catch (DbEntityValidationException dbEx)
            //{
            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //    {
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //        {
            //            Trace.TraceInformation("Class: {0}, Property: {1}, Error: {2}",
            //                validationErrors.Entry.Entity.GetType().FullName,
            //                validationError.PropertyName,
            //                validationError.ErrorMessage);
            //        }
            //    }

            //    throw;  // You can also choose to handle the exception here...
            //}
            //return StatusCode(HttpStatusCode.NoContent);
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
            db.Entry(record.TAM).State = EntityState.Unchanged;
            db.Entry(record.Finance).State = EntityState.Unchanged;
            db.Entry(record.eWFM).State = EntityState.Unchanged;
            db.Entry(record.POC).State = EntityState.Unchanged;
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