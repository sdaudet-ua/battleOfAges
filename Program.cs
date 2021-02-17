using System.Collections.Generic;
using System;

namespace pa2_sdaudet_ua_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int round = 0;
            Console.Clear();
            Console.WriteLine("Welcome to Battle of the Ages!\n\nLet's create your character!");
            Console.Write("Please enter the name of your character: ");
            string playerName = Console.ReadLine();
            Console.WriteLine($"Thanks {playerName}! Now we will choose your player type!\n\nPress 1 for Earth\nPress 2 for Air/Wind\nPress 3 for Fire");
            int attackMethod = Int32.Parse(Console.ReadLine());
            Character player = new Character(playerName,ParseAttackMethod(attackMethod));
            Console.Clear();
            Console.WriteLine($"Your character {playerName} has been spawned! Here are your stats: ");
            player.DisplayDetails();
            Console.WriteLine("\n\nNow that your character has been created, let's check out your opponent!");
            Character computer = new Character();
            computer.DisplayDetails();
            Console.Clear();
            Console.WriteLine("\n\nAre you ready to begin battle? Press any key to continue!");
            Console.ReadKey();
            Battle(player, computer, ref round);

        }
        static void Battle(Character player, Character computer, ref int round){
            bool exit = false;
            while(!exit){
                Character winner = null;
                Console.WriteLine("Welcome to Battle!");
                List<string> gameplayLog = new List<string>();
                bool playerIsPC = FirstPlayerisComputer();
                round = 1;
                while (player.health > 0 && computer.health > 0){
                    if (!playerIsPC && player.health > 0){
                        player.Attack(computer,round,ref gameplayLog);
                        round++;
                        playerIsPC = true;
                    }
                    if (playerIsPC && computer.health > 0){
                        computer.Attack(player,round,ref gameplayLog);
                        round++;
                        playerIsPC = false;
                    }
                }
                if (player.health<=0){
                    winner = computer;
                }
                else if (computer.health<=0){
                    winner = player;
                }
                Console.Clear();
                Console.WriteLine($"The battle has finished! {winner.name} won with {winner.health.ToString("P")} health remaining! Here are the results of each round!");
                foreach (string roundResult in gameplayLog){
                    Console.WriteLine(roundResult);
                }
            }
        }
        static bool FirstPlayerisComputer(){
            Random random = new Random();
            int num = random.Next(10);
            if (num<=5){
                return true;
            }
            else{
                return false;
            }
        }
        static IAttack ParseAttackMethod(int method){
            if (method==1){
                return new EarthAttack();
            }
            else if (method==2){
                return new AirAttack();
            }
            else if (method==3){
                return new FireAttack();
            }
            Console.WriteLine("ERROR: Input for character type was not an integer 1,2,or 3.");
            Console.ReadKey();
            return null;
        }
    }
}
