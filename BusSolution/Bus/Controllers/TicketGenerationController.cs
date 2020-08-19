using Bus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bus.Controllers
{
    public class TicketGenerationController : ApiController
    {
        private BusReservationEntities db=new BusReservationEntities();
        [HttpPost]
        public object search(Ticket ticks)
        {
            //var busInfoPost = db.proc_Bus(journeyinfo.FromLocation, journeyinfo.ToLocation, journeyinfo.FromDate);
            var ticketInfo = db.proc_addTicketDetails(ticks.BusID,ticks.BookingUserID,ticks.FromLocation,ticks.ToLocation,
                ticks.FromDate,ticks.ToDate,ticks.FromTime,ticks.ToTime,ticks.NumberOfSeats,ticks.Fare);
            return ticketInfo;

        }
    }
}

