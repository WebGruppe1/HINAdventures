﻿using System;
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

        public string RunCommand(string argument, string userId)
        {
            return repos.ItemDescription(argument, userId);
        }
    }
}