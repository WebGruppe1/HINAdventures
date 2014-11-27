﻿using System;
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

        /// <summary>
        /// you get and argument, and checks that the argument you want to exam is not empty. 
        /// then he will find the thing you want to exam, and writ out the description of that item
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string RunCommand(string argument, string userId)
        {
            if (!argument.Equals(""))
                return repos.Examine(argument, userId);
            else
                return "Use of the commando, examine [item, room or person to be examined]";
        }
    }
}