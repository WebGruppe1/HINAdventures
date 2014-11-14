using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Drink : ICommand
    {    
        public string RunCommand(string item)
        {
            return "You drank " + item;
        }
    }
}