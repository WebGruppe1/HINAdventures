using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HINAdventures.Models;
using System.Timers;
using System.Threading;

namespace HINAdventures.classes
{
    public class Virtualuser : ICommand
    {
        private IRepository myRepository;
        private List<VirtualUser> usersInTheRoom;
        private List<VirtualUser> users;
        private string returnMessage;
        private ApplicationUser user;
        private bool stillInRoom;
        private static Dictionary<VirtualUser, int> positionInList = new Dictionary<VirtualUser, int>();

        public Virtualuser ()
        {
            myRepository = new Repository();
            usersInTheRoom = new List<VirtualUser>();
            users = myRepository.GetVirtualUsers();
            returnMessage = null;
            stillInRoom = true;
        }

        public string SayRegulary(string userId)
        {
            user = myRepository.GetUser(userId);

            foreach (VirtualUser vu in users)
            {
                if (!positionInList.ContainsKey(vu))
                    positionInList[vu] = 0;
                if (vu.Room.Id == user.Room.Id)
                {
                    int pos = positionInList[vu];
                    usersInTheRoom.Add(vu);
                    VirtualUserChatCommands vucc = vu.VirtualUserChatCommands[pos];

                    pos++;
                    if (pos >= vu.VirtualUserChatCommands.Count)
                        pos = 0;

                    positionInList[vu] = pos;
                    returnMessage += "Virtual user: " + vu.Name + " - " + vucc.ChatCommand + "\n";
                }
            }

            if (usersInTheRoom.Count == 0)
                returnMessage += "There is no virtual users in this room";

            return returnMessage;
        }

        public string RunCommand(string message)
        {
            try
            {
                if (message.Contains("Hi") || message.Contains("Hello") || message.Contains("hey") || message.Contains("god day"))
                    return "Hi :) how are you?";
                else if (message.Contains("How are you?"))
                    return "Im good thank you very much. what are you doing?";
                else if (message.Contains("What are you doing?"))
                    return "Nothing much, just chilling here where i stand, nothing much to do. what are you doing?";
                else if (message.Contains("I'm doing") || message.Contains("Im doing") || message.Contains("im doing") || message.Contains("i'm doing"))
                    return "Haha, nice. sounds like super fun. you should keep doing that. you will just get bored here with me, im like this puppet with limited words";
                else if (message.Contains("puppet"))
                    return "yeah puppet. boring as hell. I'm like this puppet without this hand up my ass that controls me, lucky me";
                else if (message.Contains("what can you"))
                    return "well, that aint much what i can do or say. very little, maybe ask someone other for more information or they can something more than me";
                else
                    return "Nah, i dont know man. you should ask someone other that question.";
            }
            catch (NullReferenceException)
            {
                return "Sorry, that user doesnt excist";
            }
        }
    }
}