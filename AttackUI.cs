using System;

namespace pa2_sdaudet_ua_1
{
    public class AttackUI
    {
        public static void Gameplay(Character attacker, Character opponent, int i){
            Console.Clear();
            Console.WriteLine($"{attacker.name} is attacking {opponent.name}!");
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

{0} seconds remaining!",i);
            System.Threading.Thread.Sleep(1000);
        }
    }
}