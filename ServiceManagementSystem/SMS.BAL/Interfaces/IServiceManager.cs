using SBS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BAL.Interfaces
{
    public interface IServiceManager
    {
        string GetName();

        List<Customer> GetCustomers();
        Customer AddUser(Model.Customer customer);
        Customer AuthenticateUser(string email, string password);
        Customer GetUser(int id);
        List<Vehicle> GetVehicles();
        List<Service> GetServices();
        Vehicle AddVehicle(Vehicle vehicle);
        Vehicle GetVehicle(int id);
        List<Vehicle> GetVehiclesByOwnerId(int id);
        Vehicle DeleteVehicle(int id);
        Customer DeleteCustomer(int id);
        List<Booking> GetBookingsByCustomerId(int id);
        Booking AddBooking(Booking booking);
        Booking GetBooking(int id);
        Mechanic GetMechanicByMake(string vehicleMake);
    }
}
