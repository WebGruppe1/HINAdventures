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
            string eat = "";
            
            List<Item> items = repos.GetAllItems();
            if (items != null)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    Item it = items[i];
                   
                    if (food == it.Name || food == it.Name.ToLower() && it.isEatable)
                        eat = "You just ate " + food;
                    else
                        eat = "You can't eat that";
                }
            }
            return eat;
        }      

    }
}