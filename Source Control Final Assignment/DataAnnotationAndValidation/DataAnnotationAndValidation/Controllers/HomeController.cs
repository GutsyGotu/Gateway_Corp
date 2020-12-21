﻿using DataAnnotationAndValidation.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataAnnotationAndValidation.Controllers
{
    public class HomeController : Controller
    {
        public readonly Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // GET: Home
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                Logger.Fatal(ex);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Details(RegistrationModel sm)
        {
            if (ModelState.IsValid)
            {
                ViewBag.name = sm.Name;
                ViewBag.mobile = sm.Mobile;
                ViewBag.email = sm.Email;
                ViewBag.age = sm.Age;
                return View("Index");
            }
            else
            {
                ViewBag.name = "No Data";
                ViewBag.mobile = "No Data";
                ViewBag.email = "No Data";
                ViewBag.age = "No Data";
                return View("Index");
            }
        }
    }
}