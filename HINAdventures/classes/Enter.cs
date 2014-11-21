﻿using HINAdventures.Models;
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
                    string message = repo.RoomDescription(_room);
                    message += "\n";
                    
                    var user = repo.GetUser(userID);

                    message += string.Format("You see {0} doors labeled ", user.Room.ConnectedRooms.Count());

                    Room last = user.Room.ConnectedRooms.Last();
                    foreach (Room connectedRoom in user.Room.ConnectedRooms)
                    {
                        message += string.Format("'{0}'", connectedRoom.Name);
                        if (connectedRoom.Equals(last))
                        {
                            message += ".\n";
                        }
                        else
                        {
                            message += ", ";
                        }
                    }    

                    return message;
                }

            return "This room is out of reach";

        }

    }
}