using Newtonsoft.Json;
using SBS.BAL.Interfaces;
using SBS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Service_Booking_System.Controllers
{
    public class HomeController : Controller
    {
        private IServiceManager _serviceManager;
        public HomeController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public ActionResult Index()
        {
            if(Session["user"]!=null)
            {
                var customer = (Customer)Session["user"];
                ViewBag.username = customer.Name;
            }
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}