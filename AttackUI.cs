using System;

namespace pa2_sdaudet_ua_1
{
    public class AttackUI
    {
        public static void Gameplay(Character attacker, Character opponent, int i,int round){
            Console.Clear();
            Console.WriteLine($"Round {round} is underway! {attacker.name} is attacking {opponent.name}!");
            Console.WriteLine($"{attacker.name}'s health: {(attacker.health/100).ToString("P1")}%");
            Console.WriteLine($"{opponent.name}'s health: {(opponent.health/100).ToString("P1")}%");
            Console.Write(@"
######                                                                                 #                         
#     #   ##   ##### ##### #      ######     ####  ######    ##### #    # ######      # #    ####  ######  ####  
#     #  #  #    #     #   #      #         #    # #           #   #    # #          #   #  #    # #      #      
######  #    #   #     #   #      #####     #    # #####       #   ###### #####     #     # #      #####   ####  
#     # ######   #     #   #      #         #    # #           #   #    # #         ####### #  ### #           # 
#     # #    #   #     #   #      #         #    # #           #   #    # #         #     # #    # #      #    # 
######  #    #   #     #   ###### ######     ####  #           #   #    # ######    #     #  ####  ######  ####  

");
            System.Threading.Thread.Sleep(200);
        }
    }
}