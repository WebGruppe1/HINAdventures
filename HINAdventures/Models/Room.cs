using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HINAdventures.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OutsideDescription { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Room> ConnectedRooms { get; set; }
        
       // public virtual ICollection<Room> RoomsConnectedToThisRoom { get; set; }
       // public virtual ICollection<Room> RoomsRoomIsConnectedTo { get; set; }

       /* public Room()
        {
            RoomsConnectedToThisRoom = new HashSet<Room>();
            RoomsRoomIsConnectedTo = new HashSet<Room>();
        }
        */
    }
}