using Newtonsoft.Json;
using SBS.BAL.Interfaces;
using Service_Booking_System.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Service_Booking_System.Controllers
{
    public class AccountController : Controller
    {
        private IServiceManager _serviceManager;

        public AccountController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginUser)
        {
            if(ModelState.IsValid)
            {
                var result = _serviceManager.AuthenticateUser(loginUser.Email,loginUser.Password);
                if(result != null)
                {
                    Session["user"] = result;
                    Session["name"] = result.Name;
                    Session["id"] = result.Id;
                   
                    return RedirectToAction("UserProfile", "Customer",result);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            
            return RedirectToAction("Index","Home");
        }
    }
}