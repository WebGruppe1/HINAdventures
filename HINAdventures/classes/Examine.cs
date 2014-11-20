using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Examine : ICommand
    {
        private IRepository repos;

        public Examine()
        {
            repos = new Repository();
        }

        public string RunCommand(string argument)
        {
            return repos.ItemDescription(argument);
        }
    }
}