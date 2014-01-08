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
using System.Net.Mail;
using DJsHandsCamp.Api.Models;

namespace DJsHandsCamp.Api.Controllers
{
    public class HcMemberController : ApiController
    {
        private HcContext db = new HcContext();

        // GET api/HcMember
        public IEnumerable<HcMember> GetHcMembers()
        {



            return db.HcMembers.AsEnumerable();
        }

        // GET api/HcMember/5
        public HcMember GetHcMember(int id)
        {
            HcMember hcmember = db.HcMembers.Find(id);
            if (hcmember == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return hcmember;
        }

        // PUT api/HcMember/5
        public HttpResponseMessage PutHcMember(int id, HcMember hcmember)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != hcmember.HcMemberId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(hcmember).State = EntityState.Modified;

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

        // POST api/HcMember
        public HttpResponseMessage PostHcMember(HcMember hcmember)
        {
            if (ModelState.IsValid)
            {
                db.HcMembers.Add(hcmember);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, hcmember);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = hcmember.HcMemberId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
           
        }
            
            


        // DELETE api/HcMember/5
        public HttpResponseMessage DeleteHcMember(int id)
        {
            HcMember hcmember = db.HcMembers.Find(id);
            if (hcmember == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.HcMembers.Remove(hcmember);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, hcmember);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}