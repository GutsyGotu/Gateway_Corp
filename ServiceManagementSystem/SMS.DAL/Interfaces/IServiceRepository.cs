using SBS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Interfaces
{
    public interface IServiceRepository
    {
        string GetName();
        List<Model.Customer> GetCustomers();
        Customer AddUser(Customer customer);
        Customer AuthenticateUser(string email, string password);
        Customer GetUser(int id);
        Vehicle AddVehicle(Vehicle vehicle);
        Vehicle GetVehicle(int id);
        List<Vehicle> GetVehicles();
        List<Vehicle> GetVehiclesByOwnerId(int id);
        Booking AddBooking(Booking booking);
        Customer DeleteCustomer(int id);
        Vehicle DeleteVehicle(int id);
        List<Booking> GetBookingsByCustomerId(int id);
        List<Service> GetServices();
        Booking GetBooking(int id);
        Mechanic GetMechanicByMake(string vehicleMake);
    }
}
