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
            String eat = "";
            //var item = repos.getSpecificItem(food);
            Boolean isEatable = false ;

            if (isEatable == true)
                return eat = "You just ate " + food;
            else
                return eat = "You can't eat that";
            /*List<Item> items = repos.GetAllItems();
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
            return eat;*/
        }      

    }
}