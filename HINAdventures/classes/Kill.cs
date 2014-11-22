using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Kill : ICommand
    {
        private string[] str = new[]
        {"Are you out of you mind? you can't kill innocent people!",
         "It is wrong to kill people! shame on you for thinking that",
         "If you kill this person. Ask yourself, what would jesus do?",
         "If you kill people, that will make you a murderer",
        "You should go to jail for thinking that!"};
        private List<ApplicationUser> users;
        private IRepository repos;
        private Random rand = new Random();

        public Kill()
        {
            repos = new Repository();
            users = repos.GetAllUsers();
        }
        public string RunCommand(string arg)
        {
            string killresponse = "";
            if (users != null)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    ApplicationUser user = users[i];

                    if (user.FirstName.Equals(arg) || user.FirstName.ToLower().Equals(arg))
                    {
                        killresponse = str.ElementAt(rand.Next(0, 5));
                        break;
                    }
                    else
                    {
                        killresponse = "This person does not exist";

                    }

                }
            }
            else
            {
                killresponse = "This person does not exist";

            }
            return killresponse;

        }

    }
}