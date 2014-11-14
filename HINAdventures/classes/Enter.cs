using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Enter : ICommand
    {
        private IRepository repo;
        
        public Enter()
        {
            repo = new Repository();
        }
        public String RunCommand(String room)
        {
            return repo.RoomDescription(room);
        }

    }
}