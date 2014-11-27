using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    /// <summary>
    /// Updates the inventory of a player with the selected item and returns a string with info.
    /// </summary>
    public class Pick : ICommandTwoArgs
    {
        private IRepository repo;

        public Pick ()
        {
            repo = new Repository();
        }

        /// <summary>
        /// puts the item into the inventory a player owns
        /// </summary>
        /// <param name="item"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public string RunCommand(String item, String userID)
        {
            return repo.PutIntoInventory(item, userID);
        }

        /// <summary>
        /// the player picks up an item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string RunCommand(String item)
        {
            return "You picked up " + item;
        }
    }
}