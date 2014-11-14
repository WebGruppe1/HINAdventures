using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Hit
    {
        private static IRepository repos;
        public Hit()
        {
            repos = new Repository();
        }
        public static string HitCommand(string item)
        {
                  string hit = "";
                  List<Item> items = getItems();
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
        static List<Item> getItems()
        {
            return repos.GetAllItems();
        }
        
    }
}