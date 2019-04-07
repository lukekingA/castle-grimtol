using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;
using static CastleGrimtol.Project.GameService;

namespace CastleGrimtol.Project.Models {
    public class Room : IRoom {
        public Room (string name, string desc) {
            Name = name;
            Description = desc;
            Items = new List<Item> ();
            Exits = new Dictionary<Direction, IRoom> ();
            LockedExits = new Dictionary<Direction, IRoom> ();
        }

        public void AddAdjacentRoom (Direction door, IRoom room) {
            Exits.Add (door, room);
        }
        public void AddLockedDoor (Direction door, IRoom room) {
            LockedExits.Add (door, room);
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }
        public Dictionary<Direction, IRoom> Exits { get; set; }
        public Dictionary<Direction, IRoom> LockedExits { get; set; }
    }
}