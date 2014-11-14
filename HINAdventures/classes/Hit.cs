using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Hit :ICommand
    {
        private IRepository repos;
        public Hit()
        {
            repos = new Repository();
        }
        public string RunCommand(string item)
        {
                  string hit = "";
                  List<Item> items = repos.GetAllItems();
                  for (int i = 0; i < items.Count; i++)
                  {
                      Item it = items[i];
                      if (item == it.Name.ToLower() || item == it.Name)
                      {
                          hit = "You just struck a " + item;
                      }
                      else
                      {
                          hit = "The Item you are trying to hit/struck does not exist";
                      }
                  }
                  return hit;
           
        }
    }
}