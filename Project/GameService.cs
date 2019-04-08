using System;
using System.Collections.Generic;
using System.Linq;
using CastleGrimtol.Project.Images;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project {
	public class GameService : IGameService {

		public enum Direction {
			north = 1,
			south,
			east,
			west,
			up,
			down,
		}
		public Player CurrentPlayer { get; set; } = null;

		public Room CurrentRoom { get; set; }
		public Room LastRoom { get; set; }

		Room WinRoom { get; set; }

		bool GameLoop { get; set; } = true;

		public bool GameWon { get; set; }

		Maps map = new Maps ();

		public void Setup () {

			Room begin = new Room ("Code Works", "The elevator is to the north and the stairs are to the west");
			Room elevator = new Room ("Elevator", "The elavator door closes and you press the Button for your choice.");
			Room upstairs = new Room ("Second floor stair landing", "You enter the stairs and the door closes behind you.\nThe first floor landing is below you to the north.");
			Room downstairs = new Room ("First floor stair landing", "You are standing at the bottom of the stairwell on the first floor");
			Room lobby = new Room ("Lobby", "As you enter the loby the outside doors are to the north. The elavator is to the south and the stairs to west.\nIt is dark out side and raining.");
			Room rest = new Room ("Rest Room", "This is what you came for!");
			Room outside = new Room ("Outside", "You push the doors to the parking lot open and go outside.\nThe doors close behind you.");
			Room unlock = new Room ("Unlock", "You should never see this description");

			Item phone = new Item ("Phone", "your cell (phone)");
			Item card = new Item ("Key", "a magnetic (key) card");
			begin.Items.Add (phone);
			downstairs.Items.Add (card);

			begin.AddAdjacentRoom (Direction.north, elevator);
			begin.AddAdjacentRoom (Direction.west, upstairs);
			elevator.AddLockedDoor (Direction.up, begin);
			elevator.AddAdjacentRoom (Direction.down, lobby);
			lobby.AddAdjacentRoom (Direction.south, elevator);
			lobby.AddAdjacentRoom (Direction.north, outside);
			lobby.AddAdjacentRoom (Direction.west, downstairs);
			lobby.AddAdjacentRoom (Direction.east, rest);
			rest.AddAdjacentRoom (Direction.west, lobby);
			outside.AddLockedDoor (Direction.south, lobby);
			upstairs.AddLockedDoor (Direction.east, begin);
			upstairs.AddAdjacentRoom (Direction.north, downstairs);
			downstairs.AddAdjacentRoom (Direction.south, upstairs);
			downstairs.AddAdjacentRoom (Direction.east, lobby);
			unlock.AddAdjacentRoom (Direction.up, begin);
			unlock.AddAdjacentRoom (Direction.east, begin);

			CurrentRoom = begin;
			WinRoom = unlock;
			GameWon = false;
		}

		public void RoomGraphic () {
			map.Image (CurrentRoom.Name);
		}
		public void EnterRoom () {
			Console.Clear ();
			System.Console.WriteLine ("\n\n");
			RoomGraphic ();
			Console.ForegroundColor = ConsoleColor.Yellow;
			System.Console.Write ($"{CurrentPlayer.PlayerName} you are ");
			switch (CurrentRoom.Name) {
				case "Code Works":
					Console.Write ("at ");
					break;

				case "Second floor stair landing":
				case "First floor stair landing":
					Console.Write ("at the ");
					break;
				case "Elevator":
				case "Rest Room":
				case "Lobby":
					Console.Write ("in the ");
					break;
				case "Outside":
					Console.Write (" ");
					break;
			}
			Console.Write ($"{ CurrentRoom.Name }");
			System.Console.WriteLine (" ");
			System.Console.WriteLine (CurrentRoom.Description);

			System.Console.WriteLine ("\n");
			Console.ResetColor ();
		}

		public void GetUserInput () {

			Console.ForegroundColor = ConsoleColor.Blue;
			System.Console.WriteLine ("To move type (go) and a direction (north), (south), (east), (west), (up), or (down)");
			System.Console.WriteLine ("\n");
			System.Console.WriteLine ("You can type\n(H) for help,\n(Q) to quit,\n(L) to look for items to pickup in the room,\n(R) to restart,\n(I) to see the items that you have picked up,\n(T) to take an available item,\nTo use an item:\n (use) (item) then (go) (direction)");
			System.Console.WriteLine ("\n");
			System.Console.Write ("What would you like to do?  ");
			//System.Console.WriteLine ("\n");
			Console.ForegroundColor = ConsoleColor.Green;
			string PlayerChioce = Console.ReadLine ();
			Console.ResetColor ();
			string choice = PlayerChioce.ToLower ().Trim ();
			switch (choice) {
				case "go north":
					Go ("go north");
					break;
				case "go south":
					Go ("go south");
					break;
				case "go east":
					Go ("go east");
					break;
				case "go west":
					Go ("go west");
					break;
				case "go up":
					Go ("go up");
					break;
				case "go down":
					Go ("go down");
					break;
				case "use key go up":
					UseItem ("use key go up");
					break;
				case "use key go west":
					UseItem ("use key go west");
					break;
				case "use phone go east":
					UseItem ("use phone go east");
					break;
				case "use phone go up":
					UseItem ("use phone go up");
					break;
				case "h":
					Console.Clear ();
					Help ();
					break;
				case "q":
					Console.Clear ();
					Quit ();
					break;
				case "l":
					Look ();
					break;
				case "r":
					Reset ();
					break;
				case "i":
					Inventory ();
					break;
				case "t":
					if (CurrentRoom.Items.Count > 0) {
						TakeItem (CurrentRoom.Items[0]);
					}
					break;
				default:
					EnterRoom ();
					System.Console.WriteLine ("Not a valid entry. Try again.");
					break;
			}
		}

		public void Go (string direction) {
			string[] input = direction.Split (" ");

			if (input[0].ToLower () == "go") {
				switch (input[1].ToLower ()) {
					case "north":
						SetRoom (Direction.north);
						break;
					case "south":
						SetRoom (Direction.south);
						break;
					case "east":
						SetRoom (Direction.east);
						break;
					case "west":
						SetRoom (Direction.west);
						break;
					case "up":
						SetRoom (Direction.up);
						break;
					case "down":
						SetRoom (Direction.down);
						break;
					default:
						EnterRoom ();
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine ("Invalid choice. Please retry");
						System.Console.WriteLine ("\n");
						Console.ResetColor ();
						break;
				}
			}

		}
		// Set room Location
		public void SetRoom (Direction dir) {
			if (CurrentRoom.LockedExits.ContainsKey (dir)) {
				EnterRoom ();
				Console.ForegroundColor = ConsoleColor.Red;
				System.Console.WriteLine ($"The door to your {dir} is locked.");
				System.Console.WriteLine ("\n");
				Console.ResetColor ();
			} else
			if (CurrentRoom.Exits.ContainsKey (dir)) {
				LastRoom = CurrentRoom;
				CurrentRoom = (Room) CurrentRoom.Exits[dir];
				EnterRoom ();
			} else {
				EnterRoom ();
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine ("Invalid choice. Retry");
				System.Console.WriteLine ("\n");
				Console.ResetColor ();
			}
		}

		public void Help () {
			map.Image ("Help Map");
			System.Console.WriteLine ("\n");
			Console.WriteLine ("Directions to move");
			Console.WriteLine ("go forward, go back, go right, go left");
			Console.WriteLine ("In the stairs or elevator");
			Console.WriteLine ("go up, go down");
			Console.WriteLine ("Game Controls");
			Console.WriteLine ("(Q) to exit, (L) to describe where you are, (H) to get where you are.");

			bool entered = true;
			while (entered) {
				Console.WriteLine ("Press enter to continue");
				ConsoleKeyInfo keyInfo = Console.ReadKey ();
				if (keyInfo.Key == ConsoleKey.Enter) {
					entered = false;
					EnterRoom ();

				}
				continue;
			}

		}
		public void Inventory () {
			EnterRoom ();
			Console.ForegroundColor = ConsoleColor.Yellow;
			System.Console.Write ("You have ");
			if (CurrentPlayer.Items.Any ()) {
				foreach (KeyValuePair<Item, bool> item in CurrentPlayer.Items) {
					System.Console.Write ($"{item.Key.Name}");
					if (CurrentPlayer.Items.Count > 1) {
						Console.Write (", ");
					} else {
						Console.Write (" ");
					}
				}
				System.Console.WriteLine ("collected so far");
			} else {
				System.Console.WriteLine ("You haven't collected anything yet.");
			}
			System.Console.WriteLine ("\n");
			Console.ResetColor ();
			//	GetUserInput ();
		}
		//Take item
		public void TakeItem (Item item) {
			CurrentPlayer.Items.Add (item, false);
			CurrentRoom.Items.Remove (item);
			Console.Clear ();
			EnterRoom ();
			Console.ForegroundColor = ConsoleColor.Blue;
			System.Console.WriteLine ($"You reach down and grab the {item.Name} and put it in your pocket.");
			System.Console.WriteLine ("\n");
			Console.ResetColor ();

		}

		public void UseItem (string itemName) {
			string[] items = itemName.Split (' ');
			if (items[2] == "go" && items[0] == "use") {
				foreach (KeyValuePair<Item, bool> item in CurrentPlayer.Items) {
					if (item.Key.Name.ToLower () == items[1].ToLower () && item.Value) {
						if (item.Key.Name.ToLower () == "phone" && CurrentRoom.Name == "Elevator") {
							System.Console.WriteLine ("Your phone won't help you in the elevator.");
							EnterRoom ();
						} else if (item.Key.Name.ToLower () == "key" && CurrentRoom.Name == "Second floor stair landing") {
							System.Console.WriteLine ("Your key card won't work here.");
							EnterRoom ();
						} else {
							CurrentRoom = WinRoom;
							GameWon = true;
							string dir = items[2] + " " + items[3];
							Go (dir);
						}
					}
				}
			} else {
				System.Console.WriteLine ("Bad Entry. Try Again.");
			}
		}

		public void Reset () {
			CurrentPlayer = null;
			StartGame ();
		}

		//Quit the game

		public void Quit () {
			GameLoop = false;
			Console.Clear ();
			System.Console.WriteLine ("\n\n\n");
			Console.ForegroundColor = ConsoleColor.Yellow;
			System.Console.WriteLine ("See You Later");
			System.Console.WriteLine ("\n");
			Console.ResetColor ();
			return;
		}

		//Look around to see items in the room
		public void Look () {
			Console.Clear ();

			EnterRoom ();
			Console.ForegroundColor = ConsoleColor.Yellow;
			if (CurrentRoom.Items.Count > 0) {
				foreach (Item item in CurrentRoom.Items) {
					System.Console.WriteLine ($"You see {item.Description}");
				}
			} else {
				System.Console.WriteLine ("Nothing to see here.");
			}
			Console.ResetColor ();
			System.Console.WriteLine ("\n");

		}
		// Begin function, start
		public void StartGame () {
			Setup ();
			Console.Clear ();
			System.Console.WriteLine ("\n\n\n");
			while (CurrentPlayer == null) {
				System.Console.WriteLine ("Plaese Enter Your name.");
				string CurPlayer = Console.ReadLine ();
				System.Console.WriteLine (CurPlayer + "? (Y) or any key to reenter");
				ConsoleKeyInfo playerEntry = Console.ReadKey ();
				if (playerEntry.KeyChar.ToString ().ToLower () == "y") {
					CurrentPlayer = new Player (CurPlayer);
					Console.Clear ();
				}
				if (playerEntry.KeyChar == 'r') {
					continue;
				}
			}

			System.Console.WriteLine ($"Wellcome to the Hackathon {CurrentPlayer.PlayerName}");
			System.Console.WriteLine ("It's after midnight. It seems that the bathroom is always busy so you need to use one on a different floor.");
			System.Console.WriteLine ("Let's see if you can get throught the building and back to your desk.");

			EnterRoom ();
			while (GameLoop) {
				EntryActions ();
				GetUserInput ();
			}
		}

		public void EntryActions () {
			switch (CurrentRoom.Name) {
				case "Code Works":
					if (GameWon) {

						map.Image ("Win");
						CurrentPlayer.Items.Clear ();
						Setup ();
					}
					break;
				case "Elevator":
					//Put Something here?
					break;
				case "First floor stair landing":
					//Put Something here?
					break;
				case "Outside":
					Console.Clear ();
					System.Console.WriteLine ("\n\n\n");
					System.Console.WriteLine ("The Door is locked behind you and it is pooring rain.");
					foreach (KeyValuePair<Item, bool> item in CurrentPlayer.Items) {
						if (item.Key.Name == "Phone") {
							System.Console.WriteLine ("Your phone is wet and shorted out.");
						}
					}
					System.Console.WriteLine ("You Lose. Go Home.");
					System.Console.WriteLine ("\n");

					break;
				case "Rest Room":
					Dictionary<Item, bool> copy = new Dictionary<Item, bool> (CurrentPlayer.Items);
					foreach (KeyValuePair<Item, bool> item in copy) {
						CurrentPlayer.Items[item.Key] = true;
					}
					break;
			}
		}
	}

}