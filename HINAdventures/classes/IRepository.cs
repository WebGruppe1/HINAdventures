using HINAdventures.Models;
using System;
using System.Collections.Generic;

namespace HINAdventures.classes
{
    public interface IRepository
    {
        List<String> getAvailableRooms();
        List<Item> GetAllItems();
    }
}
