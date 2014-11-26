using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HINAdventures.Models;

namespace HINAdventures.classes
{
    public class WhiteBoard
    {
        private IRepository repos = new Repository();

        public string RunCommand(string title, string message, string userId)
        {
            List<WhiteBoardBlog> list = repos.GetAllWhiteBoards();
            ApplicationUser user = repos.GetUser(userId);
            string returnMessage = null;
            WhiteBoardBlog blog = new WhiteBoardBlog(message, user);
            list.Add(blog);
            foreach (WhiteBoardBlog wh in list)
            {
                returnMessage = "Post: " + wh.Description + "\nAuthor: " + wh.Author.FirstName + " " + wh.Author.LastName;
            }
            return returnMessage;
        }
    }
}