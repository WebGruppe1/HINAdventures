using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Throw : ICommandTwoArgs
    {
        private IRepository repos;
        private List<Item> items;
        public Throw()
        {
            repos = new Repository();
            items = repos.GetAllItems();
        }
        public string RunCommand(string item, string userID)
        {
            string output = "";
            for (int i = 0; i < items.Count; i++)
            {
                Item it = items[i];
                ApplicationUser user = repos.GetUser(userID);
                if (it.Room.Id == user.Room.Id)
                {
                    if (it.Name.ToLower() == item || it.Name == item)
                    {
                        output = "You just threw a " + it.Name;
                        repos.UpdatePersonItem(it.ID, null);
                        break;
                    }
                    else
                    {
                        output = "The item you are trying to throw does not exist in this room";
                    }
                    
                }
                else
                {
                    output = "The item you are trying to throw does not exist in this room";

                }
            }
            return output;

        }
    }
}
