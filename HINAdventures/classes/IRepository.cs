using System;
namespace HINAdventures.classes
{
    public interface IRepository
    {
        System.Collections.Generic.List<HINAdventures.Models.Item> GetAllItems();
        System.Collections.Generic.List<HINAdventures.Models.ApplicationUser> GetAllUsers();
        System.Collections.Generic.List<HINAdventures.Models.Room> getAvailableRooms(string userID);
        System.Collections.Generic.List<HINAdventures.Models.Item> GetDrinkableItems();
        System.Collections.Generic.List<HINAdventures.Models.Item> GetEatableItems();
        System.Collections.Generic.List<HINAdventures.Models.Item> GetInventory(string userId);
        System.Collections.Generic.List<HINAdventures.Models.VirtualUserChatCommands> GetVirtualUserChatCommands(HINAdventures.Models.VirtualUser user);
        System.Collections.Generic.List<HINAdventures.Models.VirtualUser> GetVirtualUsers();
        System.Collections.Generic.List<HINAdventures.Models.WhiteBoardBlog> GetAllWhiteBoardBlogs();
        HINAdventures.Models.WhiteBoardBlog GetWhiteBordByUserId(string userId, string message);
        string Examine(string item, string userId);
        HINAdventures.Models.ApplicationUser GetUser(string userId);
        HINAdventures.Models.VirtualUser GetVirtualUser(string name);
        string RoomDescription(string roomName);
        void UpdatePlayerPosition(string argument, string userID);
        string PutIntoInventory(string item, string userID);
        void UpdatePersonItem(int item_id, HINAdventures.Models.ApplicationUser user);
        HINAdventures.Models.Item GetItem(string name);

    }
}
