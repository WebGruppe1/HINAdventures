using HINAdventures.Hubs;
using HINAdventures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Diagnostics;

namespace HINAdventures.classes
{
    /// <summary>
    /// Repository class, all interaction with the database goes through here.
    /// Written by everyone, new methods added as they were needed.
    /// </summary>
    public class Repository : HINAdventures.classes.IRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        //Returns a list of rooms available from a given playerposition
        public List<Room> getAvailableRooms(String userID)
        {            
            List<Room> list = new List<Room>();
            ApplicationUser user = db.Users.Where(u => u.Id == userID).FirstOrDefault();

            foreach (Room room in user.Room.ConnectedRooms)
                list.Add(room);  
            
            return list;
        }

        //Returns eatable item
        public List<Item> GetEatableItems()
        {
            var eatItems = db.Items.Include("Room").Where(i => i.isEatable == true).ToList();
            return eatItems;
        }

        //Returns a list of all available items
        public List<Item> GetAllItems()
        {
            var itemListe = db.Items.ToList();
            return itemListe;
        }

        //Returns drinkable item
        public List<Item> GetDrinkableItems()
        {
            var drinkListe = db.Items.Include("Room").Where(i => i.isDrinkable == true).ToList();
            return drinkListe;
        }

        //Returns a room description string given a room name
        public String RoomDescription(String roomName)
        {
            var desc = from a in db.Rooms where a.Name == roomName select a.Description;
            return desc.FirstOrDefault();
        }

        //Returns item given a users id, a users inventory
        public List<Item> GetInventory(string userId)
        {
            var itemList = db.Items.Where(items => items.ApplicationUser.Id.Equals(userId)).ToList();
            return itemList;
        }

        //Puts an item into a users inventory, adds a userobject to the item
        public string PutIntoInventory(string item, string userID)
        {
            ApplicationUser user = GetUser(userID);
            var selectedItem = db.Items.Where(i => i.Name == item).FirstOrDefault();
            

            if(selectedItem != null && selectedItem.Room == user.Room)
            {
                if (selectedItem.ApplicationUser == null)
                {
                    selectedItem.ApplicationUser = user;
                    user.Items.Add(selectedItem);
                    db.SaveChanges();
                    return "You picked up " + item + "\n";
                }
                else if (selectedItem.ApplicationUser == user)
                    return "You already have that item in your inventory";
                else
                    return "Item not found";
                
            }

            else
                return "item not found\n";

        }

        //
        public void UpdatePersonItem(int item_id, ApplicationUser user)
        {
            var item = db.Items.Include("ApplicationUser").Where(i => i.ID == item_id).FirstOrDefault();
            item.ApplicationUser = user;
            db.SaveChanges();
        }

        //Returns an item object given an item name
        public Item GetItem(string name)
        {
            var item = db.Items.Include("ApplicationUser").Where(i => i.Name == name).FirstOrDefault();
            return item;
        }

        //Returns a list of all registered users
        public List<ApplicationUser> GetAllUsers()
        {
            var users = db.Users.ToList();
            return users;
        }

        //Gets a specific user from a given user id
        public ApplicationUser GetUser(string userId)
        {
            ApplicationUser user = db.Users.Where(u => u.Id == userId).FirstOrDefault();
            return user;
        }

        //Updates the players position, also updates position of all items belonging to that player
        public string UpdatePlayerPosition(String argument, String userID)
        {
            ApplicationUser user = db.Users.Where(u => u.Id == userID).FirstOrDefault();
            user.Room = db.Rooms.Where(r => r.Name == argument).FirstOrDefault();

            foreach (Item item in user.Items)
            {
                item.Room = user.Room;
            }
            
            List<Item> itemList = this.GetAllItems();
            foreach (Item item in itemList)
            {
                if(item.ApplicationUser != null)
                    if(user.Equals(item.ApplicationUser))
                        item.Room = user.Room;
            }
            
            db.SaveChanges();

            String returnMessage = string.Empty;

            //If a virtual user is present in the room entered, a few sentences will be added with the roomdescription from the virtual user
            List<VirtualUser> users = this.GetVirtualUsersInRoom(user.Room.Id);
            List<VirtualUserChatCommands> chatcomments = new List<VirtualUserChatCommands>();
            if (users.Count > 0)
            {
                Dictionary<VirtualUser, int> positionInList = new Dictionary<VirtualUser, int>();
                returnMessage = null;
                bool isRunning = true;
                while (isRunning)
                {
                    foreach (VirtualUser vu in users)
                    {
                        if (vu.VirtualUserChatCommands.Count > 0)
                        {
                            if (!positionInList.ContainsKey(vu))
                                positionInList[vu] = 0;
                            if (vu.Room.Id == user.Room.Id)
                            {
                                int pos = positionInList[vu];
                                VirtualUserChatCommands vucc = vu.VirtualUserChatCommands[pos];

                                positionInList[vu] = pos;
                                returnMessage += "Virtual user: " + vu.Name + " - " + vucc.ChatCommand + "\n";
                                vu.VirtualUserChatCommands.Remove(vucc);
                                isRunning = true;
                            }
                        }
                        else
                            isRunning = false;
                    }
                }
            }
            return returnMessage;
        }

