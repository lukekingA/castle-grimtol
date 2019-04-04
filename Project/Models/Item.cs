using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models {
    public class Item : IItem {
        public Item (string name, string desc) {
            Name = name;
            Description = desc;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}