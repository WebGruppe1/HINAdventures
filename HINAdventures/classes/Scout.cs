using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    /// <summary>
    /// Returns all available rooms and all items, users and virtual users in the current room.
    /// </summary>
    public class Scout : ICommand
    {
        private IRepository repo;
        public Scout()
        {
            repo = new Repository();
        }

        /// <summary>
        /// this one looks for different things in this room and name them or what it is in this room. 
        /// like another player, virtual user, items and says what rooms this is.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public String RunCommand(String userID)
        {
            List<Room> rooms =  repo.getAvailableRooms(userID);
            List<Item> items = repo.GetAllItems();
            List<ApplicationUser> users = repo.GetAllUsers();
            List<VirtualUser> virtualUsers = repo.GetVirtualUsers();
            ApplicationUser user = repo.GetUser(userID);

            String returnString = "You look around and see doors labeled with the names ";

            foreach(Room room in rooms)
            {
                if(room.Equals(rooms.Last()))
                    returnString += room.Name + ". ";
                else
                    returnString += room.Name + ", ";
            }

            if(items.Count > 0)
            {
                Boolean runnedOnce = false;
                foreach(Item item in items)
                {
                    if (item.ApplicationUser == null && item.Room == user.Room)
                    {
                        if(runnedOnce)
                            returnString += ", ";
                        if (!runnedOnce)
                        {
                            returnString += "When you look around you also see some items: ";
                            runnedOnce = true;
                        }
                        returnString += item.Name;
                    }
                }
                returnString += ". ";
            }

            if(users.Count > 0)
            {
                string availableUsers = "";
                foreach(ApplicationUser u in users)
                {
                    if (u.Room == user.Room && u.Id != user.Id)
                    {
                        availableUsers += u.FirstName + ", ";
                    }

                }
                if (availableUsers != "")
                    returnString += "It looks like you're not alone in this room! you also see " + availableUsers + " standing around doing nothing. ";
            }

            if(virtualUsers.Count > 0)
            {
                string availableVirtualUsers = "";
                foreach(VirtualUser vu in virtualUsers)
                {
                    if (vu.Room == user.Room)
                        availableVirtualUsers += vu.Name + ", ";
                }
                if (availableVirtualUsers != "")
                    returnString += "There might be a lecture going on, bacause " + availableVirtualUsers + " is standing by the canvas";
            }
            return returnString;
        }
    }
}