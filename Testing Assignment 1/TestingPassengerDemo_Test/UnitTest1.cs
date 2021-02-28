using System.Collections.Generic;
using System.IO;
using System.Web.Http.Results;
using TestingPassengerDemo.Controllers;
using TestingPassengerDemo.Models;
using CLPM.DAL.Repository.Interface;
using Moq;
using Newtonsoft.Json;
using Xunit;
using System;

namespace CLPM_Test
{
    public class UnitTest1
    {
        private readonly Mock<IPassengerRepository> mockDataRepo = new Mock<IPassengerRepository>();
        private readonly PassengerController _passengerController;

        public UnitTest1()
        {
            _passengerController = new PassengerController(mockDataRepo.Object);
        }

        [Fact]
        public void Test_GetAllPassengers()
        {
            //Arrange
            var resultType = mockDataRepo.Setup(x => x.getAllPassenger()).Returns(getPassengerList());
            //Act
            var response = _passengerController.getAllPassenger();
            //Assert
            Assert.Equal(2, response.Count);
        }

        [Fact]
        public void Test_GetUserById()
        {
            //Arrange
            var passenger = new Passenger();
            passenger.PassengerId = Convert.ToInt32(DateTime.Now.Ticks.ToString());

            var resultType = mockDataRepo.Setup(x => x.getPassengerByPassengerId(passenger.PassengerId.ToString())).Returns(passenger);
            //Act
            var result = _passengerController.GetPassenger(passenger.PassengerId.ToString());
            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_AddPassenger()
        {
            //Arrange
            var newpassenger = new Passenger() { PassengerId = Convert.ToInt32(DateTime.Now.Ticks.ToString()), FirstName = "Meet", LastName = "Shah", PhoneNumber = "9664560601" };
            var response = mockDataRepo.Setup(x => x.PassengerRegistration(newpassenger)).Returns(AddPassenger());
            //Act
            var result = _passengerController.PassengerRegistration(newpassenger);
            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_UpdatePassenger()
        {
            //Act
            var model = JsonConvert.DeserializeObject<Passenger>(File.ReadAllText("Data/UpdatePassenger.json"));
            //Arrange
            var result = mockDataRepo.Setup(x => x.PassengerDetailsUpdate(model)).Returns(model);
            var response = _passengerController.PassengerDetailsUpdate(model);
            //Assert
            Assert.Equal(model, response);
        }

        [Fact]
        public void Test_DeletePassenger()
        {
            //Arrange
            var passenger = new Passenger();
            passenger.PassengerId = Convert.ToInt32(DateTime.Now.Ticks.ToString());
            var resultType = mockDataRepo.Setup(x => x.PassengerDetailsDelete(passenger.PassengerId.ToString())).Returns(true);
            //Act
            var response = _passengerController.PassengerDetailsDelete(passenger.PassengerId.ToString());
            //Assert
            Assert.True(response);
        }

        private static IList<Passenger> getPassengerList()
        {
            IList<Passenger> passengers = new List<Passenger>()
            {
                new Passenger(){PassengerId=Convert.ToInt32(DateTime.Now.Ticks.ToString()),FirstName="Meet",LastName="Shah",PhoneNumber="9664560601"},
                new Passenger(){PassengerId=Convert.ToInt32(DateTime.Now.Ticks.ToString()),FirstName="Meet",LastName="Shah",PhoneNumber="9664560601"}
            };
            return passengers;
        }


        private static Passenger AddPassenger()
        {
            var passenger = new Passenger() { PassengerId = Convert.ToInt32(DateTime.Now.Ticks.ToString()), FirstName = "Meet", LastName = "Shah", PhoneNumber = "9664560601" };
            return passenger;
        }
    }
}
