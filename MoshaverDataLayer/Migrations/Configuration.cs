namespace MoshaverDataLayer.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using MoshaverhAmlak.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MoshaverhAmlak.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "MoshaverDataLayer.Context.ApplicationDbContext";
        }

        protected override void Seed(MoshaverhAmlak.Models.ApplicationDbContext context)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "User"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "User" };

                manager.Create(role);
            }


            if (!UserManager.Users.Any(u => u.UserName == "infomoshaverehamlak@gmail.com"))
            {
                var user = new ApplicationUser
                {
                    UserName = "infomoshaverehamlak@gmail.com",
                    Email = "infomoshaverehamlak@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "0123456789",
                    PhoneNumberConfirmed = true
                };

                UserManager.Create(user, "amlak12345678M@");
                UserManager.AddToRole(user.Id, "Admin");

            }
        }

    }

}
