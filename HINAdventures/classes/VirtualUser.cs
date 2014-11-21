using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HINAdventures.Models;

namespace HINAdventures.classes
{
    public static class Virtualuser
    {
        private static IRepository myRepository = new Repository();

        public static string output()
        {
            string chatCommand = string.Empty;
            List<VirtualUser> users = myRepository.GetVirtualUsers();
            //int countdown = 20;
            foreach (VirtualUser user in users)
            {
                List<VirtualUserChatCommands> chatCommands = myRepository.GetVirtualUserChatCommandsToUser(user);
                List<VirtualUserChatCommands> notRegualaryChatCommands = myRepository.GetVirtualUserChatCommandsNotRegularyToUser(user);

                foreach (VirtualUserChatCommands command in chatCommands)
                {
                    chatCommand = command.ChatCommand;
                }
            }
            return chatCommand;
        }
        public static string ChatWithVirtualUser(string name, string message)
        {
            string newName = char.ToUpper(name[0]) + name.Substring(1);
            try
            {
                VirtualUser chattingWith = myRepository.GetVirtualUser("");
                if (message.Contains("Hi"))
                    return "Hi i am " + chattingWith.Name + " :) how are you?";
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