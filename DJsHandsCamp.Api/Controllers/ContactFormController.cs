using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using DJsHandsCamp.Api.Models;

namespace DJsHandsCamp.Api.Controllers
{
    public class ContactFormController : ApiController
    {
        private HcContext db = new HcContext();

        // GET api/ContactUs
        public IEnumerable<ContactForm> GetContactUs()
        {
            var contactus = db.ContactForm.Include(c => c.HcMember);
            return contactus.AsEnumerable();
        }

        // GET api/ContactUs/5
        public ContactForm GetContactUs(int id)
        {
            ContactForm contactus = db.ContactForm.Find(id);
            if (contactus == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return contactus;
        }

        // PUT api/ContactUs/5
        public HttpResponseMessage PutContactUs(int id, ContactForm contactus)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != contactus.ContactFormId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(contactus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/ContactUs
        public HttpResponseMessage PostContactUs(ContactForm contactForm)
        {
            if (ModelState.IsValid)
            {
                db.ContactForm.Add(contactForm);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, contactForm);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = contactForm.ContactFormId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/ContactUs/5
        public HttpResponseMessage DeleteContactUs(int id)
        {
            ContactForm contactus = db.ContactForm.Find(id);
            if (contactus == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.ContactForm.Remove(contactus);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, contactus);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}