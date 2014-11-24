using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.Models
{
    public class WhiteBoardComment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public virtual WhiteBoardBlog Blog { get; set; }
    }
}