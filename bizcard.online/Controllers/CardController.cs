using bizcard.online.Models;
using System;
using System.Collections.Generic; 
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bizcard.online.Controllers
{
    public class CardController : Controller
    { 
        private ApplicationUserManager _userManager;

        public CardController()
        {
        }
        public CardController(ApplicationUserManager userManager)
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
            ApplicationUser user = UserManager.FindByNameAsync(User.Identity.Name).Result;
            return View(user);
        }
    }
}