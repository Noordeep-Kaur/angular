using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Bus.Models
{
    [DataContract]
    public class Cancel
    {
        [DataMember]
        public int BookingUserID { get; set; }
        [DataMember]
        public int TicketBookingStatus { get; set; }
    }
}