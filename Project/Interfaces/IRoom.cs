using System.Collections.Generic;
using CastleGrimtol.Project.Models;
using static CastleGrimtol.Project.GameService;

namespace CastleGrimtol.Project.Interfaces {
    public interface IRoom {
        string Name { get; }
        string Description { get; }
        List<Item> Items { get; set; }
        Dictionary<Direction, IRoom> Exits { get; }
    }
}