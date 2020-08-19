using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Security;
using Bus.Models;
using BusReservationNProject;

namespace BusReservationNProject.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class UserDetailsController : ApiController
    {
        private BusReservationEntities db = new BusReservationEntities();

        // GET: api/UserDetails

        public List<proc_UserLogin3_Result> GettblUsers()
        {
            db.proc_UserLogin3();
            List<proc_UserLogin3_Result> login = new List<proc_UserLogin3_Result>();
            foreach (var item in db.proc_UserLogin3())
            {
                login.Add(item);
            }
            return login;
        }
        // GET: api/Users/5
        [HttpPost]
        public IHttpActionResult PostUserDetails(proc_UserLogin3_Result user)
        {
            string a = null;
            List<proc_UserLogin3_Result> login = new List<proc_UserLogin3_Result>();
            foreach (var item in db.proc_UserLogin3())
            {
                login.Add(item);
            }
            foreach (var item in login)
            {
                if (item.UID == user.UID && item.Password == user.Password)
                {
                    FormsAuthentication.SetAuthCookie(item.UID.ToString(), false);
                    a = "Logged in";
                }
            }

            //UserDetails UserDetails = db.UsersDetails.Find(id);
            if (a == null)
            {
                return NotFound();
            }

            return Ok(a);
        }
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserDetails(string id, UserDetail UserDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != UserDetail.UID.ToString())
            {
                return BadRequest();
            }

            db.Entry(UserDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDetailExists(id))
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

        // DELETE: api/Users/5
        [ResponseType(typeof(UserDetail))]
        public IHttpActionResult DeletetblUser(string id)
        {
            UserDetail UserDetail = db.UserDetails.Find(id);
            if (UserDetail == null)
            {
                return NotFound();
            }

            db.UserDetails.Remove(UserDetail);
            db.SaveChanges();

            return Ok(UserDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserDetailExists(string id)
        {
            return db.UserDetails.Count(e => e.UID.ToString() == id) > 0;
        }
    }
}