        //Returns the description of an item, a room or a person
        public String Examine(string item, string userId)
        {
            string description = "";

            ApplicationUser user = this.GetUserFromName(item);      //Gets the user if it is a user
            ApplicationUser currentUser = this.GetUser(userId);     //Gets the current user
            Room room = this.GetRoom(item);                         //Gets the room if it is a room

            //If room returns a result, the description will be returned
            if (room != null)
            {
                if (room.Id == currentUser.Room.Id)
                    return room.Description;
                else
                    return "You need to be in a room to examine it.";
            }

            //If user is null, then the item to be examined must be an item or nothing.
            if (user == null)
            {
                try
                {
                    //Check if provided string exists in form of an item
                    Item itemFromDb = db.Items.Where(i => i.Name == item).FirstOrDefault();

                    //Returns a result based on item found or not, and if its in the same room
                    if (itemFromDb != null)
                    {
                        if (currentUser.Room.Id == itemFromDb.Room.Id)
                            description = itemFromDb.Description.Text;

                        else
                            description = "An item like that is not around here.";
                    }

                    else
                        description = "Does not seem like that item can be found anywhere at this school.";
                }
                catch (ArgumentNullException)
                {
                    description = "Does not seem like that item can be found anywhere at this school.";
                }
            }

            //This runs if the item to be examined is a player
            else
            {
                //Comment out for testing on your own user, checks if the user to be examined is yourself
                if (userId.Equals(user.Id))
                {
                    return "No reason to examine yourself, try inventory if you want to check your pockets.";
                }
                //

                //Checks if the user is in the same room as you
                if (currentUser.Room.Id != user.Room.Id)
                {
                    return "You need to be in the same room as the user you want to examine.";
                }

                //Returns information about the players inventory, if there is something in it
                List<Item> itemList = this.GetInventory(user.Id);
                StringBuilder tempDescription = new StringBuilder();

                tempDescription.Append("Your examination of " + user.UserName + " has revealed he is currently in the possesion of");

                if (itemList.Count > 0)
                {
                    tempDescription.Append(" the following items:");
                    foreach (Item i in itemList)
                    {
                        tempDescription.Append("\n" + i.Name);
                        description = tempDescription.ToString();
                    }
                }
                else
                {
                    tempDescription.Append(" no items worth taking notice of.");
                    description = tempDescription.ToString();
                }
            }
            return description;
        }

        //Used by the method Examine, returns a user object from a username
        private ApplicationUser GetUserFromName(string username)
        {
            try
            {
                ApplicationUser user = db.Users.Where(u => u.UserName == username).FirstOrDefault();
                return user;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }

        //Used by the method Examine, returns a room object from room name
        private Room GetRoom(string roomName)
        {
            Room room = db.Rooms.Where(w => w.Name == roomName).FirstOrDefault();
            return room;
        }

        //Returns a list of virtual users
        public List<VirtualUser> GetVirtualUsersInRoom(int roomId)
        {
            var users = from u in db.VirtualUser where u.Room.Id == roomId select u;
            return users.ToList();
        }

        //Returns a list of sentences said by the virtual player
        public List<VirtualUserChatCommands> GetVirtualUserChatCommands(VirtualUser user)
        {
            var chatCommands = from c in db.VirtualUserChatCommans
                               where c.VirtualUser.Id == user.Id
                               select c;
            return chatCommands.ToList();
        }

        //Gets a virtual user by name
        public VirtualUser GetVirtualUser(string name)
        {
            VirtualUser user = db.VirtualUser.Where(u => u.Name == name).FirstOrDefault();
         
            return user;
        }

        //Gets all comments written on the whiteboard
        public List<WhiteBoardBlog> GetAllWhiteBoardBlogs()
        {
            var list = db.WhiteBoardBlogs.ToList();
            return list;
        }


        public WhiteBoardBlog GetWhiteBordByUserId(string userId, string message)
        {
            try {
                ApplicationUser user = this.GetUser(userId);
                var item = db.WhiteBoardBlogs.Where(w => w.Room.Id == user.Room.Id).FirstOrDefault();
                item.Description += "\n" + message;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return item;
            } catch {
                return null;
            }
        }
    }
}