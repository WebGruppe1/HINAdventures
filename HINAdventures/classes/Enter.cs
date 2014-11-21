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
        public String RunCommand(String _room, String userID)
        {
            List<Room> rooms = repo.getAvailableRooms(userID);

            foreach(Room room in rooms)
                if (room.Name.Equals(_room, StringComparison.InvariantCultureIgnoreCase))
                {
                    repo.UpdatePlayerPosition(_room, userID);
                    return repo.RoomDescription(_room);
                }

            return "This room is out of reach";

        }

    }
}