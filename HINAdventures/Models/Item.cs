using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.Models
{
    /// <summary>
    /// Entity item class. holds all the items in this game. which you can pick up/eat and others things. 
    /// holds foreignkeys like room so it knows where it is, a description and a user if a user holds it
    /// </summary>
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public bool isEatable { get; set; }
        public bool isDrinkable { get; set; }
        public virtual Room Room { get; set; }
        public virtual Description Description { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}