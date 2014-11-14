using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.Models
{
    public class VirtualUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Room Room { get; set; }
        public virtual List<VirtualUserChatCommands> VirtualUserChatCommands { get; set; }
    }
}