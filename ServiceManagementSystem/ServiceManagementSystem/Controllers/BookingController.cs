using SBS.BAL.Interfaces;
using SBS.Model;
using Service_Booking_System.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Service_Booking_System.Controllers
{
    public class BookingController : Controller
    {
        private IServiceManager _serviceManager;
    

        public BookingController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
           
        }
        
    // GET: Booking
    public ActionResult Index()
        {
            if(Session["user"]!=null)
            {
                var customer = (Customer)Session["user"];
                var bookingList = _serviceManager.GetBookingsByCustomerId(customer.Id);
                return View(bookingList);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AddorEdit(int id=0)
        {
            
            if (Session["user"] != null)
            {
                var customer = (Customer)Session["user"];
                if (id==0)
                {
                    var services = _serviceManager.GetServices();
                    var vehicles = _serviceManager.GetVehiclesByOwnerId(customer.Id);
                    var bookingViewModel = new BookingViewModel
                    {
                        booking = new Booking(),
                        services = services,
                        vehicles = vehicles
                    };
                    return View(bookingViewModel);
                }
                else
                {
                    var services = _serviceManager.GetServices();
                    var vehicles = _serviceManager.GetVehiclesByOwnerId(customer.Id);
                    var booking = _serviceManager.GetBooking(id);
                    var bookingViewModel = new BookingViewModel
                    {
                        booking = booking,
                        services = services,
                        vehicles = vehicles
                    };
                    return View(bookingViewModel);
                }
                
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult AddorEdit(Booking booking)
        {
            if(ModelState.IsValid && Session["user"]!=null)
            {
                var customer = (Customer)Session["user"];
                booking.CustomerId = customer.Id;
                booking.CreatedBy = customer.Name;
                booking.CreatedOn = DateTime.Now;
                booking.UpdatedBy = customer.Name;
                booking.UpdatedOn = DateTime.Now;

                var vehicle = _serviceManager.GetVehicle(booking.VehicleId);
                var vehicleMake = vehicle.Make;
                var mechanic = _serviceManager.GetMechanicByMake(vehicleMake);
                if(mechanic != null)
                {
                    booking.MechanicId = mechanic.Id;
                }
                var result = _serviceManager.AddBooking(booking);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}