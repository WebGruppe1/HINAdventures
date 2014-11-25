using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace HINAdventures.classes
{
    public class Repository : HINAdventures.classes.IRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<Room> getAvailableRooms(String userID)
        {            
            List<Room> list = new List<Room>();
            ApplicationUser user = db.Users.Where(u => u.Id == userID).FirstOrDefault();

            //user.Room.ConnectedRooms
            //var EnteredRoom = db.Rooms.Where(r => r.Name == argument).FirstOrDefault();
            

            foreach (Room room in user.Room.ConnectedRooms)
                list.Add(room);
                //if (room == user.Room)
                   // list.Add(room.Name);     
            
            return list;
        }
        public List<Item> GetEatableItems()
        {
            //using (var context = new ApplicationDbContext())
            //{
                var eatItems = db.Items.Include("Room").Where(i => i.isEatable == true).ToList();
                return eatItems;
            //}
        }
        public List<Item> GetAllItems()
        {
            //using (var context = new ApplicationDbContext())
            //{
                var itemListe = db.Items.ToList();
                return itemListe;

            //}
        }
        public List<Item> GetDrinkableItems()
        {
            using (var context = new ApplicationDbContext())
            {
                var drinkListe = context.Items.Include("Room").Where(i => i.isDrinkable == true).ToList();
                return drinkListe;

            }
        }
        public String RoomDescription(String roomName)
        {
            var desc = from a in db.Rooms where a.Name == roomName select a.Description;
            return desc.FirstOrDefault();
        }

        public List<Item> GetInventory(string userId)
        {
            var itemList = db.Items.Where(items => items.ApplicationUser.Id.Equals(userId)).ToList();
            return itemList;
        }
        public string PutIntoInventory(string item, string userID)
        {
            //kode ikke ferdig
            ApplicationUser user = GetUser(userID);
            var selectedItem = db.Items.Where(i => i.Name == item).FirstOrDefault();
            

            if(selectedItem != null && selectedItem.Room == user.Room)
            {
                if (selectedItem.ApplicationUser == null)
                {
                    selectedItem.ApplicationUser = user;
                    user.Items.Add(selectedItem);
                    db.SaveChanges();
                    return "You picked up " + item + "\n";
                }
                else if (selectedItem.ApplicationUser == user)
                    return "You already have that item in your inventory";
                else
                    return "Item not found";
                
            }

            else
                return "item not found\n";

        }
        public void UpdatePersonItem(int item_id, ApplicationUser user)
        {
            var item = db.Items.Include("ApplicationUser").Where(i => i.ID == item_id).FirstOrDefault();
            item.ApplicationUser = user;
            db.SaveChanges();

        }
        public List<ApplicationUser> GetAllUsers()
        {
            var users = db.Users.ToList();
            return users;
        }
        public ApplicationUser GetUser(string userId)
        {
            ApplicationUser user = db.Users.Where(u => u.Id == userId).FirstOrDefault();
            return user;
        }
        public void UpdatePlayerPosition(String argument, String userID)
        {
            ApplicationUser user = db.Users.Where(u => u.Id == userID).FirstOrDefault();
            user.Room = db.Rooms.Where(r => r.Name == argument).FirstOrDefault();

            //Utestet, skal forandre item i inventory sin posisjon
            List<Item> itemList = this.GetAllItems();
            foreach (Item item in itemList)
            {
                //if (user.Id.Equals(item.ApplicationUser.Id))
                if(item.ApplicationUser != null)
                    if(user.Equals(item.ApplicationUser))
                        item.Room = user.Room;
            }

            db.SaveChanges();

        }

        public String Examine(string item, string userId)
        {
            string description = "";

            ApplicationUser user = this.GetUserFromName(item);
            ApplicationUser currentUser = this.GetUser(userId);
            Room room = this.GetRoom(item);

            if (room != null)
            {
                if (room.Id == currentUser.Room.Id)
                    return room.Description;
                else
                    return "You need to be in a room to examine it.";
            }

            if (user == null)
            {
                try
                {
                    user = this.GetUser(userId);
                    Item itemFromDb = db.Items.Where(i => i.Name == item).FirstOrDefault();

                    if (itemFromDb != null)
                    {
                        if (user.Room.Id == itemFromDb.Room.Id)
                            description = itemFromDb.Description.Text;

                        else
                            description = "An item like that is not around here.";
                    }

                    else
                        description = "Does not seem like that item can be found anywhere at this school.";
                }
                catch (ArgumentNullException)
                {
                    description = "Does not seem like that item can be found anywhere at this school.";
                }
            }

            else
            {
                //Comment out for testing on your own user
                if (userId.Equals(user.Id))
                {
                    return "No reason to examine yourself in public, try inventory if you want to check your pockets.";
                }
                //

                if (currentUser.Room.Id != user.Room.Id)
                {
                    return "You need to be in the same room as the user you want to examine.";
                }

                List<Item> itemList = this.GetInventory(user.Id);
                StringBuilder tempDescription = new StringBuilder();

                tempDescription.Append("Your examination of " + user.UserName + " has revealed he is currently in the possesion of");

                if (itemList.Count > 0)
                {
                    tempDescription.Append(" the following items:");
                    foreach (Item i in itemList)
                    {
                        tempDescription.Append("\n" + i.Name);
                        description = tempDescription.ToString();
                    }
                }
                else
                {
                    tempDescription.Append(" no items worth taking notice of.");
                    description = tempDescription.ToString();
                }
            }
            return description;
        }

        //Brukes kun fra samme klasse av metoden Examine
        private ApplicationUser GetUserFromName(string username)
        {
            try
            {
                ApplicationUser user = db.Users.Where(u => u.UserName == username).FirstOrDefault();
                return user;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }

        private Room GetRoom(string roomName)
        {
            Room room = db.Rooms.Where(w => w.Name == roomName).FirstOrDefault();
            return room;
        }


        public List<VirtualUser> GetVirtualUsers()
        {
            var users = from u in db.VirtualUser select u;
            return users.ToList();
        }

        public List<VirtualUserChatCommands> GetVirtualUserChatCommandsToUser(VirtualUser user)
        {
            var chatCommands = from c in db.VirtualUserChatCommans
                               where c.VirtualUser == user && c.SayRegulary == true
                               select c;
            return chatCommands.ToList();
        }

        public List<VirtualUserChatCommands> GetVirtualUserChatCommandsNotRegularyToUser(VirtualUser user)
        {
            var chatCommands = from c in db.VirtualUserChatCommans
                               where c.VirtualUser == user && c.SayRegulary == false
                               select c;
            return chatCommands.ToList();
        }


        public VirtualUser GetVirtualUser(string name)
        {
            VirtualUser user = db.VirtualUser.Where(u => u.Name == name).FirstOrDefault();
         
            return user;
        }



    }
}