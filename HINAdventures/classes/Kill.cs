using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.classes
{
    /// <summary>
    /// Kill.cs
    /// 
    /// Kommando for å drepe en person. Sjekker om du er i samme rom som personen. 
    /// Returnerer et tilfeldig svar om dreping(at det ikke er lov). 
    /// Inneholder en sjekk om du dreper en zombie, da får du en nøkkel til et hemmelig
    /// rom.
    /// </summary>
    public class Kill : ICommandTwoArgs
    {
        private string[] str = new[]
        {"Are you out of you mind? you can't kill innocent people!",
         "It is wrong to kill people! shame on you for thinking that",
         "If you kill this person. Ask yourself, what would jesus do?",
         "If you kill people, that will make you a murderer",
        "You should go to jail for thinking that!"};
        private List<ApplicationUser> users;
        private IRepository repos;
        private Random rand = new Random();

        public Kill()
        {
            repos = new Repository();
            users = repos.GetAllUsers();
        }
        public string RunCommand(string arg, string userID)
        {
            string killresponse = "";
            if (users != null)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    ApplicationUser user = users[i];

                    if (user.FirstName.Equals(arg) || user.FirstName.ToLower().Equals(arg))
                    {
                        killresponse = str.ElementAt(rand.Next(0, 5));
                        break;
                    }
                    else if (arg.Equals("zombie") && user.Room.Id == 21)
                    {

                        Item item = repos.GetItem("Brown key");
                        if (item.ApplicationUser != null)
                        {
                            if (item.ApplicationUser.Id.Equals(userID))
                            {
                                killresponse = "You killed the zombie again, and you already have the key for the door. Check your inventory";
                                break;
                            }
                            else
                            {
                                killresponse = "You killed the zombie, thank god for that! " + "You must ask " + item.ApplicationUser.FirstName + " for the key";
                            }
                        }
                        else if(item.Room.Id == 21)
                        {
                            ApplicationUser loggedinUser = repos.GetUser(userID);
                            killresponse = "You killed the zombie, thank god for that! " +
                           "you will now be given a key that will open a secret door";
                            repos.UpdatePersonItem(item.ID, loggedinUser);
                            break;
                        }
                        else
                        {
                            killresponse = "You killed the zombie, thank god for that!" +
                                " the key is not here, somebody have been before you and "
                                + " dropped it somewhere" + " hint: " + item.Room.Name;
                        }
                        break;
                    }
                    else
                    {
                        killresponse = "This person does not exist";

                    }

                }
            }
            else
            {
                killresponse = "This person does not exist";

            }
            return killresponse;

        }

    }
}