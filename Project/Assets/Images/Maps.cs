using System;

namespace CastleGrimtol.Project.Images {
  class Maps {
    public void Image (string image) {
      switch (image) {
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
              M             M  M            M ========== 
              M             M  M            M M  Rest  M 
              M down stairs M  M   lobby    M M        M 
              M   landing   M  M            M M  Room  M 
              M             M  M            M ========== 
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
              M             M  M            M ========== 
              M             M  M            M M  Rest  M 
              M down stairs M  M   lobby    M M        M 
              M   landing   M  M            M M  Room  M 
              M             M  M            M ========== 
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
              M             M  M      ^     M ========== 
              M             M  M <        > M M  Rest  M 
              M             M  M   you are  M M        M 
              M down stairs M  M    here    M M  Room  M 
              M   landing   M  M      v     M ========== 
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
              M             M  M            M ==========
              M           > M  M            M M  Rest  M
              M   you are   M  M   lobby    M M        M
              M    here     M  M            M M  Room  M
              M             M  M            M ==========
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
              M             M  M            M ========== 
              M             M  M            M M  Rest  M 
              M down stairs M  M   lobby    M M        M 
              M   landing   M  M            M M  Room  M 
              M             M  M            M ========== 
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
              M             M  M            M ==========  
              M             M  M            M M  Rest  M  
              M down stairs M  M   lobby    M M        M  
              M   landing   M  M            M M  Room  M  
              M             M  M            M ==========  
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
        case "Rest Room":
          GraphicColor (@"

                               ==============            
                               M            M            
                               M            M            
                               M  Outside   M            
                               M            M            
                               M            M            
                               MMMMMMMMMMMMMM   You are  
              ===============  ==============     here   
              M             M  M            M ========== 
              M             M  M            M M  Rest  M 
              M down stairs M  M   lobby    M M <      M 
              M   landing   M  M            M M  Room  M 
              M             M  M            M ========== 
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
        case "Win":
          Console.Clear ();

          GraphicColor (@"
                  ___           ___                    ___                       ___     
                 /\  \         /\  \                  /\  \                     /\  \    
      ___       /::\  \        \:\  \                _\:\  \       ___          \:\  \   
     /|  |     /:/\:\  \        \:\  \              /\ \:\  \     /\__\          \:\  \  
    |:|  |    /:/  \:\  \   ___  \:\  \            _\:\ \:\  \   /:/__/      _____\:\  \ 
    |:|  |   /:/__/ \:\__\ /\  \  \:\__\          /\ \:\ \:\__\ /::\  \     /::::::::\__\
  __|:|__|   \:\  \ /:/  / \:\  \ /:/  /          \:\ \:\/:/  / \/\:\  \__  \:\~~\~~\/__/
 /::::\  \    \:\  /:/  /   \:\  /:/  /            \:\ \::/  /   ~~\:\/\__\  \:\  \      
 ~~~~\:\  \    \:\/:/  /     \:\/:/  /              \:\/:/  /       \::/  /   \:\  \     
      \:\__\    \::/  /       \::/  /                \::/  /        /:/  /     \:\__\    
       \/__/     \/__/         \/__/                  \/__/         \/__/       \/__/    
");

          break;
        case "Help Map":
          GraphicColor(@"

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
          break;
      }

    }
    private void GraphicColor(string input) {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.BackgroundColor = ConsoleColor.White;
      System.Console.WriteLine($"{input}");
      Console.ResetColor ();
    }
  }

}