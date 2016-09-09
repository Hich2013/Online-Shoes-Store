namespace eCommerce.Migrations
{
    using eCommerce.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<eCommerce.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "eCommerce.Models.ApplicationDbContext";
        }

        protected override void Seed(eCommerce.Models.ApplicationDbContext context)
        {
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);
            var existingUserToDelete = store.Users.SingleOrDefault(c => c.UserName == "Admin");
            manager.Delete(existingUserToDelete);

            //  This method will be called after migrating to the latest version.
            if (!context.Users.Any(u => u.UserName == "Max"))
            {
                var adminUser = new ApplicationUser { UserName = "Max" };
                manager.Create(adminUser, "Password1!");
                context.SaveChanges();
            }
            
            if (!context.Users.Any(u => u.UserName == "Hichem"))
            {
                var adminUser = new ApplicationUser{UserName = "Hichem"};
                manager.Create(adminUser, "Soukou1523");
                context.SaveChanges();
            }
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
