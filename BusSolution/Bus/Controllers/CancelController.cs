using Bus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bus.Controllers
{
    public class CancelController : ApiController
    {
        private BusReservationEntities db = new BusReservationEntities();
        [HttpGet]
        public object current(int id)
        {
            var info = db.proc_currentbooking(id);
            return info;
        }
        [HttpPost]
        public object cancel(Ticket ticketinfo)
        {
            var cancelInfoPost = db.proc_cancel(ticketinfo.BookingUserID);
            return cancelInfoPost;
        }
        [HttpPut]
        public IHttpActionResult Put(int id, Ticket valuechange)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ue = new BusReservationEntities())
            {
                var existingdetails = ue.Tickets.Where(p => p.BookingUserID == id).FirstOrDefault<Ticket>();
                if (existingdetails != null)
                {
                    existingdetails.TicketBookingStatus = 0;   
                    ue.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }
        //// GET: api/Cancel
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Cancel/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Cancel
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Cancel/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Cancel/5
        //public void Delete(int id)
        //{
        //}
    }
}
