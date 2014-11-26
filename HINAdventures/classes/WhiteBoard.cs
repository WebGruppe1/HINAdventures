﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HINAdventures.Models;

namespace HINAdventures.classes
{
    public class WhiteBoard : ICommandTwoArgs
    {
        private IRepository repos = new Repository();

        public string RunCommand(string message, string userId)
        {
            WhiteBoardBlog whiteBoard = repos.GetWhiteBordByUserId(userId, message);
            if (whiteBoard != null)
                return "Posts: \n" + whiteBoard.Description;
            else
                return "Det er ingen whiteboard i dette rommet, prøv et annet rom";
        }
    }
}