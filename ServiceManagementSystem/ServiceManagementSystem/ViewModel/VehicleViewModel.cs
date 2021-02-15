using SBS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service_Booking_System.ViewModel
{
    public class VehicleViewModel
    {
        public Vehicle vehicle { get; set; }

        public IEnumerable<Customer> customers { get; set; }

    }
}