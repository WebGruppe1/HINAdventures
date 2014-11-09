using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;


namespace HINAdventures.Hubs
{
    [HubName("Command")]
    public class CommandHub : Hub
    {
        public void Command(string command)
        {
            string message = command + "\n";
//            string message = "Command does not exist";
            Clients.Caller.CommandResponse(message);
        }
    }
}