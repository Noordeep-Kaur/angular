using Bus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bus.Controllers
{
    public class PreviousController : ApiController
    {
        private BusReservationEntities db = new BusReservationEntities();
        [HttpGet]
        public object current(int id)
        {
            var info = db.proc_previous(id);
            return info;
        }
    }
}
