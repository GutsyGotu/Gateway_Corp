using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Model
{
    public class Vehicle
    {
        public int Id { get; set; }
        [Display(Name = "License Plate")]
        public string LicensePlate { get; set; }
        [Display(Name = "Brand")]
        public string Make { get; set; }
        public string Model { get; set; }
        [Display(Name = "Chasis Number")]
        public string ChasisNo { get; set; }
        [Display(Name = "Registration date")]
        public DateTime RegistrationDate { get; set; }
        [Display(Name = "Owner")]
        public int OwnerId { get; set; }

       
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
