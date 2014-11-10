using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
	public class Help
	{
        public static string GetCommands(){
            string availableCommands = "List of available commands: \n";
            availableCommands += "help \n";
            availableCommands += "";

            return availableCommands; 
        }
	}
}