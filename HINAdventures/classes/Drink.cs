using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Drink : ICommand
    {    
        private IRepository repos;
        private List<Item> items;
        public Drink()
        {
            repos = new Repository();
            items = repos.GetAllItems();
        }
        public string RunCommand(string item)
        {
            if (items != null)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    Item it = items[i];
                    if (it.isDrinkable)
                        item = "You drank " + item;
                    else
                        item = "You can't drink this";
                }
            }
            return item;
        }
    
    }
}