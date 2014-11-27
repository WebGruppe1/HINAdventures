using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace HINAdventures.Models
{
    /// <summary>
    /// Entity virtual user class with a foreignkey to another entitytable which holde all the comments that virtual 
    /// users say by them selvs.
    /// class holds id for identification, name for just having a name, a room where they belong and a list of 
    /// comments.
    /// </summary>
    public class VirtualUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Room Room { get; set; }
        public virtual List<VirtualUserChatCommands> VirtualUserChatCommands { get; set; }
    }
}