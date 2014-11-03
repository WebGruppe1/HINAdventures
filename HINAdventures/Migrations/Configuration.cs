namespace HINAdventures.Migrations
{
    using HINAdventures.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
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
        private ApplicationUser createUser(string _username, string password, string _lastname, string _firstname, string _course)
        {
            var user = userManager.FindByName(_username);
            if (user == null)
            {
                user = new ApplicationUser { UserName = _username, Email = _username, LastName = _lastname, FirstName = _firstname, Course = _course };
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
            var userAdmin = createUser("dag@ivarsoyfoto.no", "appelsinFarge5", "Ivarsøy", "Dag", "Datateknikk");
            var userDag = createUser("dagivarsoy@gmail.com", "appelsinFarge5", "Ivarsøy", "Dag", "Datateknikk");
            var userTord = createUser("tord.fredriksen@gmail.com", "appelsinFarge5", "Fredriksen", "Tord", "Datateknikk");
            var userKristian = createUser("kristian.alm83@gmail.com", "appelsinFarge5", "Alm", "Kristian", "Datateknikk");
            var userTommy = createUser("Tomlanghe@gmail.com", "appelsinFarge5", "Langhelle", "Tommy", "Datateknikk");
            var userEivind = createUser("eivind.skreddernes@gmail.com", "appelsinFarge5", "Skreddernes", "Eivind", "Datateknikk");
            var userFrederik = createUser("johnsen16@gmail.com", "appelsinFarge5", "Johnsen", "Frederik", "Datateknikk");


            //Assign roles to users
            SetRole(userAdmin, adminRole);
            SetRole(userDag, userRole);
            SetRole(userTord, userRole);
            SetRole(userKristian, userRole);
            SetRole(userTommy, userRole);
            SetRole(userEivind, userRole);
            SetRole(userFrederik, userRole);
            context.SaveChanges();

            //Seed Descriptions

            var descriptions = new List<Description>
            {
                new Description {
                    Text = "You entered a rather big grouproom with a scarylooking door at the other end. Between you and the scary door there is several worn down chairs and a table."
               },
               new Description {
                   Text = "This place looks like a crime scene, there is a bloody studentcard on the table with a note next to it saying; HELP, IM HIDING IN 3RD FLOOR."
                }
            };
            descriptions.ForEach(element => context.Descriptions.AddOrUpdate(description => description.Text, element));

            context.SaveChanges();

            //Seed Rooms
            var rooms = new List<Room>
            {
                new Room {
                    Name = "D3040"
                },
                new Room {
                    Name = "C3150"  
                },
                new Room {
                    Name = "D3360"
                },
                new Room {
                    Name = "D3015"
                },
                new Room {
                    Name = "C3021"  
                },
                new Room {
                    Name = "D3310"
                },
                new Room {
                    Name = "D3000"
                },
                new Room {
                    Name = "C2060"  
                },
                new Room {
                    Name = "D2330"
                },
                new Room {
                    Name = "D2320"
                },
                new Room {
                    Name = "D2310"  
                },
                new Room {
                    Name = "D2300"
                },
                new Room {
                    Name = "Gangbro"
                },
                new Room {
                    Name = "C3191"  
                },
                new Room {
                    Name = "C3190"
                },
                new Room {
                    Name = "D3510"
                },
                new Room {
                    Name = "D3490"  
                },
                new Room {
                    Name = "D3470"
                },
                new Room {
                    Name = "D2290"
                },
                new Room {
                    Name = "D2980"  
                },
                new Room {
                    Name = "D2390"
                },
                new Room {
                    Name = "D2400"
                },
                new Room {
                    Name = "D2280"  
                },
                new Room {
                    Name = "D2270"
                },
                new Room {
                    Name = "D2340"
                },
                new Room {
                    Name = "D2350"  
                },
                new Room {
                    Name = "D2360"
                },
                new Room {
                    Name = "D2250"
                },
                new Room {
                    Name = "D3460"  
                },
                new Room {
                    Name = "D3450"
                },
                new Room {
                    Name = "D3440"
                },
                new Room {
                    Name = "D3430"  
                },
                new Room {
                    Name = "D3420"
                },
                new Room {
                    Name = "D3410"
                },
                new Room {
                    Name = "D3400"  
                },
                new Room {
                    Name = "D3390"
                },
                new Room {
                    Name = "D3380"
                },
                new Room {
                    Name = "D3370"  
                },
                new Room {
                    Name = "D2260"
                },
                new Room {
                    Name = "D2200"
                },
                new Room {
                    Name = "D2240"  
                },
                new Room {
                    Name = "D2220"
                },
                new Room {
                    Name = "D2210"
                },
                new Room {
                    Name = "D2230"  
                },
            };
            rooms.ForEach(element => context.Rooms.AddOrUpdate(room => room.Name, element));

            context.SaveChanges();
        }
    }
}
