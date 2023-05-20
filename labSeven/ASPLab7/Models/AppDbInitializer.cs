using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPLab7.Models
{
    public class AppDbInitializer:DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var admin = new IdentityRole { Name = "Administrator" };
            var emp = new IdentityRole { Name = "Employer" };
            var guest = new IdentityRole { Name = "Guest" };
            var adminuser = new ApplicationUser { Email = "admin@belstu.by", UserName = "admin@belstu.by" };
            var empuser = new ApplicationUser { Email = "emp@belstu.by", UserName = "emp@belstu.by" };
            var guestuser = new ApplicationUser { Email = "guest@belstu.by", UserName = "guest@belstu.by" };
            var super = new ApplicationUser { Email = "super@belstu.by", UserName = "super@belstu.by" };
            roleManager.Create(admin);
            roleManager.Create(emp);
            roleManager.Create(guest);
            userManager.Create(adminuser,"qweqwe");
            userManager.Create(empuser,"qweqwe");
            userManager.Create(guestuser,"qweqwe");
            userManager.Create(super,"qweqwe");

            userManager.AddToRole(adminuser.Id, admin.Name);
            userManager.AddToRole(empuser.Id, emp.Name);
            userManager.AddToRole(guestuser.Id, guest.Name);


            userManager.AddToRole(super.Id, admin.Name);
            userManager.AddToRole(super.Id, emp.Name);
            userManager.AddToRole(super.Id, guest.Name);
            base.Seed(context);
        }
    }
}