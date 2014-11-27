using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    /**Kristian Alm 27.11.2014
     * This class enables the use of examine commando
     */ 
    public class Examine : ICommandTwoArgs
    {
        private IRepository repos;

        public Examine()
        {
            repos = new Repository();
        }

        //Used when running tests
        public Examine(IRepository _repo)
        {
            repos = _repo;
        }

        //Returns a description of the argument provided, if no argument is provided a help sentence will be returned
        public string RunCommand(string argument, string userId)
        {
            if (!argument.Equals(""))
                return repos.Examine(argument, userId);
            else
                return "Use of the commando, examine [item, room or person to be examined]";
        }
    }
}