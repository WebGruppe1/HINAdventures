using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Kiss : ICommand
    {
        public string RunCommand(string person)
        {
            return "You kissed " + person;
        }
    }
}