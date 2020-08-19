using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Bus.Models
{
    [DataContract]
    public class EditUser
    {
        [DataMember]
        public string EmailId { get; set; }
        [DataMember]
        public int UID { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public System.DateTime DOB { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public int Pincode { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public int Wallet { get; set; }
        [DataMember]
        public int GuestID { get; set; }
    }
}