using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Model
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Time { get; set; }
        public bool Active { get; set; }

       
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
