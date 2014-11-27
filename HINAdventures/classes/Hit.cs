using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    /// <summary>
    /// Hit.cs
    /// 
    /// Kommando for å slå en person eller et item. Sjekker om person og item er i samme rom som innlogget
    /// bruker. Slår du en person returnerer det tilfeldig hvor du slå personen.
    /// </summary>
    public class Hit : ICommandTwoArgs
    {
        private IRepository repos;
        private List<ApplicationUser> users;
        private string[] vitals = new[] { "face", "stomach", "arm", "fot", "back", "crotch", "chest" };
        private Random rand = new Random();
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
            ApplicationUser user = repos.GetUser(userID);
            users = repos.GetAllUsers();
            List<Item> items = repos.GetAllItems();

            for (int j = 0; j < users.Count; j++)
            {
                ApplicationUser players = users[j];
                if (players.FirstName.Equals(item) || players.FirstName.ToLower().Equals(item))
                {
                    if (user.Room.Id == players.Room.Id)
                    {
                        return "You just punched " + players.FirstName + " in the " + vitals.ElementAt(rand.Next(0, 7));
                    }
                }
            }

            for (int i = 0; i < items.Count; i++)
            {
                Item it = items[i];
                if (user.Room.Id == it.Room.Id)
                {
                    if (item == it.Name.ToLower() || item == it.Name)
                    {
                        return "You just struck a " + it.Name;
                    }
                }
            }
            return "The Item/Person you are trying to hit/struck does not exist in this room";

        }
    }
}