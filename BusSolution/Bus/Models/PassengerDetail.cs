//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bus.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PassengerDetail
    {
        public int PNR { get; set; }
        public string PassengerName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int SeatNumber { get; set; }
        public bool BookingStatus { get; set; }
    
        public virtual Ticket Ticket { get; set; }
    }
}
