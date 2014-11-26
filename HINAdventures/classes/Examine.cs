using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Examine : ICommandTwoArgs
    {
        private IRepository repos;

        public Examine()
        {
            repos = new Repository();
        }

        public Examine(IRepository _repo)
        {
            repos = _repo;
        }

        public string RunCommand(string argument, string userId)
        {
            if (!argument.Equals(""))
                return repos.Examine(argument, userId);
            else
                return "Use of the commando, examine [item or person to be examined]";
        }
    }
}