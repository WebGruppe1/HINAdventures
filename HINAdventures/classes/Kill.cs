using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Kill : ICommand
    {
        private string[] str = new []
        {"Are you out of you mind? you can't kill innocent people!",
         "It is wrong to kill people! shame on you for thinking that",
         "Ask yourself, what would jesus do?"};
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
            string kill = "";
            for (int i = 0; i < users.Count; i++)
            {
                ApplicationUser user = users[i];
                if (user.FirstName == arg)
                {
                    kill = str.ElementAt(rand.Next(0, 2));
                }
                else
                {
                    kill = "This person does not exist";
                }
            }

            return kill;

        }

    }
}