using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project {
	public class GameService : IGameService {
		public GameService () {
			AvailableItems = new List<Item> ();
		}

		public Player CurrentPlayer { get; set; }

		public Room CurrentRoom { get; set; }

		public List<Item> AvailableItems { get; set; }

		public void Setup () {
			Room begin = new Room ("CodeWorks", "You are at the hackathon and it's after midnight. It seems that the bathroom is always busy so you need to use one on a different floor. Your phone is on your desk beside you. The elevator is to the north and the stairs are to the west");
			Room elevator = new Room ("Elevator", "The elevator door closes and you are unable to chose any floor but it begins to go down. The elevator stops at the first floor but the door doesn't open. You wait and press the door open button and nothing happens. Finnaly the door opens to the north");
			Room upstairs = new Room ("Second flood stair landing", "You enter the stairs and the door closes behind you. The first floor landing is below you to the north.");
			Room downstairs = new Room ("First floor stair landing", "You are standing at the bottom of the stairwell on the first floor");
			Room lobby = new Room ("Lobby", "As you enter the loby the outside doors are to the north. The elavator is to the south and the stairs to west. It is dark out side and raining.");
			Room outside = new Room ("Outside", "You push the doors to the parking lot the doors close behind you.");

			Item phone = new Item ("phone", "Cell Phone");
			Item card = new Item ("Key Card", "magnetic key card");

			begin.AddAdjacentRoom ("north", elevator);
			begin.AddAdjacentRoom ("west", upstairs);
			elevator.AddAdjacentRoom ("south", begin);
			elevator.AddAdjacentRoom ("north", lobby);
			lobby.AddAdjacentRoom ("south", elevator);
			lobby.AddAdjacentRoom ("north", outside);
			lobby.AddAdjacentRoom ("west", downstairs);
			outside.AddAdjacentRoom ("south", lobby);
			upstairs.AddAdjacentRoom ("east", begin);
			upstairs.AddAdjacentRoom ("north", downstairs);
			downstairs.AddAdjacentRoom ("south", upstairs);
			downstairs.AddAdjacentRoom ("east", lobby);

			CurrentRoom = begin;
		}

		public void Reset () {
			throw new NotImplementedException ();
		}

		public void StartGame () {
			throw new NotImplementedException ();
		}

		public void GetUserInput () {
			throw new NotImplementedException ();
		}

		public void Quit () {
			throw new NotImplementedException ();
		}

		public void Help () {
			System.Console.WriteLine (@"

                               ==============                                    
                               M            M                                    
                               M            M                                    
                               M            M                                    
                               M            M                                    
                               M            M                                    
                               M            M                                    
                               MMMMMMMMMMMMMM                                    
              ===============  ==============                                    
              M             M  M            M                                    
              M             M  M            M                                    
              M             M  M            M                                    
              M             M  M            M                                    
              M             M  M            M                                    
              M             M  M            M                                    
              M             M  MMMMMMMMMMMMMM                                    
              M             M  ==============                                    
              M             M  M            M                                    
              MMMMMMMMMMMMMMM  M            M                                    
                               M            M                                    
              MMMMMMMMMMMMMMM  M            M      ▲                             
              M             M  M            M      N                             
              M             M  M            M                                    
              M             M  MMMMMMMMMMMMMM                                    
              M             M  ==============                                    
              M             M  M      ▲     M                                    
              M             M  M            M                                    
              M             M  M      X     M                                    
              M             M  M ◄          M                                    
              M             M  M            M                                    
              M             M  M            M                                    
              MMMMMMMMMMMMMMM  MMMMMMMMMMMMMM                                    
");
			Console.Clear ();
			Console.WriteLine ("Directions to move");
			Console.WriteLine ("go forward, go back, go right, go left");
			Console.WriteLine ("In the stairs or elevator");
			Console.WriteLine ("go up, go down");
			Console.WriteLine ("Game Controls");
			Console.WriteLine ("(quit) to exit, (look) to describe where you are, (help) to get where you are.");
			Console.WriteLine ("Press enter to continue");
			ConsoleKeyInfo keyInfo = Console.ReadKey ();
			while (keyInfo.Key != ConsoleKey.Enter)
				Console.WriteLine ("Press enter to continue");
			keyInfo = Console.ReadKey ();

		}

		public void Go (string direction) {
			string[] input = direction.Split (" ");
			if (input[0].ToLower () == "go") {
				switch (input[1].ToLower ()) {
					case "north":
						return;
						break;
					case "south":
						return;
						break;
					case "east":
						return;
						break;
					case "west":
						return;
						break;
					case "up":
						return;
						break;
					case "down":
						return;
						break;
					default:
						Console.WriteLine ("Invalid choice. Please retry");
						break;
				}
			}
			Console.WriteLine ("Invalid choice. Please retry");
		}

		public void TakeItem (string itemName) {
			AvailableItems.ForEach (i => {
				if (i.Name == itemName) { }
				CurrentPlayer.Inventory.Add (i);
				AvailableItems.Remove (i);
			});
		}

		public void UseItem (string itemName) {
			throw new NotImplementedException ();
		}

		public void Inventory () {
			throw new NotImplementedException ();
		}

		public void Look () {
			throw new NotImplementedException ();
		}
	}
	public enum Direction {
		north = 1,
		south,
		east,
		west,
		up,
		down,
	}
}