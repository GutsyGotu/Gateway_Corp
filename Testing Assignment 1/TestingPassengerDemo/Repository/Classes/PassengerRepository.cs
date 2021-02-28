using TestingPassengerDemo.Models;


using CLPM.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLPM.DAL.Repository.Classes
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly PassengerTestDemo1 _dbContext;
        public PassengerRepository()
        {
            _dbContext = new PassengerTestDemo1();
        }
        public bool PassengerDetailsDelete(string PassengerId)
        {
            try
            {
                var passenger = _dbContext.Passengers.Where(s => (PassengerId.Equals(s.PassengerId.ToString()))).FirstOrDefault();
                if (passenger.FirstName != null)
                {
                    _dbContext.Passengers.Remove(passenger);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public IList<Passenger> getAllPassenger()
        {
            var entities = _dbContext.Passengers.OrderBy(c => c.FirstName).ToList();
            return entities;
        }

        public Passenger getPassengerByPassengerId(string PassengerId)
        {
            var passenger = _dbContext.Passengers.Where(s => (PassengerId.Equals(s.PassengerId.ToString()))).FirstOrDefault();
            return passenger;
        }

        public Passenger PassengerRegistration(Passenger model)
        {
            Passenger passenger = model;
            passenger.PassengerId = Convert.ToInt32(DateTime.Now.Ticks.ToString());
            _dbContext.Passengers.Add(passenger);
            _dbContext.SaveChanges();

            return model;
        }

        public Passenger PassengerDetailsUpdate(Passenger model)
        {

            Passenger passenger = _dbContext.Passengers.Where(s => (model.Equals(s.PassengerId.ToString()))).FirstOrDefault();
            _dbContext.Passengers.Attach(model);
            _dbContext.SaveChanges();
            return model;
        }
    }
}

