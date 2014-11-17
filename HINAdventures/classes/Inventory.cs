using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HINAdventures.Models;
using System.Text;

namespace HINAdventures.classes
{
    /**
     * Kristian Alm 17.11.2014
     * Class that returns a list of items in the users inventory
     */ 
    public class Inventory : ICommand
    {
        private IRepository repos;

        public Inventory()
        {
            repos = new Repository();
        }

        //Argument is the users id, used to find that users inventory
        public string RunCommand(string argument)
        {
            List<Item> itemList = repos.GetInventory(argument);         //Get a list of items that belong to the user
            StringBuilder items = new StringBuilder();

            //Build a string of all items
            if (itemList.Count != 0)
            {
                foreach (Item item in itemList)
                {
                    items.Append(item.Name + "\n");
                }
            }
            else
                items.Append("No items in inventory!");                 //Display no items if list is empty

            return items.ToString();
        }
    }
}