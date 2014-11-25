using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Hit : ICommandTwoArgs
    {
        private IRepository repos;
        public Hit()
        {
            repos = new Repository();
        }
        public Hit(IRepository _repo)
        {
            repos = _repo;
        }
        public string RunCommand(string item, string userID)
        {
            List<Item> items = repos.GetAllItems();
            for (int i = 0; i < items.Count; i++)
            {
                Item it = items[i];
                ApplicationUser user = repos.GetUser(userID);
                if (user.Room.Id == it.Room.Id)
                {
                    if (item == it.Name.ToLower() || item == it.Name)
                    {
                        return "You just struck a " + it.Name;
                    }
                }
            }
            return "The Item you are trying to hit/struck does not exist in this room";

        }
    }
}