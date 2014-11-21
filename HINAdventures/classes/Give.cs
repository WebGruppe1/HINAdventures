using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Give : ICommandTwoArgs
    {
        private IRepository repos;
        private List<Item> items;
        private List<ApplicationUser> users;
        public Give()
        {
            repos = new Repository();
            items = repos.GetAllItems();
            users = repos.GetAllUsers();
        }
        public string RunCommand(string argument, string id)
        {
            return "";
        }
    }
}