﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Open : ICommand
    {
        public string RunCommand(string item)
        {
            return item + " is open";
        }

    }
}