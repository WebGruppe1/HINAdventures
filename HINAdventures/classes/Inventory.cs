using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HINAdventures.Models;
using System.Text;

namespace HINAdventures.classes
{
    public class Inventory : ICommand
    {
        private IRepository repos;

        public Inventory()
        {
            repos = new Repository();
        }

        public string RunCommand(string argument)
        {
            //List<Item> itemList = repos.GetInventory(userID); //Denne skal brukes etterhvert
            List<Item> itemList = repos.GetAllItems();          //for testing
            StringBuilder items = new StringBuilder();

            if (itemList.Count != 0)
            {
                foreach (Item item in itemList)
                {
                    items.Append(item.Name + "\n");
                }
            }
            else
                items.Append("No items in inventory!");

            return items.ToString();
        }
    }
}