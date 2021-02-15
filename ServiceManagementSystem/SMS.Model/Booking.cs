using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Model
{
    public class Booking
    {

        public int Id { get; set; }
        [Display(Name ="service")]
        public int ServiceId { get; set; }
        public int CustomerId { get; set; }
        public Nullable<int> MechanicId { get; set; }
        [Display(Name = "Vehicle")]
        public int VehicleId { get; set; }
        [Display(Name = "Booking Start Date")]
        public System.DateTime BookingStart { get; set; }
        [Display(Name = "booking End Date")]
        public System.DateTime BookingEnd { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedOn { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Mechanic Mechanic { get; set; }
        public virtual Service Service { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
