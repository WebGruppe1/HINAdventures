using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Scout : ICommandNoArgs
    {
        private IRepository repo;
        public Scout()
        {
            repo = new Repository();
        }
        public String RunCommand()
        {
            String[] temp =  repo.getAvailableRooms();
            String returnString = "Nearby rooms: ";

            foreach(String s in temp)
            {
                returnString += s + ", ";
            }
            return returnString;
        }
    }
}