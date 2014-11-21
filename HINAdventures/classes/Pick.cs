using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Pick
    {
        private IRepository repo;
        public Pick()
        {
            repo = new Repository();
        }
        public string RunCommand(String item, String userID)
        {
            repo.PutIntoInventory(item, userID);
            return "You picked up " + item;
        }
    }
}