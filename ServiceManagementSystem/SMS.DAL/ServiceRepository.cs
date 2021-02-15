
using SBS.DAL.Context;
using SBS.DAL.Interfaces;
using SBS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL
{
    public class ServiceRepository : IServiceRepository
    {
        private ServiceBookingContext _dbContext;
        public ServiceRepository()
        {
            _dbContext = new ServiceBookingContext();
        }

        public Booking AddBooking(Booking booking)
        {
            try
            {
                if (booking.Id == 0)
                {

                    _dbContext.bookings.Add(booking);
                    _dbContext.SaveChanges();

                    return booking;
                }
                else
                {
                    _dbContext.Entry(booking).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    return booking;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Customer AddUser(Customer customer)
        {

            try
            {
                if (customer != null)
                {
                    if (customer.Id == 0)
                    {
                        _dbContext.customers.Add(customer);
                        _dbContext.SaveChanges();

                        var user = _dbContext.customers.Where(x => x.Email == customer.Email).FirstOrDefault();
                        user.CustomerNo = "U" + user.Id;
                        _dbContext.Entry(user).State = EntityState.Modified;

                        _dbContext.SaveChanges();

                        return user;
                    }
                    else
                    {
                        _dbContext.Entry(customer).State = EntityState.Modified;

                        _dbContext.SaveChanges();
                        return customer;
                    }

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Vehicle AddVehicle(Vehicle vehicle)
        {
            try
            {
                if (vehicle != null)
                {
                    if (vehicle.Id == 0)
                    {
                        _dbContext.vehicles.Add(vehicle);
                        _dbContext.SaveChanges();



                        return vehicle;
                    }
                    else
                    {
                        _dbContext.Entry(vehicle).State = EntityState.Modified;

                        _dbContext.SaveChanges();
                        return vehicle;
                    }

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Customer AuthenticateUser(string email, string password)
        {
            Customer invalidCustomer = null;
            Customer user = _dbContext.customers.Where(x => x.Email == email).FirstOrDefault();
            if (user != null)
            {
                if (user.Password == password)
                {
                    return user;
                }
                return invalidCustomer;
            }
            return invalidCustomer;
        }

        public Customer DeleteCustomer(int id)
        {
            var user = _dbContext.customers.Find(id);
            if (user != null)
            {
                _dbContext.customers.Remove(user);
                _dbContext.SaveChanges();
                return user;
            }
            return null;


        }

        public Vehicle DeleteVehicle(int id)
        {
            var vehicle = _dbContext.vehicles.Find(id);
            if (vehicle != null)
            {
                _dbContext.vehicles.Remove(vehicle);
                _dbContext.SaveChanges();
                return vehicle;
            }
            return null;
        }

        public Booking GetBooking(int id)
        {
            var booking = _dbContext.bookings.Where(b => b.Id == id).FirstOrDefault();
            return booking;
        }

        public List<Booking> GetBookingsByCustomerId(int id)
        {
            var bookingList = _dbContext.bookings.Where(b => b.CustomerId == id).ToList();
            return bookingList;
        }

        public List<Customer> GetCustomers()
        {

            var customerList = _dbContext.customers.ToList();
            List<Customer> sortedList = customerList.OrderBy(o => o.Name).ToList();
            return sortedList;
        }

        public Mechanic GetMechanicByMake(string vehicleMake)
        {
            var mechanic = _dbContext.mechanics.Where(m => m.Make == vehicleMake).FirstOrDefault();
            if (mechanic != null)
            {
                return mechanic;
            }
            return null;
        }

        public string GetName()
        {
            return "Rikin";
        }

        public List<Service> GetServices()
        {
            var serviceList = _dbContext.services.Where(s => s.Active).ToList();
            return serviceList;
        }

        public Customer GetUser(int id)
        {
            var user = _dbContext.customers.Where(x => x.Id == id).FirstOrDefault();
            return user;
        }

        public Vehicle GetVehicle(int id)
        {
            var vehicle = _dbContext.vehicles.Where(x => x.Id == id).FirstOrDefault();
            return vehicle;
        }

        public List<Vehicle> GetVehicles()
        {
            var vehicleList = _dbContext.vehicles.ToList();
            List<Vehicle> sortedList = vehicleList.OrderBy(o => o.LicensePlate).ToList();
            return sortedList;
        }

        public List<Vehicle> GetVehiclesByOwnerId(int id)
        {
            var vehicels = _dbContext.vehicles.Where(v => v.OwnerId == id).ToList();
            return vehicels;
        }
    }
}
