using System;

namespace pa2_sdaudet_ua_1
{
    public class AttackUI
    {
        //This Class encapsulates the gameplay interface and displays live information about the battle as it is occurring. 
        public static void Gameplay(Character player, Character computer,int round){
            Console.Clear();
            Console.WriteLine($"Round {round} is underway! {player.name} is battling {computer.name}!");
            //Show health of both players as game runs. 
            Console.WriteLine($"{player.name}'s health: {(player.health/100).ToString("P1")}");
            Console.WriteLine($"{computer.name}'s health: {(computer.health/100).ToString("P1")}");
            Console.Write(@"
######                                                                                 #                         
#     #   ##   ##### ##### #      ######     ####  ######    ##### #    # ######      # #    ####  ######  ####  
#     #  #  #    #     #   #      #         #    # #           #   #    # #          #   #  #    # #      #      
######  #    #   #     #   #      #####     #    # #####       #   ###### #####     #     # #      #####   ####  
#     # ######   #     #   #      #         #    # #           #   #    # #         ####### #  ### #           # 
#     # #    #   #     #   #      #         #    # #           #   #    # #         #     # #    # #      #    # 
######  #    #   #     #   ###### ######     ####  #           #   #    # ######    #     #  ####  ######  ####  

");
        }
        public static void DisplayWinnerBanner(bool userWon){//Displays "You Win" or "You Lose" after the battle finishes. Helps to give interface a more friendly appearance. 
                if (userWon){
                    Console.Write(@"
 __   __           __        ___       _ 
 \ \ / /__  _   _  \ \      / (_)_ __ | |
  \ V / _ \| | | |  \ \ /\ / /| | '_ \| |
   | | (_) | |_| |   \ V  V / | | | | |_|
   |_|\___/ \__,_|    \_/\_/  |_|_| |_(_)
                                         
 ");
                }
                else if (!userWon){
                    Console.Write(@"
 __   __            _                   _ 
 \ \ / /__  _   _  | |    ___  ___  ___| |
  \ V / _ \| | | | | |   / _ \/ __|/ _ \ |
   | | (_) | |_| | | |__| (_) \__ \  __/_|
   |_|\___/ \__,_| |_____\___/|___/\___(_)
                                          
");
                }
            }
    }
}