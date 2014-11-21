using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Repository : IRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<String> getAvailableRooms(String userID)
        {            
            List<String> list = new List<String>();
            ApplicationUser user = db.Users.Where(u => u.Id == userID).FirstOrDefault();

            //user.Room.ConnectedRooms
            //var EnteredRoom = db.Rooms.Where(r => r.Name == argument).FirstOrDefault();
            

            foreach (Room room in user.Room.ConnectedRooms)
                list.Add(room.Name);
                //if (room == user.Room)
                   // list.Add(room.Name);     
            
            return list;
        }
        public List<Item> GetEatableItems()
        {
            using (var context = new ApplicationDbContext())
            {
                var eatItems = context.Items.Include("Room").Where(i => i.isEatable == true).ToList();
                return eatItems;
            }
        }
        public List<Item> GetAllItems()
        {
            using (var context = new ApplicationDbContext())
            {
                var itemListe = context.Items.ToList();
                return itemListe;

            }
        }
        public List<Item> GetDrinkableItems()
        {
            using (var context = new ApplicationDbContext())
            {
                var drinkListe = context.Items.Include("Room").Where(i => i.isDrinkable == true).ToList();
                return drinkListe;

            }
        }
        public String RoomDescription(String input)
        {
            var desc = from a in db.Rooms where a.Name == input select a.Description;
            return desc.FirstOrDefault();
        }

        public List<Item> GetInventory(string userId)
        {
            var itemList = db.Items.Where(items => items.ApplicationUser.Id.Equals(userId)).ToList();
            return itemList;
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
                if (user.Id.Equals(item.ApplicationUser.Id))
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
    }
}