using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Eat 
    {
        private IRepository repos;
        public Eat()
        {
            repos = new Repository();
        }
        public string Command(string food, string userID)
        {


            List<Item> items = repos.GetEatableItems();
            
            if (items != null)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    Item it = items[i];
                    ApplicationUser user = repos.GetUser(userID);
                    if (user.Room.Id == it.Room.Id)
                    {
                        if (food == it.Name || food == it.Name.ToLower() && it.isEatable)
                        {
                            food = "You just ate " + food;
                        }
                        else
                        {
                            food = "You can't eat that";
                        }
                    }
                    else
                    {
                        food = "Do not exist in this room";
                    }
                }

            }
            return food;

        }      

    }
}