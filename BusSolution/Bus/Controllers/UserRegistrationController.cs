//using Bus.Models;

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web.Http.Cors;
//using System.Web.Http.Description;

//namespace BusReservationNProject.Controllers
//{
//    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
//    public class UserRegistrationController : ApiController
//    {
//        private BusReservationEntities db = new BusReservationEntities();
//        [ResponseType(typeof(UserDetail))]
//        [HttpPost]
//        public IHttpActionResult PostUserDetail(UserDetail UserDetail, GuestUserDetail GuestUserDetail)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            db.proc_UserRegistration(GuestUserDetail.FirstName, GuestUserDetail.Lastname, GuestUserDetail.EmailId, GuestUserDetail.PhoneNumber,
//                UserDetail.Password, UserDetail.Gender, UserDetail.DOB, UserDetail.Address, UserDetail.State, UserDetail.City, UserDetail.Pincode);
//            db.SaveChanges();

//            return CreatedAtRoute("DefaultApi", new { id = UserDetail.UID }, UserDetail);
//        }

//        public IHttpActionResult PostUserDetail(proc_UserRegistration1_Result userdetail)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            //db.tblUsers.Add(tblUser);
//            db.proc_UserRegistration1();
//            db.SaveChanges();

//            return CreatedAtRoute("DefaultApi", new { id = userdetail.UID }, userdetail);
//        }
//    }
//}