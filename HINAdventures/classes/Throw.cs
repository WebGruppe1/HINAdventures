using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    public class Throw :ICommand
    {
        private IRepository repos;
        private List<Item> items;
        public Throw()
        {
            repos = new Repository();
        }
        public string RunCommand(string item)
        {
            items = repos.GetAllItems();
            return "";

        }
    }
}