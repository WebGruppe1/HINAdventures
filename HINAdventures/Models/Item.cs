using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.Models
{
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