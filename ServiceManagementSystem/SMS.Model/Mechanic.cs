using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Model
{
    public class Mechanic
    {
        public int Id { get; set; }
        public string MechanicNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Make { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
