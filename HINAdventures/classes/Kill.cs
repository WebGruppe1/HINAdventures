using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Kill : ICommand
    {
        private string[] str = {"Are you out of you mind? you can't kill innocent people!",
                                   ""};
        public string RunCommand(string arg)
        {
            return "";
        }

    }
}