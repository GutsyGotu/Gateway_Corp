
using TestingPassengerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLPM.DAL.Repository.Interface
{
 public   interface IPassengerRepository
    {
        Passenger PassengerRegistration(Passenger model);
        Passenger PassengerDetailsUpdate(Passenger model);
        Boolean PassengerDetailsDelete(String PassengerId);
        IList<Passenger> getAllPassenger();
        Passenger getPassengerByPassengerId(String PassengerId);

    }
}
