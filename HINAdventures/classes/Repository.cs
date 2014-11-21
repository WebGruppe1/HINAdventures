using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public String ItemDescription(string item, string userId)
        {
            string description = "";

            try
            {
                ApplicationUser user = this.GetUser(userId);
                Item itemFromDb = db.Items.Where(i => i.Name == item).FirstOrDefault();

                if (user.Room.Id == itemFromDb.Room.Id)
                    description = itemFromDb.Description.Text;
    
                else
                    description = "An item like that is not around here";
            }
            catch (ArgumentNullException)
            {
                description = "Cannot find the item you try to examine";
            }
            return description;
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