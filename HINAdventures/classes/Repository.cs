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

        public String[] getAvailableRooms()
        {            
            var rooms = from a in db.Rooms select a.Name;

            String[] list = rooms.ToArray();            
            
            return list;
        }
        public List<Item> GetEatableItems()
        {
            using (var context = new ApplicationDbContext())
            {
                var eatItems = context.Items.Where(i => i.isEatable == true).ToList();
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
                var drinkListe = context.Items.Where(i=> i.isDrinkable == true).ToList();
                return drinkListe;

            }
        }
        public String RoomDescription(String input)
        {
            var desc = from a in db.Rooms where a.Name == input select a.Description;
            return desc.FirstOrDefault();
        }

        //utestet
        public List<Item> GetInventory(string userId)
        {
            var itemList = db.Items.Where(items => items.ApplicationUser.Id.Equals(userId)).ToList();
            return itemList;
        }
    }
}