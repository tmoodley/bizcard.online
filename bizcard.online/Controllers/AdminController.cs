using bizcard.online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using seoWebApplication.Framework;
using bizcard.online.Framework;

namespace bizcard.online.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AdminController()
        {
        }

        public AdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Dashboard
        public ActionResult Index()
        {
            ApplicationUser user = UserManager.FindByNameAsync(User.Identity.Name).Result;
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string emailToSend)
        {
            ApplicationUser user = UserManager.FindByNameAsync(User.Identity.Name).Result;
            var template = TemplateService.SendBizCard(user);
            //send email
            emailSend.SendGrid(emailToSend, "RE: Bizcard from " + user.FirstName + " " + user.LastName, template);
            // Returning the user to the list of users
            return RedirectToAction("Index", "Admin");
        }
    }
}