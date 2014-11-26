using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.Models
{
    public class VirtualUserChatCommands
    {
        public int Id { get; set; }
        public string ChatCommand { get; set; }
        public virtual VirtualUser VirtualUser { get; set; }
    }
}