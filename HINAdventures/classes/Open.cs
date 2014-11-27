using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    /// <summary>
    /// Open.cs
    /// 
    /// Commando to open a secret room, but you must have a key.
    /// </summary>
    public class Open : ICommandTwoArgs
    {
        private IRepository repos;
        private List<Item> inventory;
        public Open()
        {
            repos = new Repository();
        }
          public Open(IRepository _repo)
        {
            repos = _repo;
        }
        public string RunCommand(string item, string userId)
        {
            inventory = repos.GetInventory(userId);

            if (item.Equals("door"))
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    Item it = inventory[i];

                    if (it.Name.Equals("Brown key") && it.Room.Name == "D2370")
                    {
                        item = "You unlocked the door! but there is no treasure here, besides the opportunity for cleaning the school :)";
                        break;
                    }
                    else
                    {
                        item = "You will need a key to unlock this door";
                    }
                                 
                 }
                
            }
            else
            {
                item = "This door is already unlocked, you don't need a key";
            }
            return item;

        }

    }
}