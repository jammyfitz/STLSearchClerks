//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace STLSearchClerks.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DoubleBooking
    {
        public int DoubleBookingId { get; set; }
        public System.DateTime BookingDate { get; set; }
        public int SearchClerkId { get; set; }
        public int AuthorityId { get; set; }
    
        public virtual Authority Authority { get; set; }
        public virtual SearchClerk SearchClerk { get; set; }
    }
}
