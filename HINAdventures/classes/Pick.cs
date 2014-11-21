using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Pick : ICommand
    {
        public string RunCommand(String item, String userID)
        {
            return "You picked up " + item;
        }
        public string RunCommand(String item)
        {
            return "You picked up " + item;
        }
    }
}