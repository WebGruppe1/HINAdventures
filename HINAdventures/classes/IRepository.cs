using System;
namespace HINAdventures.classes
{
    public interface IRepository
    {
        /// <summary>
        /// GetAllItems
        /// Returns all items in the db
        /// </summary>
        /// <returns>List with items</returns>
        System.Collections.Generic.List<HINAdventures.Models.Item> GetAllItems();
        /// <summary>
        /// GetAllUsers
        /// Returns all users in the db
        /// </summary>
        /// <returns>List of users</returns>
        System.Collections.Generic.List<HINAdventures.Models.ApplicationUser> GetAllUsers();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID">User id</param>
        /// <returns>List of rooms</returns>
        System.Collections.Generic.List<HINAdventures.Models.Room> getAvailableRooms(string userID);
        /// <summary>
        /// GetDrinkableItems
        /// 
        /// Returns a list of all drinkable items in db
        /// </summary>
        /// <returns>List of items</returns>
        System.Collections.Generic.List<HINAdventures.Models.Item> GetDrinkableItems();
        /// <summary>
        /// GetEatableItems
        /// 
        /// Returns a list of all Eatable items in db
        /// </summary>
        /// <returns>List of items</returns>
        System.Collections.Generic.List<HINAdventures.Models.Item> GetEatableItems();
        /// <summary>
        /// GetInventory
        /// 
        /// Returns a list of items for one user
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns>List of items</returns>
        System.Collections.Generic.List<HINAdventures.Models.Item> GetInventory(string userId);
        /// <summary>
        /// GetVirtualUserChatCommands
        /// 
        /// </summary>
        /// <param name="user">Virtual user</param>
        /// <returns></returns>
        System.Collections.Generic.List<HINAdventures.Models.VirtualUserChatCommands> GetVirtualUserChatCommands(HINAdventures.Models.VirtualUser user);
        /// <summary>
        /// GetVirtualUsers
        /// 
        /// Method that returns all virtual users in db
        /// </summary>
        /// <returns>List of virtualusers</returns>
        System.Collections.Generic.List<HINAdventures.Models.VirtualUser> GetVirtualUsers();
        /// <summary>
        /// GetAllWhiteBoardBlogs
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        System.Collections.Generic.List<HINAdventures.Models.WhiteBoardBlog> GetAllWhiteBoardBlogs();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">User id</param>
        /// <param name="message"> message</param>
        /// <returns></returns>
        HINAdventures.Models.WhiteBoardBlog GetWhiteBordByUserId(string userId, string message);
        /// <summary>
        /// Examine
        /// Examenes an item
        /// 
        /// </summary>
        /// <param name="item">Item name</param>
        /// <param name="userId">User id</param>
        /// <returns>Description of a item</returns>
        string Examine(string item, string userId);
        /// <summary>
        /// GetUser
        /// 
        /// Returns one user by id
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>one user</returns>
        HINAdventures.Models.ApplicationUser GetUser(string userId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        HINAdventures.Models.VirtualUser GetVirtualUser(string name);
        /// <summary>
        /// RoomDescription
        /// 
        /// Returns a description for a room
        /// </summary>
        /// <param name="roomName">Room name</param>
        /// <returns>Description</returns>
        string RoomDescription(string roomName);
        /// <summary>
        /// UpdatePlayerPosition
        /// 
        /// Updates the players position
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="userID">User id</param>
        /// <returns></returns>
        string UpdatePlayerPosition(string argument, string userID);
        /// <summary>
        /// PutIntoInventory
        /// 
        /// Method for updating the item you pick up
        /// </summary>
        /// <param name="item">item name</param>
        /// <param name="userID">User id</param>
        /// <returns>Message</returns>
        string PutIntoInventory(string item, string userID);
        /// <summary>
        /// UpdatePersonItem
        /// 
        /// Updates a persons item
        /// </summary>
        /// <param name="item_id">Item id</param>
        /// <param name="user">User</param>
        void UpdatePersonItem(int item_id, HINAdventures.Models.ApplicationUser user);
        /// <summary>
        /// GetItem
        /// Returns a Item with the name
        /// </summary>
        /// <param name="name">Item name</param>
        /// <returns>Item objekt</returns>
        HINAdventures.Models.Item GetItem(string name);

    }
}
