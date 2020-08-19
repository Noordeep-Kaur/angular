using Bus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Versioning;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BusReservationNProject.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class TicketDemoController : ApiController
    {
        private BusReservationEntities db = new BusReservationEntities();
        [HttpGet]
        public object fetchinfo(string id)
        {
            var fetch = db.proc_fetchUserId(id);
            return fetch;
        }
        [HttpPost]
        public object insertGuestUserDetail(GuestUserDetail insertvalue)
        {
            var insert = db.proc_insertGuestUserID(insertvalue.FirstName, insertvalue.Lastname, insertvalue.EmailId, insertvalue.PhoneNumber);
            return insert;
        }
    }
}
