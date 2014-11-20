using HINAdventures.Models;
using System;
using System.Collections.Generic;

namespace HINAdventures.classes
{
    public interface IRepository
    {
        String RoomDescription(String input);
        List<Item> GetEatableItems();
        List<String> getAvailableRooms(String userID);
        List<Item> GetDrinkableItems();
        List<Item> GetAllItems();
        List<Item> GetInventory(string userId);
        ApplicationUser GetUser(string userId);
        void UpdatePlayerPosition(String roomID, String userID);
        String ItemDescription(string item, string userId);

    }
}
