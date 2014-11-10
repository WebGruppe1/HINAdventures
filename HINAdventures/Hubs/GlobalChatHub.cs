using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace HINAdventures.Hubs
{
    public class GlobalChatHub : Hub
    {
        static ConcurrentDictionary<string, string> userList = new ConcurrentDictionary<string, string>();

        public void Send(string name, string message)
        {
            Clients.All.addNewMessageToPage(name, message);
        }

        public void Join(string userName, string id)
        {
            if (userList.ContainsKey(userName))
            {

            }

            else
            {
                userList.TryAdd(userName, id);
                foreach (KeyValuePair<String, String> entry in userList)
                    Clients.Caller.showConnected(entry.Key);
            }
            Clients.Others.showConnected(userName);
        }

        public void SendToSpecific(string name, string message, string to)
        {
            Clients.Caller.addNewMessageToPage(name, message);
            Clients.Client(userList[to]).addNewMessageToPage(name, message);
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var name = userList.FirstOrDefault(x => x.Value == Context.ConnectionId.ToString());
            string s;
            userList.TryRemove(name.Key, out s);
            return Clients.All.disconnected(name.Key);
        }
    }
}