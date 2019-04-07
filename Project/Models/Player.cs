using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models {
    public class Player : IPlayer {
        public Player (string name) {
            PlayerName = name;
            Items = new Dictionary<Item, bool> ();
        }

        public void ItemActiveSwitch (Item item) {
            if (Items.ContainsKey (item)) {
                Items[item] = !Items[item];
            }
        }
        public string PlayerName { get; private set; }

        public Dictionary<Item, bool> Items { get; set; }
    }
}