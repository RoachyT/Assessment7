
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Put_me_on_the_list_chief.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
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
       
        [HttpPost]
        public ActionResult Confirmation(string FirstName, string LastName, string partyDate, string Email, string GuestFirstName, string GuestLastName)
        {
            if (true)
            {

            }
            ViewBag.ConfirmName = "Name: " + FirstName + " " + LastName;
            ViewBag.ConfirmDate = "Date of attendance: " + partyDate;
            ViewBag.ConfirmGuest = "Guest: " + GuestFirstName + " " + GuestLastName;
            ViewBag.ConfirmEmail = "Email: " + Email;
            return View();
        }
        [HttpPost]
        public ActionResult ConfirmDish(string FirstName, string LastName, string Dish, string Description)
        {
            ViewBag.ConfirmName = "Name: " + FirstName + " " + LastName;
            ViewBag.ConfirmDish = "Dish to pass: " + Dish;
            ViewBag.Description = "Description: " + Description;

            return View();
        }
        public ActionResult Attending()
        {
            return View();
        }
        public ActionResult NotAttending()
        {
            return View();
        }


    }
}