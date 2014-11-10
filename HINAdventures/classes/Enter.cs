using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Enter
    {
        static ApplicationDbContext db;

        public static String EnterCommand(String room)
        {
            db = new ApplicationDbContext();
            String returnString;
            Room selectedRoom = null;

            if (db.Rooms.Where(r => r.Name.Equals(room)).Count() > 0)
            {
                selectedRoom = db.Rooms.Where(r => r.Name.Equals(room)).First();
                returnString = selectedRoom.Description;

                //Spiller sin posisjon må flyttes til det aktuelle rommet.
            }

            else
                returnString = "No room with that name exists in this area";


            return returnString;
        }
    }
}