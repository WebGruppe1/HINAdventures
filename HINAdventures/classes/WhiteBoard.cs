using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HINAdventures.Models;

namespace HINAdventures.classes
{
    public class WhiteBoard : ICommandTwoArgs
    {
        private IRepository repos = new Repository();

        /// <summary>
        /// gets the message and userid and send it in to the repository which saves it in the database. then checks
        /// if it was sucesssful and then writes it out to the screen. if it fails there is a message for that too.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string RunCommand(string message, string userId)
        {
            WhiteBoardBlog whiteBoard = repos.GetWhiteBordByUserId(userId, message);
            if (whiteBoard != null)
                return "Posts: \n" + whiteBoard.Description;
            else
                return "There is no whiteboards in this room, try another room";
        }
    }
}