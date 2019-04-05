using System;
using System.Collections.Generic;
using System.Linq;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project {
	public class GameService : IGameService {
		public GameService () {

		}
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

		public void Setup () {
			Room begin = new Room ("Code Works", "Your phone is on your desk beside you. The elevator is to the north and the stairs are to the west");
			Room elevator = new Room ("Elevator", "The elevator door closes and you are unable to chose any floor but it begins to go down. The elevator stops at the first floor but the door doesn't open. You wait and press the door open button and nothing happens. Finnaly the door opens to the north");
			Room upstairs = new Room ("Second floor stair landing", "You enter the stairs and the door closes behind you. The first floor landing is below you to the north.");
			Room downstairs = new Room ("First floor stair landing", "You are standing at the bottom of the stairwell on the first floor");
			Room lobby = new Room ("Lobby", "As you enter the loby the outside doors are to the north. The elavator is to the south and the stairs to west. It is dark out side and raining.");
			Room outside = new Room ("Outside", "You push the doors to the parking lot the doors close behind you.");

			Item phone = new Item ("Phone", "your cell phone");
			Item card = new Item ("Key Card", "a magnetic key card");
			begin.Items.Add (phone);
			downstairs.Items.Add (card);

			begin.AddAdjacentRoom (Direction.north, elevator);
			begin.AddAdjacentRoom (Direction.west, upstairs);
			elevator.AddAdjacentRoom (Direction.south, begin);
			elevator.AddAdjacentRoom (Direction.north, lobby);
			lobby.AddAdjacentRoom (Direction.south, elevator);
			lobby.AddAdjacentRoom (Direction.north, outside);
			lobby.AddAdjacentRoom (Direction.west, downstairs);
			outside.AddAdjacentRoom (Direction.south, lobby);
			upstairs.AddAdjacentRoom (Direction.east, begin);
			upstairs.AddAdjacentRoom (Direction.north, downstairs);
			downstairs.AddAdjacentRoom (Direction.south, upstairs);
			downstairs.AddAdjacentRoom (Direction.east, lobby);

			CurrentRoom = begin;
		}

		public void EnterRoom () {
			Console.Clear ();

			RoomGraphic ();
			System.Console.WriteLine ($"You are in {CurrentRoom.Name}");
			System.Console.WriteLine (CurrentRoom.Description);
			System.Console.WriteLine ("Where do you want to go?");
		}

		public void GetUserInput () {
			System.Console.WriteLine ("You can type (H) for help,\n(Q) to quit,\n(L) to look for items to pickup in the room,\n(R) to restart,\n(I) to see the items that you have picked up and\n(T) to take an available item.");
			string PlayerChioce = Console.ReadLine ();
			string choice = PlayerChioce.ToLower ();
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
					GetUserInput ();
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
						Console.WriteLine ("Invalid choice. Please retry");
						GetUserInput ();
						break;
				}
			}
			EnterRoom ();
			GetUserInput ();
		}

		public void SetRoom (Direction dir) {
			if (CurrentRoom.Exits.ContainsKey (dir)) {
				CurrentRoom = (Room) CurrentRoom.Exits[dir];
				EnterRoom ();
				GetUserInput ();
			}
		}

		public void Help () {
			System.Console.WriteLine (@"

                               ==============                                    
                               M            M                                    
                               M            M                                    
                               M   outside  M                                    
                               M            M                                    
                               M            M                                    
                               MMMMMMMMMMMMMM                                    
              ===============  ==============                                    
              M             M  M            M                                    
              M             M  M            M                                    
              M down stairs M  M   lobby    M                                    
              M   landing   M  M            M                                    
              M             M  M            M                                    
              M             M  MMMMMMMMMMMMMM                                    
              M             M  ==============                                    
              M             M  M            M                                    
              MMMMMMMMMMMMMMM  M            M                                    
                               M  elevator  M                                    
              MMMMMMMMMMMMMMM  M            M      ▲                             
              M             M  M            M      N                             
              M             M  MMMMMMMMMMMMMM                                    
              M             M  ==============                                    
              M  up stairs  M  M            M                                    
              M   landing   M  M            M                                    
              M             M  M Code Works M                                    
              M             M  M            M                                    
              M             M  M            M                                    
              MMMMMMMMMMMMMMM  MMMMMMMMMMMMMM                                    
");
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
					EnterRoom ();
					GetUserInput ();
				}
				continue;
			}

		}
		public void Inventory () {
			throw new NotImplementedException ();
		}

		public void TakeItem (Item item) {

			CurrentPlayer.Inventory.Add (item);
			CurrentRoom.Items.Remove (item);

			EnterRoom ();
			GetUserInput ();
		}

		public void UseItem (string itemName) {
			throw new NotImplementedException ();
		}

		public void Reset () {
			StartGame ();
		}

		public void Quit () {
			Console.Clear ();
			System.Console.WriteLine ("See You Later");
			return;
		}

		public void Look () {
			if (CurrentRoom.Items.Count > 0) {
				foreach (Item item in CurrentRoom.Items) {
					System.Console.WriteLine ($"You see {item.Description}");
				}
			} else {
				System.Console.WriteLine ("Nothing to see here.");
			}
			GetUserInput ();
		}
		public void StartGame () {
			Setup ();
			Console.Clear ();
			//bool GetPlayerLoop = true;
			while (CurrentPlayer == null) {
				System.Console.WriteLine ("Plaese Enter Your name.");
				string CurPlayer = Console.ReadLine ();
				System.Console.WriteLine (CurPlayer + "? (Y) or (R) to reenter");
				ConsoleKeyInfo playerEntry = Console.ReadKey ();
				if (playerEntry.KeyChar.ToString ().ToLower () == "y") {
					//GetPlayerLoop = false;
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
			LockDoors ();
			EnterRoom ();
			GetUserInput ();
		}

		public void LockDoors () {
			switch (CurrentRoom.Name) {
				case "Elevator":
					if (CurrentRoom.Exits.ContainsKey (Direction.south)) {
						CurrentRoom.AddLockedDoor (Direction.south, CurrentRoom.Exits[Direction.south]);
						CurrentRoom.Exits.Remove (Direction.south);
					}
					break;
				case "First floor stair landing":
					if (CurrentRoom.Exits.ContainsKey (Direction.east)) {
						CurrentRoom.AddLockedDoor (Direction.east, CurrentRoom.Exits[Direction.east]);
						CurrentRoom.Exits.Remove (Direction.east);
					}
					break;
			}
		}
		public void RoomGraphic () {
			switch (CurrentRoom.Name) {
				case "Code Works":
					System.Console.WriteLine (@"

                               ==============                                    
                               M            M                                    
                               M            M                                    
                               M   outside  M                                    
                               M            M                                    
                               M            M                                    
                               MMMMMMMMMMMMMM                                    
              ===============  ==============                                    
              M             M  M            M                                    
              M             M  M            M                                    
              M down stairs M  M   lobby    M                                    
              M   landing   M  M            M                                    
              M             M  M            M                                    
              M             M  MMMMMMMMMMMMMM                                    
              M             M  ==============                                    
              M             M  M            M                                    
              MMMMMMMMMMMMMMM  M            M                                    
                               M  elevator  M                                    
              MMMMMMMMMMMMMMM  M            M      ^                             
              M             M  M            M      N                             
              M             M  MMMMMMMMMMMMMM                                    
              M             M  ==============                                    
              M  up stairs  M  M      ^     M                                    
              M   landing   M  M            M                                    
              M             M  M   you are  M                                    
              M             M  M    here    M                                    
              M             M  M <          M                                    
              MMMMMMMMMMMMMMM  MMMMMMMMMMMMMM                                    
");
					break;
				case "Elevator":
					System.Console.WriteLine (@"

                               ==============                                    
                               M            M                                    
                               M            M                                    
                               M   outside  M                                    
                               M            M                                    
                               M            M                                    
                               MMMMMMMMMMMMMM                                    
              ===============  ==============                                    
              M             M  M            M                                    
              M             M  M            M                                    
              M down stairs M  M   lobby    M                                    
              M   landing   M  M            M                                    
              M             M  M            M                                    
              M             M  MMMMMMMMMMMMMM                                    
              M             M  ==============                                    
              MMMMMMMMMMMMMMM  M     ^      M                                    
                               M  you are   M                                    
              MMMMMMMMMMMMMMM  M    here    M      ^                             
              M             M  M            M      N                             
              M             M  M     v      M                                    
              M             M  MMMMMMMMMMMMMM                                    
              M             M  ==============                                    
              M  up stairs  M  M            M                                    
              M   landing   M  M            M                                    
              M             M  M Code Works M                                    
              M             M  M            M                                    
              M             M  M            M                                    
              MMMMMMMMMMMMMMM  MMMMMMMMMMMMMM                                    
");
					break;
				case "Lobby":
					System.Console.WriteLine (@"

                               ==============                                    
                               M            M                                    
                               M            M                                    
                               M   outside  M                                    
                               M            M                                    
                               M            M                                    
                               MMMMMMMMMMMMMM                                    
              ===============  ==============                                    
              M             M  M     ^      M                                    
              M             M  M <          M                                    
              M             M  M   you are  M                                    
              M down stairs M  M    here    M                                    
              M   landing   M  M     v      M                                    
              M             M  MMMMMMMMMMMMMM                                    
              M             M  ==============                                    
              M             M  M            M                                    
              MMMMMMMMMMMMMMM  M            M                                    
                               M  elevator  M                                    
              MMMMMMMMMMMMMMM  M            M      ^                             
              M             M  M            M      N                             
              M             M  MMMMMMMMMMMMMM                                    
              M             M  ==============                                    
              M  up stairs  M  M            M                                    
              M   landing   M  M            M                                    
              M             M  M Code Works M                                    
              M             M  M            M                                    
              M             M  M            M                                    
              MMMMMMMMMMMMMMM  MMMMMMMMMMMMMM                                    
");
					break;
				case "First floor stair landing":
					System.Console.WriteLine (@"

                               ==============                                    
                               M            M                                    
                               M            M                                    
                               M   outside  M                                    
                               M            M                                    
                               M            M                                    
                               MMMMMMMMMMMMMM                                    
              ===============  ==============                                    
              M             M  M            M                                    
              M           > M  M            M                                    
              M   you are   M  M   lobby    M                                    
              M    here     M  M            M                                    
              M             M  M            M                                    
              M             M  MMMMMMMMMMMMMM                                    
              M             M  ==============                                    
              M      v      M  M            M                                    
              MMMMMMMMMMMMMMM  M            M                                    
                               M  elevator  M                                    
              MMMMMMMMMMMMMMM  M            M      ^                             
              M             M  M            M      N                             
              M             M  MMMMMMMMMMMMMM                                    
              M             M  ==============                                    
              M  up stairs  M  M            M                                    
              M   landing   M  M            M                                    
              M             M  M Code Works M                                    
              M             M  M            M                                    
              M             M  M            M                                    
              MMMMMMMMMMMMMMM  MMMMMMMMMMMMMM                                    
");
					break;
				case "Second floor stair landing":
					System.Console.WriteLine (@"

                               ==============                                    
                               M            M                                    
                               M            M                                    
                               M   outside  M                                    
                               M            M                                    
                               M            M                                    
                               MMMMMMMMMMMMMM                                    
              ===============  ==============                                    
              M             M  M            M                                    
              M             M  M            M                                    
              M down stairs M  M   lobby    M                                    
              M   landing   M  M            M                                    
              M             M  M            M                                    
              M             M  MMMMMMMMMMMMMM                                    
              M             M  ==============                                    
              M             M  M            M                                    
              MMMMMMMMMMMMMMM  M            M                                    
                               M  elevator  M                                    
              MMMMMMMMMMMMMMM  M            M      ^                             
              M      ^      M  M            M      N                             
              M             M  MMMMMMMMMMMMMM                                    
              M             M  ==============                                    
              M   you are   M  M            M                                    
              M    here     M  M            M                                    
              M             M  M Code Works M                                    
              M           > M  M            M                                    
              M             M  M            M                                    
              MMMMMMMMMMMMMMM  MMMMMMMMMMMMMM                                    
");
					break;
				case "Outside":
					System.Console.WriteLine (@"

                               ==============                                    
                               M            M                                    
                               M            M                                    
                               M   you are  M                                    
                               M    here    M                                    
                               M     v      M                                    
                               MMMMMMMMMMMMMM                                    
              ===============  ==============                                    
              M             M  M            M                                    
              M             M  M            M                                    
              M down stairs M  M   lobby    M                                    
              M   landing   M  M            M                                    
              M             M  M            M                                    
              M             M  MMMMMMMMMMMMMM                                    
              M             M  ==============                                    
              M             M  M            M                                    
              MMMMMMMMMMMMMMM  M            M                                    
                               M  elevator  M                                    
              MMMMMMMMMMMMMMM  M            M      ^                             
              M             M  M            M      N                             
              M             M  MMMMMMMMMMMMMM                                    
              M             M  ==============                                    
              M  up stairs  M  M            M                                    
              M   landing   M  M            M                                    
              M             M  M Code Works M                                    
              M             M  M            M                                    
              M             M  M            M                                    
              MMMMMMMMMMMMMMM  MMMMMMMMMMMMMM                                    
");
					break;
			}
		}
	}

}