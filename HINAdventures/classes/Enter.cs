using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Enter
    {
        private IRepository repo;
        
        public Enter()
        {
            repo = new Repository();
        }
        public String RunCommand(String room, String userID)
        {
            List<String> rooms = repo.getAvailableRooms(userID);

            foreach(String s in rooms)
                if (s.Equals(room, StringComparison.InvariantCultureIgnoreCase))
                {
                    repo.UpdatePlayerPosition(room, userID);
                    return repo.RoomDescription(room);
                }

            return "This room is out of reach";

        }

    }
}