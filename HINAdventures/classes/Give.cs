using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    /// <summary>
    /// Give.cs
    /// 
    /// Command to give a item to a user. retrieves item to a logged in user
    /// And checks if the person you've want to give an item to is in the same room.
    /// </summary>
    public class Give : ICommandTwoArgs
    {
        private IRepository repos;
        private List<Item> items;
        private List<ApplicationUser> users;
        public Give()
        {
            repos = new Repository();
            
        }
        public string RunCommand(string argument, string id)
        {
            items = repos.GetInventory(id);
            users = repos.GetAllUsers();
            string returnarg = "";
            string[] word = argument.Split(' ');

            if (word.Length == 3)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    ApplicationUser user = users[i];
                    if (user.FirstName.Equals(word.ElementAt(0)) || user.FirstName.ToLower().Equals(word.ElementAt(0)))
                    {
                        for (int j = 0; j < items.Count; j++)
                        {
                            Item it = items[j];

                            string item = word.ElementAt(1) + " " + word.ElementAt(2);
                            if (it.Name.Equals(item) || it.Name.ToLower().Equals(item))
                            {
                                ApplicationUser loggedInUser = repos.GetUser(id);
                                if (it.ApplicationUser.Id == loggedInUser.Id)
                                {
                                    repos.UpdatePersonItem(it.ID, user);
                                    returnarg = "You gave " + user.FirstName + " a " + it.Name;
                                }
                                break;
                            }
                            else
                            {
                                returnarg = "You can't give " + user.FirstName + " " + word.ElementAt(1) + " because it doesn't exist or because your not the owner";
                            }

                        }
                        break;
                    }
                    else
                    {
                        returnarg = "The person you are trying to give the item to does not exist";
                    }
                }
            }
            else
            {
                returnarg = "commando not recognized [give name item]";
            }
            return returnarg;
        }
    }
}