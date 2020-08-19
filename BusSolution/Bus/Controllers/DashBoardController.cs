using Bus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bus.Controllers
{
    public class DashBoardController : ApiController
    {
        private BusReservationEntities db = new BusReservationEntities();
        [HttpGet]
        public object showdata()
        {

            var userinfo = db.UserDetails.ToList();
            return userinfo;
        }
        [HttpGet]
        public object Profile(int id)
        {
            var profileinfopost = db.proc_Profile(id);
            return profileinfopost;
        }
        [HttpPost]
        public object search(UserDetail userinfo)
        {
            //var busInfoPost = db.proc_Bus(journeyinfo.FromLocation, journeyinfo.ToLocation, journeyinfo.FromDate);
            var userInfoPost = db.proc_Wallet(userinfo.UID);
            return userInfoPost;
        }
        //[HttpPut]
        //public IHttpActionResult Put(int id,UserDetail passwordchange)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest("Not a valid model");
        //    using (var cp=new BusReservationEntities())
        //    {
        //        var existingpass = cp.UserDetails.Where(p => p.UID == id).FirstOrDefault<UserDetail>();
        //        if (existingpass != null)
        //        {
        //            existingpass.Password = passwordchange.Password;
        //            cp.SaveChanges();
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }
        //    return Ok();
        //}
        [HttpPut]
        public IHttpActionResult PutUser(int id,EditUser valuechange)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using(var ue=new BusReservationEntities())
            {
                var existingdetails = ue.UserDetails.Where(p => p.UID == id).FirstOrDefault<UserDetail>();
                if (existingdetails != null)
                {
                    if (valuechange.PhoneNumber != null)
                    {
                        existingdetails.PhoneNumber = valuechange.PhoneNumber;
                    }
                    if (valuechange.Address != null)
                    {
                        existingdetails.Address = valuechange.Address;
                    }
                    if (valuechange.EmailId != null) 
                    {
                        existingdetails.GuestUserDetail.EmailId = valuechange.EmailId;
                    }
                    if (valuechange.Password != null)
                    {
                        existingdetails.Password = valuechange.Password;
                    }
                    if (valuechange.Address == null)
                    {
                        existingdetails.Address = existingdetails.Address;
                    }
                        ue.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }
        // GET: api/DashBoard
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/DashBoard/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/DashBoard
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/DashBoard/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/DashBoard/5
        //public void Delete(int id)
        //{
        //}

    }
}
