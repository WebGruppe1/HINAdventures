namespace HINAdventures.Migrations
{
    using HINAdventures.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HINAdventures.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        private ApplicationDbContext context;
        private RoleManager<IdentityRole> roleManager;
        private RoleStore<IdentityRole> roleStore;
        private UserManager<ApplicationUser> userManager;
        private UserStore<ApplicationUser> userStore;

        // Creates a new role
        private IdentityRole createRole(string _role)
        {
            var role = roleManager.FindByName(_role);
            if (role == null)
            {
                role = new IdentityRole(_role);
                var roleresult = roleManager.Create(role);
            }
            return role;
        }

        // Creates a new user
        private ApplicationUser createUser(string _username, string password)
        {
            var user = userManager.FindByName(_username);
            if (user == null)
            {
                user = new ApplicationUser { UserName = _username, Email = _username };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }
            return user;
        }

        //Sets a role for a user
        private void SetRole(ApplicationUser user, IdentityRole role)
        {
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }

        protected override void Seed(HINAdventures.Models.ApplicationDbContext _context)
        {

            //Sets context, User and Role store/managers to be used by private methods
            //to create new roles and users
            context = _context;
            roleStore = new RoleStore<IdentityRole>(context);
            roleManager = new RoleManager<IdentityRole>(roleStore);
            userStore = new UserStore<ApplicationUser>(context);
            userManager = new UserManager<ApplicationUser>(userStore);

            //Create Admin and User roles
            var adminRole = createRole("Admin");
            var userRole = createRole("User");

            //Create users
            var userAdmin = createUser("dag@ivarsoyfoto.no", "appelsinFarge5");
            var userDag = createUser("dagivarsoy@gmail.com", "appelsinFarge5");
            var userTord = createUser("tord.fredriksen@gmail.com", "appelsinFarge5");
            var userKristian = createUser("kristian.alm83@gmail.com", "appelsinFarge5");
            var userTommy = createUser("Tomlanghe@gmail.com", "appelsinFarge5");
            var userEivind = createUser("eivind.skreddernes@gmail.com", "appelsinFarge5");
            var userFrederik = createUser("johnsen16@gmail.com", "appelsinFarge5");


            //Assign roles to users
            SetRole(userAdmin, adminRole);
            SetRole(userDag, userRole);
            SetRole(userTord, userRole);
            SetRole(userKristian, userRole);
            SetRole(userTommy, userRole);
            SetRole(userEivind, userRole);
            SetRole(userFrederik, userRole);

            //Seed Descriptions

        }
    }
}
