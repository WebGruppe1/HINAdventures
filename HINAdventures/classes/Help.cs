using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
	public class Help
	{
		public static string GetCommands(){
			string availableCommands = "List of available commands:\n";
			availableCommands += "- examine [Object]\n";
			availableCommands += "- get [Object]\n";
			availableCommands += "- give [Playername] [Object]\n";
			availableCommands += "- help\n";
			availableCommands += "- hit [Playername]\n";
			availableCommands += "- inventory\n";
			availableCommands += "- kill [Playername]\n";
			availableCommands += "- kiss [Playername]\n";
			availableCommands += "- shout [Message]\n";
			availableCommands += "- tell [Playername] [Message]\n";
			availableCommands += "- throw [Object]\n";
			availableCommands += "- turn [on / off]\n";
			return availableCommands; 
		}
	}
}