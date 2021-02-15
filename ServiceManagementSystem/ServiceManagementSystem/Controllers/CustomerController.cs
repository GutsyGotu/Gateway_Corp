using SBS.BAL.Interfaces;
using SBS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Service_Booking_System.Controllers
{
    public class CustomerController : Controller
    {
        private IServiceManager _serviceManager;

        public CustomerController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customerList = _serviceManager.GetCustomers();
            return View(customerList);
        }

        public ActionResult AddorEdit(int id=0)
        {
            if(id==0)
            {
                    
                return View();
            }
            else
            {
                var user = _serviceManager.GetUser(id);
                return View(user);
            }
        }

        [HttpPost]
        public ActionResult AddorEdit(Customer customer)
        {
            if(ModelState.IsValid)
            {
                
                var result = _serviceManager.AddUser(customer);
                
                return RedirectToAction("UserProfile",new { id=result.Id});
            }
            return Content("Not added");
        }

        public ActionResult UserProfile(int id)
        {
            var customer = _serviceManager.GetUser(id);
            ViewBag.username = customer.Name;
            return View(customer);
        }

       
        public ActionResult Delete(int id)
        {
           var result= _serviceManager.DeleteCustomer(id);
            if (result != null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}