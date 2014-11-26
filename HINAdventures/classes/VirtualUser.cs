using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HINAdventures.Models;

namespace HINAdventures.classes
{
    public class Virtualuser : ICommand
    {
        private IRepository myRepository = new Repository();

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