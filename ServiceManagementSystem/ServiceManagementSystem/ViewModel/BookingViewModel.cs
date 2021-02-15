using SBS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service_Booking_System.ViewModel
{
    public class BookingViewModel
    {
        public Booking booking { get; set; }
        public IEnumerable<Service> services { get; set; }
        public IEnumerable<Vehicle> vehicles { get; set; }

    }
}