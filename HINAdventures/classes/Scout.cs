﻿using HINAdventures.Models;
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
                        if (!runnedOnce)
                        {
                            returnString += "When you look around you also see some items: ";
                            runnedOnce = true;
                        }

                        if (item.Equals(items.Last()))
                            returnString += item.Name + ". ";
                        else
                            returnString += item.Name + ", ";
                    }
                }
            }

            if(users.Count > 0)
            {
                string availableUsers = "";
                foreach(ApplicationUser u in users)
                {
                    if (u.Room == user.Room && u.Id != user.Id)
                    {
                        if (u.Equals(users.Last()))
                            availableUsers += u.FirstName;
                        else
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
                        availableVirtualUsers += vu.Name;
                }
                if (availableVirtualUsers != "")
                    returnString += "There might be a lecture going on, bacause " + availableVirtualUsers + " is standing by the canvas";
            }


            return returnString;
        }
    }
}