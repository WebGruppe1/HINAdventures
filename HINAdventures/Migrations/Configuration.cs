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

            
            //Seed Rooms
            var rooms = new List<Room>
            { new Room {
                    Name = "B3200",
                    OutsideDescription = "You see a door labeled 'B3200'",
                    Description = "You entered a rather big grouproom with a scarylooking door at the other end. Between you and the scary door there is several worn down chairs and a table."
                },
                new Room {
                    Name = "C2070",
                    OutsideDescription = "You see a door labeled 'C2070'",
                    Description = "This place looks like a crime scene, there is a bloody studentcard on the table with a note next to it saying; HELP, IM HIDING IN 3RD FLOOR."
                },
                new Room {
                    Name = "D3330",
                    OutsideDescription = "You see a door labeled 'D3330'",
                    Description = "You enter a big room with a lot computers where there is a dark person sitting in the back staring intensingly at the screen with quick moment inside his clothes, and a couple of students fighting over which is best between apple and android/Windows."

                },
                
                new Room {
                    Name = "D2090",
                    OutsideDescription = "You see a door labeled 'D2090'",
                    Description = "This room is the most boring one I've been in so far. No drama, no blood, , no nothing. There is a fire extinguisher in the corner tho, can this be used to ruin the cleaninglady's day?"

                }, new Room {
                    Name = "C2000",
                    OutsideDescription = "You see a door labeled 'C2000'",
                    Description = "you enter the stairs that leads up to the 3. floor, just walk straight forward to it.",
                },
                new Room {
                    Name = "D3320",
                    OutsideDescription = "You see a door labeled 'D3320'",
                    Description = "you enter a medium size room where a black hole appears and small aliens come marshing out of it on by one and is dancing a Hula Hula- dance and march back into the black hole."
                },
                new Room {
                    Name = "C2100",
                    OutsideDescription = "You see a door labeled 'C2100'",
                    Description = "is a big dark grouproom where a black prosche 911 stands that you dont really see."

                },
                new Room {
                    Name = "C2080",
                    OutsideDescription = "You see a door labeled 'C2080'",
                    Description = "Welcome to the ventilation room, the ventilation for your whole world is here, becareful not to mess it up, then it could start a chain raction to drastic changes on the temrature, either it goes up or down."

                },
                new Room {
                    Name = "D3340",
                    OutsideDescription = "You see a door labeled 'D3340'",
                    Description = "you enter a room where the new EL engineers gets their lecture from a teacher about their study and where it is decided where they are going to go after the study, either they get into production in room D3350, or workshop asa repairment in room D3360 or as a fighter in C3150."

                },
                new Room {
                    Name = "D3350",
                    OutsideDescription = "You see a door labeled 'D3350'",
                    Description = "enter a room where each player from D3340 have a tech group try to evolve more and more powerful taser gun and other elctrical weapons for them. by the door where you standing is a table where several coffee machines stands with a lot of cups as well to keep them awake. each group has it own section which is hidden from the other groups so they cant see what they do. there is a test target as well where you can test their weapon and measure how powerful their weapons and accuracy. "

                },
                new Room {
                    Name = "D3050",
                    OutsideDescription = "You see a door labeled 'D3050'",
                    Description = "you have enter the womens bathroom, is two cubicles for two toilets where shit gets done. there is a broken mirror over a filthy wash which and on the wall right in front of you. the wall that is to the left of you is covered in red sticky mass with a figur that looks like a man which is the nly place on the wall that is not covered."

                },
                new Room {
                    Name = "D3040",
                    OutsideDescription = "You see a door labeled 'D3040'",
                    Description = "The room is totaly empty. It looks like it is being redorated, as the paint on the walls is still damp"
                },
                new Room {
                    Name = "C3150",
                    OutsideDescription = "You see a door labeled 'D3150'",
                    Description = "The room for the EL engineers where they are playing call of duty with taser guns with high voltage. may lead too deaths sometimes, and then they just throw it out of the window and continue. and there are a whiteboard where all the fallen brother names are written and score point."
                },
                new Room {
                    Name = "D3360",
                    OutsideDescription = "You see a door labeled 'D3360'",
                    Description = "The workshop for EL engineers, where they keep all the weapons when they are not fighting and repairing all the taser guns."

                },
                new Room {
                    Name = "D3015",
                    OutsideDescription = "You see a door labeled 'D3015'",
                    Description = "a secret room with no doors. and it is completly emtpy except for one thing, it is a closet. the closet to narnia. when you open it, it will be a 50\" HD LCD 3D tv where you can watch what happens in narnia."

                },
                new Room {
                    Name = "C3021",
                    OutsideDescription = "You see a door labeled 'C3021'",
                    Description = "you enter a small empty hallway that leads from the main allway to room C3150 where tazer gun fights is arranged between EL engineers, further in is D3360 where their workshop is. if you come from C3150 next door leads to C3020 main hallway"

                },
                new Room {
                    Name = "C3020",
                    OutsideDescription = "You see a door labeled 'C3020'",
                    Description = "you enter the main hallway"

                },
                new Room {
                    Name = "D3310",
                    OutsideDescription = "You see a door labeled 'D3310'",
                    Description = "an small empty hallway that leads to 3 room, in one door is to the main hallway C3020, or to the the class room for EL engineers D3340 or for comunter engineers D3320."
                },
                new Room {
                    Name = "D3000",
                    OutsideDescription = "You see a door labeled 'D3000'",
                    Description = "you enter the stairs that leads down to the second floor just walk straight ahead."
                },
                new Room {
                    Name = "C2060",
                    OutsideDescription = "You see a door labeled 'C2060'", 
                    Description = "In this small group room you see three chairs and some small tables. On one of the tables you see a phone. Suddenly the phone starts ringing."
                },
                new Room {
                    Name = "D2330",
                    OutsideDescription = "You see a door labeled 'D2330'",
                    Description = "A zombie is walking against you and will try to eat you."
                },
                new Room {
                    Name = "D2320",
                    OutsideDescription = "You see a door labeled 'D2320'",
                    Description = "In this room Rune is starring at the computer. His hands goes wild on the keyboard. On the wall there is just a white colored wall. Nothing is happening. Everything is silent,Rune is not responding."
                },
                new Room {
                    Name = "D2310",
                    OutsideDescription = "You see a door labeled 'D2310'",
                    Description = "The door is opening and you hear some loud noises. The lights goes wild and the floor is moving. In the background you hear the soundtrack \"Gangnam style\" and you see Jostein is dancing to it."
                },
                new Room {
                    Name = "D2300",
                    OutsideDescription = "You see a door labeled 'D2300'",
                    Description = "This office is no ordinary office. You are expected a teacher sitting on the computer doing stuff, but instead you see a chest on the table. It could be locked or it could be open. You should find out."
                },
                new Room {
                    Name = "D2370",
                    OutsideDescription = "You see a door labeled 'D2370'",
                    Description = "The door is locked, maybe you find a key around or meet someone who has it?"
                },
                new Room {
                    Name = "Gangbro",
                    OutsideDescription = "You see a door labeled 'Gangbro'",
                    Description = "- You shall not pass! Seems like Gandalf has mistaken you for being Balrog."
                },
                new Room {
                    Name = "C3191",
                    OutsideDescription = "You see a door labeled 'D3191'",
                    Description = "You see a long hallwalk in front of you with the walls covered in educational posters, maybe you find something useful? In case of sudden laziness there is a fancy couch in the corner too."
                },
                new Room {
                    Name = "C3190",
                    OutsideDescription = "You see a door labeled 'C3190'",
                    Description = "Mustafa quickly puts away his rubix cube and pretend to be busy with work as soon as he sees you."
                },
                new Room {
                    Name = "D3510",
                    OutsideDescription = "You see a door labeled 'D3510'",
                    Description = "You enter a completely dark room where a depressed guy is sitting on a clearly uncomfortable chair in the corner. He is really jealous of the guy in the neighbour room since he got both his name on the door and twice as big room."
                },
                new Room {
                    Name = "D3490",
                    OutsideDescription = "You see a door labeled 'D3490'",
                    Description = "This is by far the nicest office you've seen so far! It's really big and got huge windows in all directions that makes it easy to stare unnoticed at the goodlooking coworkers. Lucky Audrey, lucky."
                },
                new Room {
                    Name = "D3470",
                    OutsideDescription = "You see a door labeled 'D3470'",
                    Description = "This room looks a lot like the room next door. these two empolyees clearly got something to blackmail the boss with. Anette is denying every accusations of this, ofcourse."
                },
                new Room {
                    Name = "D2290",
                    OutsideDescription = "You see a door labeled 'D2290'",
                    Description = "This room is dark, the monitor is black. You only see the standby light on the computer blinking. Maybe Helge is away or went home for the day."
                },
                new Room {
                    Name = "D2380",
                    OutsideDescription = "You see a door labeled 'Toilet'",
                    Description = "You just found the toilet, maybe you want to use it?"
                },
                new Room {
                    Name = "D2390",
                    OutsideDescription = "You see a door labeled 'Toilet'",
                    Description = "You just found the toilet, maybe you want to use it?"
                },
                new Room {
                    Name = "D2400",
                    OutsideDescription = "You see a door labeled 'D2400'",
                    Description = "This hallway you have a door in the end and two doors that are going somewhere."
                },
                new Room {
                    Name = "D2280",
                    OutsideDescription = "You see a door labeled 'D2280'",
                    Description = "This is no ordinary office. It is much bigger than all others. Bjørn is sitting like a king, drinking his coffie and looking alive. He look right at you and is wondering if you need something or are you looking for something?"
                },
                new Room {
                    Name = "D2270",
                    OutsideDescription = "You see a door labeled 'D2270'",
                    Description = "As the door is opening, you smell a very sweet parfume. The window is covered with curtains. Behind the desk, you see Wenche is sitting or working or something. She got a cup of tea on her desk, that she is drinking. "
                },
                new Room {
                    Name = "D2340",
                    OutsideDescription = "You see a door labeled 'D2340'",
                    Description = "At the end of this room, there is a door. In the room you see a copy machine that is in use, stapler and many sheets. Somebody is using the copy machine, but the person is not there."
                },
                new Room {
                    Name = "D2350",
                    OutsideDescription = "You see a door labeled 'D2350'",
                    Description = "In this room you see a tv, mic, and a lot of chairs and tables. This is possibly the meeting room for the teachers, but maybe you are free to use it when they are not using it."
                },
                new Room {
                    Name = "D2360",
                    OutsideDescription = "You see a door labeled 'D2360'",
                    Description = "You entered a room or hallway that appears to be a lunch room. There is a refrigurator, coffie machine, and a little kitchen."
                },
                new Room {
                    Name = "D2250",
                    OutsideDescription = "You see a door labeled 'D2250'",
                    Description = "You hear music, keyboard playing, a man is singing. Børre is playing Walking on memphis on keyboard and he thinks that he is playing in Telenor Arena. He doesn't notice you at all."
                },
                new Room {
                    Name = "D3460",
                    OutsideDescription = "You see a door labeled 'D3460'",
                    Description = "Lars clearly missed out on the leverage on the boss that both Anette and Audrey got, because he got an office even a homeless person would be embarresed of."
                },
                new Room {
                    Name = "D3450",
                    OutsideDescription = "You see a door labeled 'D3450'",
                    Description = "Corner office, wow! whatever this guy did to deserve this room, it must have been illegal. But he got free candy in a bowl on his table, so I forgive him for all sins."
                },
                new Room {
                    Name = "D3440",
                    OutsideDescription = "You see a door labeled 'D3440'",
                    Description = "In this room there is a guy named guy. If he doesn't love his parents for the name they gave him, then i don't know what to say. Guy promise you a key to one of the locked rooms around if you can name the movie this quote is from: \"Frankly, my dear, I don't give a damn\""
                },
                new Room {
                    Name = "D3430",
                    OutsideDescription = "You see a door labeled 'D3430'",
                    Description = "You see an open portal to another dimension, and a cleaning trolley standing next to it. It looks like a cleaning lady was in an adventurous mood. Are you in a similiar mood?"
                },
                new Room {
                    Name = "D3420",
                    OutsideDescription = "You see a door labeled 'D3420'",
                    Description = "The second corner office on this floor, and the proud owner Per welcomes you warmly. The shelf in the corner is out of his field of vision and contains many interesting things, maybe there is something you can \"borrow\"?"
                },
                new Room {
                    Name = "D3410",
                    OutsideDescription = "You see a door labeled 'D3410'",
                    Description = "You see a worn down old bed in the furthest corner of the room, and some emply cans of beans around it. Is this a home to someone who is too greedy to pay rent?"
                },
                new Room {
                    Name = "D3400",
                    OutsideDescription = "You see a door labeled 'D3400'",
                    Description = "Per Arne greets you as you enter the tiny but cozy room. There is enough cookies in here to feed the whole school for a year, so I'm sure he can spare you a few for your upcoming journey."
                },
                new Room {
                    Name = "D3390",
                    OutsideDescription = "You see a door labeled 'D3390'",
                    Description = "Andreas stares at you as you enter his room, wondering what you want. unless you want a cup of coffee, he got nothing to offer you."
                },
                new Room {
                    Name = "D3380",
                    OutsideDescription = "You see a door labeled 'D3380'",
                    Description = "This room got no owner, but it seems like Iryna have started sneaking stuff in here. In a year or so I'm guessing the wall separating this room and Iryna's is long gone."
                },
                new Room {
                    Name = "D3370",
                    OutsideDescription = "You see a door labeled 'D3370'",
                    Description = "You have entered Iryna's room. If you got any sort of math questions, ANY! Then this is the place to ask them"
                },
                new Room {
                    Name = "D2260",
                    OutsideDescription = "You see a door labeled 'D2260'",
                    Description = "Christine welcomes you in to here office. She offer you tea or coffie to drink."
                },
                new Room {
                    Name = "D2200",
                    OutsideDescription = "You see a door labeled 'D2200'",
                    Description = "In Klas office he seems very busy with his work. He is programming a python programm. So you could ask him about everything when it comes to pyton."
                },
                new Room {
                    Name = "D2240",
                    OutsideDescription = "You see a door labeled 'D2240'",  
                    Description = "You open a door to a something insane. The books on the shelf, the computer, the desk, everything in there just vanished into a black hole. Peter is shouting for help."
                },
                new Room {
                    Name = "D2220",
                    OutsideDescription = "You see a door labeled 'D2220'",
                    Description = "As you go inn to the office, you see Ingrid is packing here stuff and are about to leave here office. She doesn't have time for questions soo you will have to go."
                },
                new Room {
                    Name = "D2210",
                    OutsideDescription = "You see a door labeled 'D2210'",
                    Description = "You entered a very awesome office and a handsome teacher. You see a kick ass computer and kickass books. The teacher is called The Hans."
                },
                new Room {
                    Name = "C3040",
                    OutsideDescription = "You see a door labeled 'C3040'",
                    Description = "You have entered the Male toilets"
                },
                new Room {
                    Name = "C3050",
                    OutsideDescription = "You see a door labeled 'C3050'",
                    Description = "You have entered the Female toilets"
                },
                new Room {
                    Name = "D2230",
                    OutsideDescription = "You see a door labeled 'D2230'",
                    Description = "A chill wind blows against you as you open the door. The Window is open, computer is on, theres books on the shelf. Frode is turning around and are asking if you need any help."
                },
                new Room{
                    Name = "D3500",
                    OutsideDescription = "You see a door labeled 'D3500'",
                    Description = "The room is totaly empty. It looks like it is being redorated, as the paint on the walls is still damp"
                },                
                new Room{
                    Name = "D3480",
                    OutsideDescription = "You see a door labeled 'D3480'",
                    Description = "The room is totaly empty. It looks like it is being redorated, as the paint on the walls is still damp"
                },
                new Room{
                    Name = "D3530",
                    OutsideDescription = "You see a door labeled 'D3530'",
                    Description = "The room is totaly empty. It looks like it is being redorated, as the paint on the walls is still damp"
                },
                new Room{
                    Name = "D3540",
                    OutsideDescription = "You see a door labeled 'D3540'",
                    Description = "The room is totaly empty. It looks like it is being redorated, as the paint on the walls is still damp"
                },
                new Room{
                    Name = "D3520",
                    OutsideDescription = "You see a door labeled 'D3520'",
                    Description = "The room is totaly empty. It looks like it is being redorated, as the paint on the walls is still damp"
                },
                new Room{
                    Name = "Corridor",
                    OutsideDescription = "You see a door labeled 'Corridor'",
                    Description = "You are in a long corridor with lots of dors on one side."
                }
        
            };
            rooms.ForEach(element => context.Rooms.AddOrUpdate(x => x.Name, element));
            context.SaveChanges();
            
            // Setter opp rom plasseringen
            Room C3020 = context.Rooms.Where(room => room.Name == "C3020").FirstOrDefault();
            Room B3200 = context.Rooms.Where(room => room.Name == "B3200").FirstOrDefault();
            Room C2070 = context.Rooms.Where(room => room.Name == "C2070").FirstOrDefault();
            Room D3330 = context.Rooms.Where(room => room.Name == "D3330").FirstOrDefault();
            Room C2090 = context.Rooms.Where(room => room.Name == "C2090").FirstOrDefault();
            Room C2000 = context.Rooms.Where(room => room.Name == "C2000").FirstOrDefault();
            Room D3320 = context.Rooms.Where(room => room.Name == "D3320").FirstOrDefault();
            Room C2100 = context.Rooms.Where(room => room.Name == "C2100").FirstOrDefault();
            Room C2080 = context.Rooms.Where(room => room.Name == "C2080").FirstOrDefault();
            Room D3340 = context.Rooms.Where(room => room.Name == "D3340").FirstOrDefault();
            Room D3350 = context.Rooms.Where(room => room.Name == "D3350").FirstOrDefault();
            Room D3050 = context.Rooms.Where(room => room.Name == "D3050").FirstOrDefault();
            Room D3040 = context.Rooms.Where(room => room.Name == "D3040").FirstOrDefault();
            Room C3150 = context.Rooms.Where(room => room.Name == "C3150").FirstOrDefault();
            Room D3360 = context.Rooms.Where(room => room.Name == "D3360").FirstOrDefault();
            Room C3015 = context.Rooms.Where(room => room.Name == "C3015").FirstOrDefault();
            Room C3021 = context.Rooms.Where(room => room.Name == "C3021").FirstOrDefault();
            Room D3310 = context.Rooms.Where(room => room.Name == "D3310").FirstOrDefault();
            Room C3000 = context.Rooms.Where(room => room.Name == "C3000").FirstOrDefault();
            Room C2060 = context.Rooms.Where(room => room.Name == "C2060").FirstOrDefault();
            Room D2330 = context.Rooms.Where(room => room.Name == "D2330").FirstOrDefault();
            Room D2320 = context.Rooms.Where(room => room.Name == "D2320").FirstOrDefault();
            Room D2310 = context.Rooms.Where(room => room.Name == "D2310").FirstOrDefault();
            Room D2300 = context.Rooms.Where(room => room.Name == "D2300").FirstOrDefault();
            Room D2370 = context.Rooms.Where(room => room.Name == "D2370").FirstOrDefault();
            Room Gangbro = context.Rooms.Where(room => room.Name == "Gangbro").FirstOrDefault();
            Room Corridor = context.Rooms.Where(room => room.Name == "Corridor").FirstOrDefault();
            Room C3191 = context.Rooms.Where(room => room.Name == "C3191").FirstOrDefault();
            Room C3190 = context.Rooms.Where(room => room.Name == "C3190").FirstOrDefault();
            Room D3510 = context.Rooms.Where(room => room.Name == "D3510").FirstOrDefault();
            Room D3490 = context.Rooms.Where(room => room.Name == "D3490").FirstOrDefault();
            Room D3470 = context.Rooms.Where(room => room.Name == "D3470").FirstOrDefault();
            Room D2290 = context.Rooms.Where(room => room.Name == "D2290").FirstOrDefault();
            Room D2380 = context.Rooms.Where(room => room.Name == "D2380").FirstOrDefault();
            Room D2390 = context.Rooms.Where(room => room.Name == "D2390").FirstOrDefault();
            Room D2400 = context.Rooms.Where(room => room.Name == "D2400").FirstOrDefault();
            Room D2280 = context.Rooms.Where(room => room.Name == "D2280").FirstOrDefault();
            Room D2270 = context.Rooms.Where(room => room.Name == "D2270").FirstOrDefault();
            Room D2340 = context.Rooms.Where(room => room.Name == "D2340").FirstOrDefault();
            Room D2350 = context.Rooms.Where(room => room.Name == "D2350").FirstOrDefault();
            Room D2360 = context.Rooms.Where(room => room.Name == "D2360").FirstOrDefault();
            Room D2250 = context.Rooms.Where(room => room.Name == "D2250").FirstOrDefault();
            Room D3460 = context.Rooms.Where(room => room.Name == "D3460").FirstOrDefault();
            Room D3450 = context.Rooms.Where(room => room.Name == "D3450").FirstOrDefault();
            Room D3440 = context.Rooms.Where(room => room.Name == "D3440").FirstOrDefault();
            Room D3430 = context.Rooms.Where(room => room.Name == "D3430").FirstOrDefault();
            Room D3420 = context.Rooms.Where(room => room.Name == "D3420").FirstOrDefault();
            Room D3410 = context.Rooms.Where(room => room.Name == "D3410").FirstOrDefault();
            Room D3400 = context.Rooms.Where(room => room.Name == "D3400").FirstOrDefault();
            Room D3390 = context.Rooms.Where(room => room.Name == "D3390").FirstOrDefault();
            Room D3380 = context.Rooms.Where(room => room.Name == "D3380").FirstOrDefault();
            Room D3370 = context.Rooms.Where(room => room.Name == "D3370").FirstOrDefault();
            Room D2260 = context.Rooms.Where(room => room.Name == "D2260").FirstOrDefault();
            Room D2200 = context.Rooms.Where(room => room.Name == "D2200").FirstOrDefault();
            Room D2240 = context.Rooms.Where(room => room.Name == "D2240").FirstOrDefault();
            Room D2220 = context.Rooms.Where(room => room.Name == "D2220").FirstOrDefault();
            Room D2210 = context.Rooms.Where(room => room.Name == "D2210").FirstOrDefault();
            Room D2230 = context.Rooms.Where(room => room.Name == "D2230").FirstOrDefault();
            Room C3040 = context.Rooms.Where(room => room.Name == "C3040").FirstOrDefault();
            Room C3050 = context.Rooms.Where(room => room.Name == "C3050").FirstOrDefault();
            Room D3500 = context.Rooms.Where(room => room.Name == "D3500").FirstOrDefault();
            Room D3480 = context.Rooms.Where(room => room.Name == "D3480").FirstOrDefault();
            Room D3530 = context.Rooms.Where(room => room.Name == "D3530").FirstOrDefault();
            Room D3520 = context.Rooms.Where(room => room.Name == "D3520").FirstOrDefault();
            Room D3540 = context.Rooms.Where(room => room.Name == "D3540").FirstOrDefault();         

            // Mapping av Tredje etasje
            D3310.ConnectedRooms.Add(D3340);
            D3310.ConnectedRooms.Add(D3320);
            D3310.ConnectedRooms.Add(C3020);
            D3340.ConnectedRooms.Add(D3310);
            D3320.ConnectedRooms.Add(D3310);
            C3020.ConnectedRooms.Add(D3310);

            C3020.ConnectedRooms.Add(D3350);
            C3020.ConnectedRooms.Add(D3360);
            C3020.ConnectedRooms.Add(C3040);
            C3020.ConnectedRooms.Add(C3050);
            C3020.ConnectedRooms.Add(C3191);
            C3020.ConnectedRooms.Add(C3000);
            C3020.ConnectedRooms.Add(C3021);

            D3350.ConnectedRooms.Add(C3020);
            D3330.ConnectedRooms.Add(C3020);
            D3360.ConnectedRooms.Add(C3020);
            C3040.ConnectedRooms.Add(C3020);
            C3050.ConnectedRooms.Add(C3020);
            C3191.ConnectedRooms.Add(C3020);
            C3021.ConnectedRooms.Add(C3020);

            C3021.ConnectedRooms.Add(C3150);
            C3150.ConnectedRooms.Add(C3021);

            C3191.ConnectedRooms.Add(C3190);
            C3191.ConnectedRooms.Add(D3510);
            C3191.ConnectedRooms.Add(D3500);
            C3191.ConnectedRooms.Add(D3490);
            C3191.ConnectedRooms.Add(D3480);
            C3191.ConnectedRooms.Add(D3480);
            C3191.ConnectedRooms.Add(D3470);
            C3191.ConnectedRooms.Add(D3460);
            C3191.ConnectedRooms.Add(D3450);
            C3191.ConnectedRooms.Add(D3440);
            C3191.ConnectedRooms.Add(D3530);
            C3191.ConnectedRooms.Add(D3540);
            C3191.ConnectedRooms.Add(D3520);

            C3190.ConnectedRooms.Add(C3191);
            D3510.ConnectedRooms.Add(C3191);
            D3500.ConnectedRooms.Add(C3191);
            D3490.ConnectedRooms.Add(C3191);
            D3480.ConnectedRooms.Add(C3191);
            D3470.ConnectedRooms.Add(C3191);
            D3460.ConnectedRooms.Add(C3191);
            D3450.ConnectedRooms.Add(C3191);
            D3440.ConnectedRooms.Add(C3191);
            D3530.ConnectedRooms.Add(C3191);
            D3540.ConnectedRooms.Add(C3191);
            D3520.ConnectedRooms.Add(C3191);

            D3520.ConnectedRooms.Add(Corridor);

            Corridor.ConnectedRooms.Add(D3520);
            Corridor.ConnectedRooms.Add(D3370);
            Corridor.ConnectedRooms.Add(D3380);
            Corridor.ConnectedRooms.Add(D3390);
            Corridor.ConnectedRooms.Add(D3400);
            Corridor.ConnectedRooms.Add(D3410);
            Corridor.ConnectedRooms.Add(D3420);
            Corridor.ConnectedRooms.Add(D3430);

            D3430.ConnectedRooms.Add(Corridor);
            D3420.ConnectedRooms.Add(Corridor);
            D3410.ConnectedRooms.Add(Corridor);
            D3400.ConnectedRooms.Add(Corridor);
            D3390.ConnectedRooms.Add(Corridor);
            D3380.ConnectedRooms.Add(Corridor);
            D3370.ConnectedRooms.Add(Corridor);
            D3430.ConnectedRooms.Add(Corridor);
            D3430.ConnectedRooms.Add(Corridor);

            context.SaveChanges();

            //Seed Descriptions

            var descriptions = new List<Description>
            {
               new Description {
                   Name = "Soap1",
                   Text = "The soap is contained in a blue container with a pump at the top. It's half full."
                },
                new Description {
                    Name = "Soap2",
                    Text = "There is a white soap bar on the sink. It's well used."
               },
               new Description {
                   Name = "JavaBook",
                   Text = "On one of the tables there is a book with the title 'Java: The final chapter'"
                }
            };
            descriptions.ForEach(element => context.Descriptions.AddOrUpdate(description => description.Text, element));

            context.SaveChanges();

            //Seed Items

            var items = new List<Item>
            {
                new Item {
                    Name = "Soap1",
                    Description = context.Descriptions.Where(x => x.Name == "Soap1").FirstOrDefault(),
                    isDrinkable = true,
                    isEatable = false,
                    Room = context.Rooms.Where(x => x.Name == "C3050").FirstOrDefault()
                },
                new Item {
                    Name = "Soap2",
                    Description = context.Descriptions.Where(x => x.Name == "Soap2").FirstOrDefault(),
                    isDrinkable = false,
                    isEatable = true,
                    Room = context.Rooms.Where(x => x.Name == "C3040").FirstOrDefault()
                },
                new Item {
                    Name = "JavaBook",
                    Description = context.Descriptions.Where(x => x.Name == "JavaBook").FirstOrDefault(),
                    isDrinkable = false,
                    isEatable = false,
                    Room = context.Rooms.Where(x => x.Name == "D3500").FirstOrDefault()
                }

            };
            items.ForEach(element => context.Items.AddOrUpdate(item => item.Name, element));

            context.SaveChanges();
            
        }
    }
}
