using SBS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Context
{
    public class ServiceBookingContext:DbContext
    {
        public DbSet<Dealer> dealers { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Vehicle> vehicles { get; set; }
        public DbSet<Mechanic> mechanics { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<Booking> bookings { get; set; }

    }
}
