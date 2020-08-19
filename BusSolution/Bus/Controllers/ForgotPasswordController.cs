using Bus.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Security;

namespace BusReservationNProject.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ForgotPasswordController : ApiController
    {
        private BusReservationEntities db = new BusReservationEntities();
        [HttpGet]
        public List<proc_ForgotPassword_Result> Get()
        {
            List<proc_ForgotPassword_Result> list = new List<proc_ForgotPassword_Result>();
            foreach (var item in db.proc_ForgotPassword())
            {
                list.Add(item);

            }
            return list;
        }
        [HttpPost]
        public IHttpActionResult Post(proc_ForgotPassword_Result user)
        {
            string str = null;
            List<proc_ForgotPassword_Result> security = new List<proc_ForgotPassword_Result>();
            foreach (var item in db.proc_ForgotPassword())
            {
                security.Add(item);
            }
            foreach (var item in security)
            {
                if (item.UID == user.UID && item.SecurityQuestion == user.SecurityQuestion)
                {
                    FormsAuthentication.SetAuthCookie(item.UID.ToString(), false);
                    str = "You can change your password now";
                }
            }

            //UserDetails UserDetails = db.UsersDetails.Find(id);
            if (str == null)
            {
                return NotFound();
            }

            return Ok(str);
        }
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, UserDetail changepassword)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != changepassword.UID)
            //{
            //    return BadRequest();
            //}

            //db.Entry(changepassword).State = EntityState.Modified;
            using (var a = new BusReservationEntities())
            {
                var user = a.UserDetails.Where(m => m.UID == id).FirstOrDefault<UserDetail>();
                if (user != null)
                {
                    if (changepassword.Password != null)
                    {
                        user.Password = changepassword.Password;
                    }
                    a.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok("updated password");
        }
    }
}
