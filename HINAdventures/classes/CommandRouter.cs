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

            ICommand runCommand = null;

			switch (command.ToLower())
			{
				case "inventory":
					break;
				case "turn":
					break;
				case "hit":
                    runCommand = new Hit();
                    returnString += runCommand.RunCommand(argument);
                    break;
				case "kill":
					break;
				case "kiss":
                    runCommand = new Kiss();
                    return runCommand.RunCommand(argument);
                case "enter":
                    runCommand = new Enter();
                    returnString += runCommand.RunCommand(argument);
                    break;
				case "eat":
                    runCommand = new Eat();
                    return runCommand.RunCommand(argument);
				case "drink":
                    runCommand = new Drink();
                    return runCommand.RunCommand(argument);
                case "pick":
                    runCommand = new Pick();
                    return runCommand.RunCommand(argument);
				case "get":
					break;
				case "throw":
					break; 
                case "open":
                    runCommand = new Open();
                    return runCommand.RunCommand(argument);
				case "give":
					break;
				case "help":
					return Help.GetCommand();
				default:
					return "The command is not recognised";
			}
			return returnString;
		}
	}
}