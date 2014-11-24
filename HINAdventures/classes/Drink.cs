using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Drink : ICommandTwoArgs
    {    
        private IRepository repos;
        private List<Item> items;
        public Drink()
        {
            repos = new Repository();
            items = repos.GetDrinkableItems();
        }
        public string RunCommand(string item, string userID)
        {
            if (items != null)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    Item it = items[i];
                    ApplicationUser user = repos.GetUser(userID);
                    if (user.Room.Id == it.Room.Id)
                    {
                        if (it.Name == item || it.Name.ToLower() == item)
                        {
                            return "You drank " + item;
                        }
                    }
                }
            }
            return "You can't drink this";
        }
    
    }
}