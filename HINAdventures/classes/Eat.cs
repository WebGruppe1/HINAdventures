using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Eat
    {
        public static string EatCommand(string food)
        {

            string eat = "You just ate " + food;

            return eat;
        }

    }
}