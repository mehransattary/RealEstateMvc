using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MoshaverDataLayer.Model;

namespace MoshaverhAmlak.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string name) : base(name) { }
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("AmlakConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<City> Cityes { get; set; }
        public DbSet<Melk> Melks { get; set; }
        public DbSet<TypeCustumer> TypeCustumers { get; set; } 
        public DbSet<TypeGardad> TypeGardads { get; set; }
        public DbSet<TypeMahdode> TypeMahdodes { get; set; }
        public DbSet<TypeMelk> TypeMelks { get; set; }
        public DbSet<TypeSanad> TypeSanads { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Menu> Menues { get; set; }
        public DbSet<ZirMenu> ZirMenues { get; set; }
        public DbSet<ItemMenu> ItemMenues { get; set; }
        public DbSet<Setting> settings { get; set; }
        public DbSet<Slider> sliders { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Advertise> Advertises { get; set; }
        public DbSet<UsualQuestion> UsualQuestions { get; set; }
        public DbSet<Comment> Comments { get; set; }

        //public System.Data.Entity.DbSet<MoshaverhAmlak.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<MoshaverhAmlak.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}