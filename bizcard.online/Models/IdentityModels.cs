using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace bizcard.online.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    { 
        public string Bio { get; set; }
        public string PersonalLink { get; set; }
        [Display(Name = "User Id")]
        public string UserId { get; set; }
        [Display(Name = "BusinessEmail")]
        public string BusinessEmail { get; set; }
        public string ImageName { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        public string Country { get; set; }
        [Display(Name = "Direct Number")]
        public string DirectNumber { get; set; }
        [Display(Name = "Fax Phone")]
        public string FaxNumber { get; set; }
        [Display(Name = "Business Number")]
        public string BusinessNumber { get; set; }
        public string Website { get; set; }
        public string Title { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DbConnectionString", throwIfV1Schema: false)
        {
        }

        public DbSet<Cards> Cards { get; set; }
        public DbSet<AssignedCards> AssignedCards { get; set; } 

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}