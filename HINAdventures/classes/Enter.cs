using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    /// <summary>
    /// Enter.cs
    /// 
    /// Makes a player change his position from one room to another. a new list of available rooms
    /// is returned and displayed.
    /// </summary>
    public class Enter : ICommandTwoArgs
    {
        private IRepository repo;
        
        public Enter()
        {
            repo = new Repository();
        }

        /// <summary>
        /// when you run the command enter with a room, it will first check if that room excist and that room is a
        /// neightbour room of the room you are in. if that checks out, you will get the new descption of that room
        /// and update the player position so that is always updated.
        /// </summary>
        /// <param name="_room"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public String RunCommand(String _room, String userID)
        {
            
            List<Room> rooms = repo.getAvailableRooms(userID);

            foreach(Room room in rooms)
                if (room.Name.Equals(_room, StringComparison.InvariantCultureIgnoreCase))
                {
                    string virtuelUserChat = repo.UpdatePlayerPosition(_room, userID);
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
                    
                    return message + "\n\n" + virtuelUserChat;
                }
            
            return "This room is out of reach";

        }

    }
}