using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OutsideDescription { get; set; }
        public string Description { get; set; }

        public Room North { get; set; }
        public Room South { get; set; }
        public Room West { get; set; }
        public Room East { get; set; }


    }
}