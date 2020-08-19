using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Bus.Models;
using System.Web.Http.Cors;


namespace Bus.Controllers
{
    [EnableCors(origins: "http://localhost:4200",headers:"*",methods:"*")]
    public class JourneyRoutesController : ApiController
    {
        
        private BusReservationEntities db = new BusReservationEntities();

        // GET: api/JourneyRoutes
       //[Route("fetchBuses")]
       [HttpGet]
       [Route("api/fetchbuses")]
       public object showdata()
        {

            var busInfo = db.JourneyRoutes.ToList();
            return busInfo;
        }
        [HttpGet]
        public List<JourneyRoute> BindToLocation(int id)
        {
            IEnumerable<JourneyRoute> location = new List<JourneyRoute>();
            location=db.JourneyRoutes.Where(a => a.TripID == id).ToList();
            //try
            //{
            //    using (BusReservationEntities db = new BusReservationEntities())
            //    {
            //        location = db.JourneyRoutes.Where(a => a.TripID == TripId).ToList();
            //    }
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            return location.ToList();
        }
        //[Route("search")]
        [HttpPost]
        public object search(JourneyRoute journeyinfo)
        {
            //var busInfoPost = db.proc_Bus(journeyinfo.FromLocation, journeyinfo.ToLocation, journeyinfo.FromDate);
            var busInfoPost = db.proc_Buses(journeyinfo.TripID,journeyinfo.FromDate);
            return busInfoPost;
        }
    }
}