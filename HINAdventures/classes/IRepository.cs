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
        HINAdventures.Models.ApplicationUser GetUser(string userId);
        HINAdventures.Models.VirtualUser GetVirtualUser(string name);
        System.Collections.Generic.List<HINAdventures.Models.VirtualUserChatCommands> GetVirtualUserChatCommandsNotRegularyToUser(HINAdventures.Models.VirtualUser user);
        System.Collections.Generic.List<HINAdventures.Models.VirtualUserChatCommands> GetVirtualUserChatCommandsToUser(HINAdventures.Models.VirtualUser user);
        System.Collections.Generic.List<HINAdventures.Models.VirtualUser> GetVirtualUsers();
        string ItemDescription(string item, string userId);
        string RoomDescription(string roomName);
        void UpdatePlayerPosition(string argument, string userID);
        string PutIntoInventory(string item, string userID);
        void UpdatePersonItem(int item_id, string userID);

    }
}
