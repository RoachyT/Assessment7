using Put_me_on_the_list_chief.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Put_me_on_the_list_chief.Controllers
{
    public class DatabaseController : Controller
    {
        // GET: Database
        public ActionResult Index()
        {
            PartyDBEntities ORM = new PartyDBEntities();
            ViewBag.GuestList = ORM.Guests.ToList();
            return View();
        }
        public ActionResult DishIndex()
        {
            PartyDBEntities ORM = new PartyDBEntities();
            ViewBag.DishList = ORM.Dishes.ToList();
            return View();
        }
        public ActionResult BringDish()
        {
            return View();
        }
        public ActionResult AddGuest()
        {
            return View();
        }
        public ActionResult SaveNewDish(Dish newDish)
        {
            PartyDBEntities ORM = new PartyDBEntities();
            List<Dish> dishes = ORM.Dishes.Where(
               c => c.PersonName.Contains(newDish.DishName)
               &&
               c.PersonName.Contains(newDish.PersonName)).ToList();

            if (dishes.Count() == 0 && newDish.PersonName != null)
            {
                ORM.Dishes.Add(newDish);
                ORM.SaveChanges();
            }
            else
            {

                newDish = ORM.Dishes.First(c => c.PersonName.Contains(newDish.DishName)
                   &&
                   c.PersonName.Contains(newDish.PersonName));
            }
          

            return RedirectToAction("DishIndex");
        }
        public ActionResult SaveNewGuest(Guest newGuest)
        {
            PartyDBEntities ORM = new PartyDBEntities();
            List<Guest> guests = ORM.Guests.Where(c => c.LastName.Contains(newGuest.LastName)
               &&
               c.FirstName.Contains(newGuest.FirstName)).ToList();
            if (guests.Count() == 0 && newGuest.LastName != null)
            {
                ORM.Guests.Add(newGuest);
                ORM.SaveChanges();
            }
            else
            {

                newGuest = ORM.Guests.First(c => c.LastName.Contains(newGuest.LastName)
                   &&
                   c.FirstName.Contains(newGuest.FirstName));
            }
            return RedirectToAction("Index");
        }
       
        public ActionResult EditGuest(int GuestID)
        {
            PartyDBEntities ORM = new PartyDBEntities();
            Guest found = ORM.Guests.Find(GuestID);
            return View(found);
        }
        public ActionResult EditDish(int DishID)
        {
            PartyDBEntities ORM = new PartyDBEntities();
            Dish found = ORM.Dishes.Find(DishID);
            return View(found);
        }
        public ActionResult SaveGuestChanges(Guest updatedGuest)
        {
            PartyDBEntities ORM = new PartyDBEntities();
            Guest oldGuest = ORM.Guests.Find(updatedGuest.GuestID);
            oldGuest.FirstName = updatedGuest.FirstName;
            oldGuest.LastName = updatedGuest.LastName;
            oldGuest.AttendanceDate = updatedGuest.AttendanceDate;
            oldGuest.EmailAddress = updatedGuest.EmailAddress;
            oldGuest.Guest1 = updatedGuest.Guest1;
            oldGuest.Attending = updatedGuest.Attending;

            ORM.Entry(oldGuest).State = System.Data.Entity.EntityState.Modified;
            ORM.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SaveDishChanges(Dish updatedDish)
        {
            PartyDBEntities ORM = new PartyDBEntities();
            Dish oldDish = ORM.Dishes.Find(updatedDish.DishID);
            oldDish.PersonName = updatedDish.PersonName;
            oldDish.PhoneNumber = updatedDish.PhoneNumber;
            oldDish.DishName = updatedDish.DishName;
            oldDish.DishDescription = updatedDish.DishDescription;
           

            ORM.Entry(oldDish).State = System.Data.Entity.EntityState.Modified;
            ORM.SaveChanges();
            return RedirectToAction("DishIndex");

        }
        public ActionResult DeleteGuest(int GuestID)
        {
            PartyDBEntities ORM = new PartyDBEntities();
            Guest found = ORM.Guests.Find(GuestID);
            ORM.Guests.Remove(found);
            ORM.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DeleteDish(int DishID)
        {
            PartyDBEntities ORM = new PartyDBEntities();
            Dish found = ORM.Dishes.Find(DishID);
            ORM.Dishes.Remove(found);
            ORM.SaveChanges();
            return RedirectToAction("DishIndex");

        }




    }
}