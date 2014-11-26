using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.Models
{
    public class WhiteBoardBlog
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public virtual Room Room { get; set; }

        public WhiteBoardBlog()
        {
        }

        public WhiteBoardBlog(string description, ApplicationUser author)
        {
            Description = description;
            Created = DateTime.Now;
            Author = author;
            Room = author.Room;
        }
    }
}