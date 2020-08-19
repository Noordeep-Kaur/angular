using Bus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BusReservationNProject.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class FetchGIDController : ApiController
    {
        private BusReservationEntities db = new BusReservationEntities();
        [HttpPost]
        public int FetchUser(GuestUserDetail email)
        {
            List<proc_fetchUserId_Result> information = new List<proc_fetchUserId_Result>();
            foreach (var item in db.proc_fetchUserId(email.EmailId))
            {
                information.Add(item);
            }
               
            return information[0].GID;

        }
    }
}
