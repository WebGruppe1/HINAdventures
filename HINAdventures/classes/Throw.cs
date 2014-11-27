using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    /// <summary>
    /// Throw.cs
    /// 
    /// Kommando for å kaste. Sjekker om hvilke item innlogget bruker eier, som gir deg
    /// mulighet til å kaste det. Da er du ikke lenger eier av iteme.
    /// 
    /// </summary>
    public class Throw : ICommandTwoArgs
    {
        private IRepository repos;
        private List<Item> items;
        public Throw()
        {
            repos = new Repository();
        }
        public string RunCommand(string item, string userID)
        {
            items = repos.GetInventory(userID);

            string output = "";
            for (int i = 0; i < items.Count; i++)
            {
                Item it = items[i];
                ApplicationUser user = repos.GetUser(userID);
                if (it.Room.Id == user.Room.Id)
                {
                    if (it.Name.ToLower() == item || it.Name == item)
                    {
                        output = "You just threw a " + it.Name;
                        repos.UpdatePersonItem(it.ID, null);
                        break;
                    }
                    else
                    {
                        output = "You can't throw items you don't have, check your inventory";
                    }
                    
                }
                else
                {
                    output = "You can't throw items you don't have, check your inventory";

                }
            }
            return output;

        }
    }
}
