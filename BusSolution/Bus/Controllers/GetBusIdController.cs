using Bus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bus.Controllers
{
    public class GetBusIdController : ApiController
    {
        
        private BusReservationEntities db=new BusReservationEntities();
        //[HttpGet]
        public object getBusId(int id)
        {
            List<proc_getIdOfBus_Result> list = new List<proc_getIdOfBus_Result>();
            foreach( var item in db.proc_getIdOfBus(id))
            {
                list.Add(item);
            }
           return list ;
            
        }
    }
}
