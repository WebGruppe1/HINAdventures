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
            List<String> rooms =  repo.getAvailableRooms(userID);
            String returnString = "Nearby rooms: ";

            foreach(String room in rooms)
            {
                returnString += room + ", ";
            }
            return returnString;
        }
    }
}