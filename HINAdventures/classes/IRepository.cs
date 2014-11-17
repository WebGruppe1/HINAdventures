using HINAdventures.Models;
using System;
using System.Collections.Generic;

namespace HINAdventures.classes
{
    public interface IRepository
    {
        String RoomDescription(String input);
        List<Item> GetEatableItems();
        String[] getAvailableRooms();
        List<Item> GetDrinkableItems();
        List<Item> GetAllItems();
        List<Item> GetInventory(string userId);
        ApplicationUser GetUser(string userId);

    }
}
