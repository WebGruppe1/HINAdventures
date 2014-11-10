using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace HINAdventures.Hubs
{
    /// <summary>
    /// This takes care of the chat function between players in the game
    /// Kristian Alm 10.11.2014
    /// </summary>
    public class GlobalChatHub : Hub
    {
        //List of all online players
        static ConcurrentDictionary<string, string> userList = new ConcurrentDictionary<string, string>();

        //Send the name with the message to all players connected
        public void Send(string name, string message)
        {
            Clients.All.addNewMessageToPage(name, message);
        }

        //Add the new player to the list of players and send the information about the new player to all others.
        public void Join(string userName, string id)
        {
            //Does nothing if player is already in the list
            if (userList.ContainsKey(userName))
            {

            }
            
            //The player entering the chatroom gets a list of all players online
            else
            {
                userList.TryAdd(userName, id);
                foreach (KeyValuePair<String, String> entry in userList)
                    Clients.Caller.showConnected(entry.Key);
            }
            //Update all other with information about the new player
            Clients.Others.showConnected(userName);
        }

        //Private chat between two players, sends message to specific player
        public void SendToSpecific(string name, string message, string to)
        {
            Clients.Caller.addNewMessageToPage(name, message);
            Clients.Client(userList[to]).addNewMessageToPage(name, message);
        }

        //On disconnect from signalR it removes you from the list and sends information to a function in GlobalChat.cshtml
        public override Task OnDisconnected(bool stopCalled)
        {
            var name = userList.FirstOrDefault(x => x.Value == Context.ConnectionId.ToString());
            string s;
            userList.TryRemove(name.Key, out s);
            return Clients.All.disconnected(name.Key);
        }
    }
}