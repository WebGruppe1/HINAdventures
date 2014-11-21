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
		public static string RouteCommand(string commandToBeInterpreted, string UserID)
		{
            ICommand runCommand = null;
            ICommandNoArgs runCommandNoArgs = null;
            ICommandTwoArgs runCommandTwoArgs = null;

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
                case "userid":
                    return UserID;
                case "intro":
                    runCommand = new Intro();
                    return runCommand.RunCommand(UserID);
				case "inventory":
					runCommand = new Inventory();
                    return runCommand.RunCommand(UserID);
				case "turn":
                    returnString += Turn.TurnCommand(argument);
                    break;
				case "hit":
                    runCommandTwoArgs = new Hit();
                    returnString += runCommandTwoArgs.RunCommand(argument, UserID);
                    break;
				case "kill":
                    runCommand = new Kill();
                    returnString += runCommand.RunCommand(argument);
					break;
				case "kiss":
                    runCommand = new Kiss();
                    returnString += runCommand.RunCommand(argument);
                    break;
                case "enter":
                    Enter enter = new Enter();
                    returnString += enter.RunCommand(argument, UserID);
                    break;
				case "eat":
                    runCommandTwoArgs = new Eat();
                    returnString += runCommandTwoArgs.RunCommand(argument, UserID);
                    break;
				case "drink":
                    runCommand = new Drink();
                    returnString += runCommand.RunCommand(argument);
                    break;
                case "pick":
                    Pick pick = new Pick();
                    returnString += pick.RunCommand(argument, UserID);
                    break;
				case "get":
					break;
				case "throw":
                    runCommandTwoArgs = new Throw();
                    returnString += runCommandTwoArgs.RunCommand(argument, UserID);
                    break;
                case "scout":
                    runCommand = new Scout();
                    String returnStr = "-> " + command + "\n";
                    return returnStr += runCommand.RunCommand(UserID);
                case "open":
                    runCommand = new Open();
                    returnString += runCommand.RunCommand(argument);
                    break;
				case "give":
                    runCommandTwoArgs = new Give();
                    returnString += runCommandTwoArgs.RunCommand(argument, UserID);
					break;
                case "examine":
                    runCommandTwoArgs = new Examine();
                    returnString += runCommandTwoArgs.RunCommand(argument, UserID);
                    break;
                case "help":
                    runCommandNoArgs = new Help();
                    returnStr = "-> " + command + "\n";
                    return returnStr += runCommandNoArgs.RunCommand();
				default:
					return "The command is not recognised";
			}
			return returnString;
		}
	}
}