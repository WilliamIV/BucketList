using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
namespace BucketList.Models
{

    public class ApplicationUser : IdentityUser
    {
        
        public override string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        

        
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
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            }

            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }

            public System.Data.Entity.DbSet<BucketList.Models.Shopping> Shoppings { get; set; }

            public System.Data.Entity.DbSet<BucketList.Models.Restaurants> restaurants { get; set; }

            public System.Data.Entity.DbSet<BucketList.Models.Museum> museums { get; set; }

            public System.Data.Entity.DbSet<BucketList.Models.Entertainment> entertainments { get; set; }

            public System.Data.Entity.DbSet<BucketList.Models.Sports> sports { get; set; }

            public System.Data.Entity.DbSet<BucketList.Models.EntertainmentType> EntertainmentTypes { get; set; }

            public System.Data.Entity.DbSet<BucketList.Models.MuseumType> MuseumTypes { get; set; }

            public System.Data.Entity.DbSet<BucketList.Models.RestraurantType> RestraurantTypes { get; set; }

            public System.Data.Entity.DbSet<BucketList.Models.ShoppingType> ShoppingTypes { get; set; }

            public System.Data.Entity.DbSet<BucketList.Models.SportsType> SportsTypes { get; set; }

        public System.Data.Entity.DbSet<BucketList.Models.UserList> UserLists { get; set; }

        public System.Data.Entity.DbSet<BucketList.Models.ListCategory> ListCategories { get; set; }

        //public System.Data.Entity.DbSet<BucketList.Models.UserList> UserLists { get; set; }

        //public System.Data.Entity.DbSet<BucketList.Models.ApplicationUser> ApplicationUsers { get; set; }







    }
   
}