using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project {
	public class GameService : IGameService {

		Player player { get; set; }

		List<Item> AvailableItems { get; set; }

		public void Setup () {
			throw new NotImplementedException ();
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
                    MMMMMMMMMMMMMMMMMMMMMMMMM
                    MM-___________________-MM
                    MM-|                 |-MM
                    MM-|                 |-MM
                    MM-|                 |-MM
                    MM-|                 |-MM
                    MM-|     Outside     |-MM
                    MM-|                 |-MM
                    MM-|                 |-MM
 MMMMMMMMMMMMMMMMMMMMM-|_________________|-MMMMMMMMMMMMMMMMMMMMM
 MMM-                                                        -MM
 MM- _______________________________________________________ -MM
 MM-|                                                       |-MM
 MM-|                                                       |-MM
 MM-|                                                       |-MM
 MM-|                         Lobby                         |-MM
 MM-|                                                       |-MM
 MM-|                                                       |-MM
 MM-|_______________________________________________________|-MM
 MMM                                                         MMM
 MM-________________________________________________________ -MM
 MM-|               | |                   | |               |-MM
 MM-|               | |         F         | |               |-MM
 MM-|               | |                   | |               |-MM
 MM-|     Stairs    | | R  You are Here L | |    Elavator   |-MM
 MM-|               | |                   | |               |-MM
 MM-|               | |                   | |               |-MM
 MM-|               | |         B         | |               |-MM
 MM-|_______________| |___________________| |_______________|-MM
 MMMM                                                        MMM
 MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
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
					case "forward":
						return
						break;
					case "backward":
						return
						break;
					case "right":
						return
						break;
					case "left":
						return
						break;
					case "up":
						return
						break;
					case "down":
						return
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
				player.Inventory.Add (i);
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
}