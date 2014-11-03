using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HINAdventures.Models
{
    public class Description
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual List<Item> Items { get; set; }
        public virtual List<ApplicationUser> Users { get; set; }

    }

}