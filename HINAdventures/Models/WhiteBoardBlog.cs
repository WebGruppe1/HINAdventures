using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.Models
{
    /// <summary>
    /// Entityclass for the the table whiteboards. this is where you can write on a whitboard in a room.
    /// </summary>
    public class WhiteBoardBlog
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public virtual Room Room { get; set; }
    }
}