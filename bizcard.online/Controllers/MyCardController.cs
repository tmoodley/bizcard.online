using bizcard.online.Models;
using System;
using System.Collections.Generic; 
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using seoWebApplication.Framework;

namespace bizcard.online.Controllers
{
    public class MyCardController : Controller
    { 
        private ApplicationUserManager _userManager;

        public MyCardController()
        {
        }
        public MyCardController(ApplicationUserManager userManager)
        {
            UserManager = userManager; 
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
        // GET: Card
        public ActionResult Index(string id)
        {
            ApplicationUser user;
            using (var db = new ApplicationDbContext()) {
                user = db.Users.FirstOrDefault(x => x.UserId == id);
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ApplicationUser model, string emailToSend)
        {
            var emailToSend2 = emailToSend;
            //send email
            emailSend.SendGrid(emailToSend, "RE: New Contact", "Here is your new contact from Bizcard.Online");
            // Returning the user to the list of users
            return RedirectToAction("Index", "Card");
        }
    }
}