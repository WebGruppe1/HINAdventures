using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    /// <summary>
    /// Eat.cs
    /// 
    /// Command class to eat something. Retrieves a list of items that can
    /// be Eaten and checks if the user and item is in the same room.
    /// </summary>
    public class Eat : ICommandTwoArgs
    {
        private IRepository repos;
        public Eat()
        {
            repos = new Repository();
        }
         public Eat(IRepository _repo)
        {
            repos = _repo;
        }
        public string RunCommand(string food, string userID)
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
                            return "You just ate " + food;
                        }
                    }
                }
            }
            return "You can't eat this";

        }      

    }
}