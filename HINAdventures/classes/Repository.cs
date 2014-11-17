﻿using HINAdventures.Models;
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
        public List<Item> GetAllItems()
        {
            using (var context = new ApplicationDbContext())
            {
                var itemListe = context.Items.ToList();
                return itemListe;

            }
        }
        public IEnumerable<Item> getSpecificItem(String input)
        {
            var item = from a in db.Items where a.Name == input select a;
            return item;
          
        }
        public String RoomDescription(String input)
        {
            var desc = from a in db.Rooms where a.Name == input select a.Description;
            return desc.FirstOrDefault();
        }
    }
}