using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Eat :ICommand
    {
        private IRepository repos;
        public Eat()
        {
            repos = new Repository();
        }
        public string RunCommand(string food)
        {
            
            List<Item> items = repos.GetEatableItems();
            if (items != null)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    Item it = items[i];

                    if (it.Name == food || it.Name.ToLower() == food)
                    {
                        food = "You just ate " + it.Name;
                    }
                    else
                    {
                        food = "You can't eat that";
                    }
                }
            }
            return food;
        }      

    }
}