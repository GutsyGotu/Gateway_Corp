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
    public class VehicleController : Controller
    {
        private IServiceManager _serviceManager;

        public VehicleController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        // GET: Vehicle
        public ActionResult Index()
        {
            if(Session["user"]!=null)
            {
                var customer = (Customer)Session["user"];
                var vehicleList = _serviceManager.GetVehiclesByOwnerId(customer.Id);
                return View(vehicleList);
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult AddorEdit(int id = 0)
        {
            
            if (id == 0)
            {
                
                
                return View();
            }
            else
            {
                var vehicle = _serviceManager.GetVehicle(id);
               
                return View(vehicle);
            }
        }

        [HttpPost]
        public ActionResult AddorEdit(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                var customer = (Customer)Session["user"];
                vehicle.OwnerId = customer.Id;
                var result = _serviceManager.AddVehicle(vehicle);
               
                return RedirectToAction("VehicleProfile", new { id= result.Id});
            }
            return Content("Not added");
        }

        public ActionResult VehicleProfile(int id)
        {
            var vehicle = _serviceManager.GetVehicle(id);
            return View(vehicle);
        }

        public ActionResult Delete(int id)
        {
            var result = _serviceManager.DeleteVehicle(id);
            if(result!=null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}