using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    /// <summary>
    /// Kiss.cs
    /// 
    /// Command to kiss a person. checks if there is a user in the current room with the same 
    /// name as entered by user.
    /// </summary>
    public class Kiss : ICommandTwoArgs
    {
        private IRepository repo;
        public Kiss()
        {
            repo = new Repository();
        }
        public Kiss(IRepository _repo)
        {
            repo = _repo;
        }
        public string RunCommand(string person, string userID)
        {
            List<ApplicationUser> users = repo.GetAllUsers();
            ApplicationUser loggedInAs = repo.GetUser(userID);

            foreach(ApplicationUser user in users)
            {
                if (person.Equals(user.FirstName, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (loggedInAs.Room == user.Room)
                        return "You kissed " + person;
                    else
                        return "That person is not within kissing-range";
                }
            }

            return "You should not kiss that, it's weird...";
        }
    }
}