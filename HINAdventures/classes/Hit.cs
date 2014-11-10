using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Hit
    {

        public static string HitCommand(string item)
        {
            string hit = "You just struck a " + item;

            return hit;
        }
    }
}