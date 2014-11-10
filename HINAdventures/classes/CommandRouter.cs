using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace HINAdventures.classes
{
	public static class CommandRouter
	{
		private static string commandRegex = @"(\S*) (.*)"; // Regex that splits the command from the argument

		/***
		 * Finds the command in a string and routes it
		 ***/
		public static string RouteCommand(string commandToBeInterpreted)
		{
			string command = string.Empty;
			string argument = string.Empty;

			Match match = Regex.Match(commandToBeInterpreted, commandRegex);
			
			if (match.Success)
			{
				command = match.Groups[1].Value;
				argument = match.Groups[2].Value;
			}

			else
			{
				command = commandToBeInterpreted;
			}

            string returnString = "-> " + command + " [" + argument + "] \n";

			switch (command.ToLower())
			{
				case "inventory":
					break;
				case "turn":
					break;
				case "hit":
					break;
				case "kill":
					break;
				case "kiss":
					break;
                case "enter":
                    returnString += Enter.EnterCommand(argument);
                    break;
				case "eat":
                    return Eat.EatCommand(argument);
				case "drink":
					return Drink.DrinkCommand(argument);
                case "pick":
                   return Pick.PickCommand(argument);
				case "get":
					break;
				case "throw":
					break; 
                case "open":
                    return Open.OpenCommand(argument);
				case "give":
					break;
				case "help":
					return Help.GetCommands();
				default:
					return "The command is not recognised";
			}
			return returnString;
		}
	}
}