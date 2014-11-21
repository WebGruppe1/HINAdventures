using HINAdventures.Models;
using System;
using System.Collections.Generic;

namespace HINAdventures.classes
{
    public interface IRepository
    {
        String RoomDescription(String input);
        List<Item> GetEatableItems();
        List<Room> getAvailableRooms(String userID);
        List<Item> GetDrinkableItems();
        List<Item> GetAllItems();
        List<Item> GetInventory(string userId);
        void PutIntoInventory(string item, string userID);
        ApplicationUser GetUser(string userId);
        void UpdatePlayerPosition(String roomID, String userID);
        String ItemDescription(string item, string userId);
        List<ApplicationUser> GetAllUsers();

    }
}
