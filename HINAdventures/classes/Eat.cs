using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    /// <summary>
    /// Eat.cs
    /// 
    /// Kommando klasse for å spise noe. Henter ut en liste med items som kan
    /// spises og sjekker om iteme og bruker er i samme rom.
    /// </summary>
    public class Eat : ICommandTwoArgs
    {
        private IRepository repos;
        public Eat()
        {
            repos = new Repository();
        }
         public Eat(IRepository _repo)
        {
            repos = _repo;
        }
        public string RunCommand(string food, string userID)
        {


            List<Item> items = repos.GetEatableItems();
            
            if (items != null)
            {
                for (int i = 0; i < items.Count; i++)
                {

                    Item it = items[i];
                    ApplicationUser user = repos.GetUser(userID);
                    if (user.Room.Id == it.Room.Id)
                    {
                        if (food == it.Name || food == it.Name.ToLower() && it.isEatable)
                        {
                            return "You just ate " + food;
                        }
                    }
                }
            }
            return "You can't eat this";

        }      

    }
}