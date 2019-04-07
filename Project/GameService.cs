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

		bool GameLoop { get; set; } = true;

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
			elevator.AddLockedDoor (Direction.up, begin);
			elevator.AddAdjacentRoom (Direction.down, lobby);
			lobby.AddAdjacentRoom (Direction.south, elevator);
			lobby.AddAdjacentRoom (Direction.north, outside);
			lobby.AddAdjacentRoom (Direction.west, downstairs);
			outside.AddLockedDoor (Direction.south, lobby);
			upstairs.AddLockedDoor (Direction.east, begin);
			upstairs.AddAdjacentRoom (Direction.north, downstairs);
			downstairs.AddAdjacentRoom (Direction.south, upstairs);
			downstairs.AddAdjacentRoom (Direction.east, lobby);

			CurrentRoom = begin;
		}

		public void EnterRoom () {
			Console.Clear ();
			System.Console.WriteLine ("\n\n");
			RoomGraphic ();
			Console.ForegroundColor = ConsoleColor.Yellow;
			System.Console.WriteLine ($"You are in {CurrentRoom.Name}");
			System.Console.WriteLine (CurrentRoom.Description);
			System.Console.WriteLine ("Where do you want to go?");
			System.Console.WriteLine ("\n");
			Console.ResetColor ();
		}

		public void GetUserInput () {

			Console.ForegroundColor = ConsoleColor.Blue;
			System.Console.WriteLine ("To move type (go) and a direction (north), (south), (east), (west), (up), or (down)");
			System.Console.WriteLine ("\n");
			System.Console.WriteLine ("You can type\n(H) for help,\n(Q) to quit,\n(L) to look for items to pickup in the room,\n(R) to restart,\n(I) to see the items that you have picked up and\n(T) to take an available item.");
			System.Console.WriteLine ("\n");
			Console.ForegroundColor = ConsoleColor.Green;
			string PlayerChioce = Console.ReadLine ();
			Console.ResetColor ();
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
					//	GetUserInput ();
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
			foreach (Item item in CurrentPlayer.Inventory) {
				System.Console.Write ($"{item.Name} ");
			}
			System.Console.WriteLine ("collected so far");
			System.Console.WriteLine ("\n");
			Console.ResetColor ();
			//	GetUserInput ();
		}
		//Take item
		public void TakeItem (Item item) {

			CurrentPlayer.Inventory.Add (item);
			CurrentRoom.Items.Remove (item);
			Console.Clear ();

			EnterRoom ();
			Console.ForegroundColor = ConsoleColor.Blue;
			System.Console.WriteLine ($"You reach down and grab the {item.Name} and put it in your pocket.");
			System.Console.WriteLine ("\n");
			Console.ResetColor ();

		}

		public void UseItem (string itemName) {
			throw new NotImplementedException ();
		}

		public void Reset () {
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
				System.Console.WriteLine (CurPlayer + "? (Y) or (R) to reenter");
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
				//LockDoors ();
				GetUserInput ();
			}
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
				case "Outside":
					if (CurrentRoom.Exits.ContainsKey (Direction.south)) {
						CurrentRoom.AddLockedDoor (Direction.south, CurrentRoom.Exits[Direction.south]);
						CurrentRoom.Exits.Remove (Direction.south);
					}
					break;
			}
		}
		public void RoomGraphic () {
			switch (CurrentRoom.Name) {
				case "Code Works":

					GraphicColor (@"

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
					GraphicColor (@"

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
					GraphicColor (@"

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
					GraphicColor (@"

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
					GraphicColor (@"

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
					GraphicColor (@"

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
		private void GraphicColor (string input) {
			Console.ForegroundColor = ConsoleColor.Red;
			Console.BackgroundColor = ConsoleColor.White;
			System.Console.WriteLine ($"{input}");
			Console.ResetColor ();
		}

	}

}