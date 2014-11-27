using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.Models
{
    /// <summary>
    /// this entity class that holds all the comments a virtual user can say without you chating with it.
    /// </summary>
    public class VirtualUserChatCommands
    {
        public int Id { get; set; }
        public string ChatCommand { get; set; }
        public virtual VirtualUser VirtualUser { get; set; }
    }
}