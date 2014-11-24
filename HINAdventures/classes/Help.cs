using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
	public class Help : ICommandNoArgs
	{
		public string RunCommand(){
			string availableCommands = "List of available commands:\n";


            availableCommands += "- Close [Object][Door]\n";
            availableCommands += "  Closes object/door\n";

            availableCommands += "- Drink [Object]\n";
            availableCommands += "  Tries to drink the object\n";

            availableCommands += "- Eat [Object]\n";
            availableCommands += "  Tries to eat the object\n";

            availableCommands += "- Enter [Roomname]\n";
            availableCommands += "  Enters room\n";

			availableCommands += "- Examine [Object]\n";
            availableCommands += "  Gives a decription of the object\n";

			availableCommands += "- Get [Object]\n";
            availableCommands += "  Puts the object in you inventory\n";

			availableCommands += "- Give [Playername] [Object]\n";
            availableCommands += "  Gives the object to another player\n";

			availableCommands += "- Help\n";
            availableCommands += "  Lists available commands\n";

			availableCommands += "- Hit [Playername]\n";
            availableCommands += "  Hits another player\n";

			availableCommands += "- Inventory\n";
            availableCommands += "  Lists all objects in your inventory\n";

			availableCommands += "- Kill [Playername]\n";
            availableCommands += "  Tries to kill another player\n";

			availableCommands += "- Kiss [Playername]\n";
            availableCommands += "  Tries to kiss another player\n";

            availableCommands += "- Open [Object][Door]\n";
            availableCommands += "  Opens object/door\n";

            availableCommands += "- Pick [Object]\n";
            availableCommands += "  Puts the object in you inventory\n";

            availableCommands += "- Scout\n";
            availableCommands += "  List available exits\n";


			availableCommands += "- Throw [Object]\n";
            availableCommands += "  Drops an object\n";
            

			availableCommands += "- Turn [on / off] [Object]\n";
            availableCommands += "  Turns object on or off\n";
			return availableCommands; 
		}
	}
}