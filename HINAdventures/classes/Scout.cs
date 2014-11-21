using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Scout : ICommand
    {
        private IRepository repo;
        public Scout()
        {
            repo = new Repository();
        }
        public String RunCommand(String userID)
        {
            List<Room> rooms =  repo.getAvailableRooms(userID);
            String returnString = "Nearby rooms: ";

            foreach(Room room in rooms)
            {
                returnString += room.Name + ", ";
            }
            return returnString;
        }
    }
}