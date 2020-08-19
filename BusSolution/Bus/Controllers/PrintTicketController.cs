using Bus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bus.Controllers
{
    public class PrintTicketController : ApiController
    {
        private BusReservationEntities db = new BusReservationEntities();
        [HttpPost]
        public object TicketPrint(Ticket ticket)
        {
            var count = db.proc_TicketDetails(ticket.BookingUserID);
            return count;
        }

    }
}
