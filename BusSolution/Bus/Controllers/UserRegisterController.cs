using Bus.Models;
using BusReservationNProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace BusReservationNProject.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class UserRegisterController : ApiController
    {
        private BusReservationEntities db = new BusReservationEntities();
        // GET: api/JourneyRoutes
        [HttpGet]
        public List<proc_UserRegistration2_Result> Get()
        {
            List<proc_UserRegistration2_Result> list = new List<proc_UserRegistration2_Result>();
            foreach (var item in db.proc_UserRegistration2())
            {
                list.Add(item);

            }
            return list;
        }

        [ResponseType(typeof(RegistrationDetails))]
        [HttpPost]
        public IHttpActionResult PostRegistrationDetails(RegistrationDetails registrationDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.proc_Register(registrationDetails.FirstName, registrationDetails.Lastname, registrationDetails.EmailId, registrationDetails.PhoneNumber,
               registrationDetails.Password, registrationDetails.Gender, registrationDetails.DOB, registrationDetails.Address, registrationDetails.State,
               registrationDetails.City, registrationDetails.Pincode, registrationDetails.SecurityQuestion
                );
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = registrationDetails.UID }, registrationDetails);
        }
    }
}