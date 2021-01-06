using MVCProductMgmtSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProductMgmtSystem.Controllers
{
    public class LoginController : Controller
    {
        AppDBEntities1 db = new AppDBEntities1();

        // GET: Login
            public ActionResult Login() 
            {
                return View(); // Returns the view of Login
            }

            //When user clicks on ''Login', all data comes here
            [HttpPost]
            public ActionResult Login(LoginReg u) //catch the details in object 'u' of class 'LoginReg'
            {
                //It checks that Email id & Password entered are the same as stored in the database
                var LoginReg = db.LoginRegs.Where(model => model.Email == u.Email && model.Password == u.Password).FirstOrDefault();
                if (LoginReg != null) //If 'LoginReg' is not null
                {
                    Session["UserId"] = LoginReg.Id.ToString(); //Auto-incremented Id will be stored in 'UserId'
                    Session["Email"] = LoginReg.Email.ToString(); //Entered E-mail will be stored in 'Email'
                    Session["Name"] = LoginReg.FirstName.ToString() + " " + LoginReg.LastName.ToString();
                    TempData["LoginSuccessMsg"] = "<script>alert('Logged in successfully!')</script>"; //When user is logged in successfully, display this message
                    return RedirectToAction("Dashboard", "Home"); //Redirect the user to 'Dashboard'
                }
                else //If wrong details are inserted
                {
                    ViewBag.ErrorMsg = "<script>alert('Email or Passowrd is invalid!')</script>"; //Display this message
                    return View(); //Return to the view of 'Login'
                }
            }

            //This method is for New User Registration
            public ActionResult Register()
            {
                return View(); // Returns the view of Register
            }

            // When user clicks on 'Register', all data come to 'POST' method
            [HttpPost]
            public ActionResult Register(LoginReg model) // When user clicks on 'Register', all data come to the 'model' object of 'LoginReg' table 

            {
                using (AppDBEntities1 a = new AppDBEntities1())
                {
                    if (a.LoginRegs.Any(x => x.Email == model.Email)) //If any user enters same mail id  
                    {
                        ViewBag.DuplicateMsg = "User already exists!";  //Display USer already exists
                        return View("Register", model); // Returns the view of 'Register'
                    }
                    a.LoginRegs.Add(model); //If new e-mail id is entered, add it to the database
                    a.SaveChanges();
                }
                ModelState.Clear(); //Clears the fileds of 'Register' view
                ViewBag.SuccessMsg = "Registered successfully"; // When user is registered, display this message
                return RedirectToAction("Login"); // Redirect the newly registered user to 'Login'
            }

            //When user is successfully logged in, he will be redirected to 'Dsashboard'
            public ActionResult Dashboard()
            {
                if (Session["UserId"] == null) //When 'UserId' is null 
                {
                    return RedirectToAction("Login", "Login"); //Redirect user to 'Login'
                }
                else
                {
                    return RedirectToAction("Dashboard","Home"); //If all details are correct, Redirect user to 'Dashboard'
                }

            }

            //This method is for 'Logout'
            public ActionResult Logout()
            {
                Session.Abandon(); //Destroy the current active session
                return RedirectToAction("Login", "Login"); //Return the view to 'Login'
            }      
        }
}
