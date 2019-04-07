using System.Collections.Generic;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project.Interfaces {
    public interface IPlayer {
        string PlayerName { get; }
        Dictionary<Item, bool> Items { get; }
    }
}