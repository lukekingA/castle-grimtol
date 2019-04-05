using System.Collections.Generic;
using CastleGrimtol.Project.Models;
using static CastleGrimtol.Project.GameService;

namespace CastleGrimtol.Project.Interfaces {
    public interface IRoom {
        string Name { get; set; }
        string Description { get; set; }
        List<Item> Items { get; set; }
        Dictionary<Direction, IRoom> Exits { get; set; }
    }
}