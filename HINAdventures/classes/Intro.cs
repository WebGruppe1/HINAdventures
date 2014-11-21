using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Intro : ICommand
    {
        private IRepository repos;

        public Intro()
        {
            repos = new Repository();
        }

        public string RunCommand(string userId)
        {
            var user = repos.GetUser(userId);
            string message = string.Format("Welcome to HINAdventures {0}!\n", user.FirstName);
            message += "This game will let you play in a simulation of Narvik University College\n";
            message += "To see all available rooms from the room you are in type 'scout'\n";
            message += "To move to another room type 'Enter roomnumber'\n";
            message += "You can also chat to other people in the chat below.\n";
            message += "For a full list of commands type 'Help'\n";
            message += "Enjoy the game!\n\n";

            message += user.Room.Description;
            message += "\n";
            message += string.Format("You see {0} doors labeled ", user.Room.ConnectedRooms.Count());

            Room last = user.Room.ConnectedRooms.Last();
            foreach (Room room in user.Room.ConnectedRooms)
            {
                message += string.Format("'{0}'", room.Name);
                if (room.Equals(last))
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
    }
}