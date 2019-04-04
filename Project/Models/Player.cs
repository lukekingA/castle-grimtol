using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models {
    public class Player : IPlayer {
        public Player (string name) {
            PlayerName = name;
            Inventory = new List<Item> ();
        }

        public string PlayerName { get; private set; }
        public List<Item> Inventory { get; private set; }

    }
}