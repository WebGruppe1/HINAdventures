using HINAdventures.Models;
using System;
using System.Collections.Generic;

namespace HINAdventures.classes
{
    public interface IRepository
    {
        String RoomDescription(String input);
        IEnumerable<Item> getSpecificItem(String input);

        String[] getAvailableRooms();
        List<Item> GetAllItems();
    }
}
