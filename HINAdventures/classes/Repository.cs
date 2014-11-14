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

        public List<String> getAvailableRooms()
        {
            List<String> list = new List<String>();
            
            var rooms = from a in db.Rooms select a;

            foreach (Room r in rooms)
            {
                list.Add(r.Name);
            }
            
            return list;
        }

    }
}