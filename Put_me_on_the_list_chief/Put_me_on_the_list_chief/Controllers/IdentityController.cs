using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Put_me_on_the_list_chief.Models;
using System.Threading.Tasks;


namespace Put_me_on_the_list_chief.Controllers
{
    public class IdentityController : Controller
    {

        public UserManager<IdentityUser> UserManager => HttpContext.GetOwinContext().Get<UserManager<IdentityUser>>();

        // GET: Identity
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegistrationModel registerUser)
        {
            if (ModelState.IsValid)
            {
                var IdentityResult = await UserManager.CreateAsync(new IdentityUser(registerUser.Email), registerUser.Password);


                if (IdentityResult.Succeeded)
                {
                    PartyDBEntities ORM = new PartyDBEntities();
                    var newUser = new Guest();
                    newUser.EmailAddress = registerUser.Email;
                    newUser.FirstName = registerUser.FirstName;
                    newUser.LastName = registerUser.LastName;

                    ORM.Guests.Add(newUser);
                    ORM.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", IdentityResult.Errors.FirstOrDefault());
                return View();
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                IdentityUser user = UserManager.Find(loginModel.Email, loginModel.Password);
                if (user !=null)

                {
                    var ident = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    authenticationManager.SignIn(
                        new AuthenticationProperties{ IsPersistent = false}, ident);
                    return RedirectToAction("Index", "Home");

                }
            }
            ModelState.AddModelError("", "Invalid login");
            return View();

        }
    }
}