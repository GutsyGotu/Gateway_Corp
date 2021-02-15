using SBS.BAL.Interfaces;
using SBS.DAL.Interfaces;
using SBS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BAL
{
    public class ServiceManager:IServiceManager
    {
        private IServiceRepository _serviceRepository;

        public ServiceManager(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public Booking AddBooking(Booking booking)
        {
            return _serviceRepository.AddBooking(booking);
        }

        public Customer AddUser(Customer customer)
        {
            return _serviceRepository.AddUser(customer);
        }

        public Vehicle AddVehicle(Vehicle vehicle)
        {
            return _serviceRepository.AddVehicle(vehicle);
        }

        public Customer AuthenticateUser(string email, string password)
        {
            return _serviceRepository.AuthenticateUser(email, password);
        }

        public Customer DeleteCustomer(int id)
        {
            return _serviceRepository.DeleteCustomer(id);
        }

        public Vehicle DeleteVehicle(int id)
        {
            return _serviceRepository.DeleteVehicle(id);
        }

        public Booking GetBooking(int id)
        {
            return _serviceRepository.GetBooking(id);
        }

        public List<Booking> GetBookingsByCustomerId(int id)
        {
            return _serviceRepository.GetBookingsByCustomerId(id);
        }

        public List<Customer> GetCustomers()
        {
            return _serviceRepository.GetCustomers();
        }

        public Mechanic GetMechanicByMake(string vehicleMake)
        {
            return _serviceRepository.GetMechanicByMake(vehicleMake);
        }

        public string GetName()
        {
            return _serviceRepository.GetName();
        }

        public List<Service> GetServices()
        {
            return _serviceRepository.GetServices();
        }

        public Customer GetUser(int id)
        {
            return _serviceRepository.GetUser(id);
        }

        public Vehicle GetVehicle(int id)
        {
            return _serviceRepository.GetVehicle(id);
        }

        public List<Vehicle> GetVehicles()
        {
            return _serviceRepository.GetVehicles();
        }

        public List<Vehicle> GetVehiclesByOwnerId(int id)
        {
            return _serviceRepository.GetVehiclesByOwnerId(id);
        }
    }
}
