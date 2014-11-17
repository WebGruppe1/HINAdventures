using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using HINAdventures.classes;
using HINAdventures.Models;


namespace HINAdventures.Hubs
{
    [HubName("Command")]
    public class CommandHub : Hub
    {
        public void Command(string command, string userID)
        {
            // Start on method to map user to command...
           /*
            * string id = Context.ConnectionId;
           var name = Context.User.Identity.Name;
           using (var db = new ApplicationDbContext())
           {
           }
           */
   
           string commandResponse = CommandRouter.RouteCommand(command, userID);
            Clients.Caller.CommandResponse(commandResponse + "\n");
        }
    }
}