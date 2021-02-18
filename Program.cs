using System.Collections.Generic;
using System;

namespace pa2_sdaudet_ua_1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while(!exit){
                int round = 0;
                Console.Clear();
                Console.WriteLine("Welcome to Battle of the Ages!\n\nLet's create your character!");
                Console.Write("Please enter the name of your character: ");
                string playerName = Console.ReadLine();
                Console.WriteLine($"Thanks {playerName}! Now we will choose your player type!\n\nPress 1 for Earth\nPress 2 for Air/Wind\nPress 3 for Fire");
                int attackMethod;
                string attackInput = Console.ReadLine();
                bool isValid = int.TryParse(attackInput,out attackMethod);
                if (attackMethod<1 || attackMethod>3){isValid=false;}
                while(!isValid){
                    if(attackInput==null){
                        Console.WriteLine("No input detected, please try again.");
                        attackInput = Console.ReadLine();
                        isValid = int.TryParse(attackInput,out attackMethod);
                    }
                    else{
                        Console.WriteLine("Input must be a number between 1-3. Please try again.");
                        attackInput = Console.ReadLine();
                        isValid = int.TryParse(attackInput,out attackMethod);
                    }
                    if (attackMethod<1 || attackMethod>3){isValid=false;}
                }
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
                Console.Write("Would you like to play again?\nY for yes, N for no: ");
                if (Console.ReadLine().ToUpper()!="Y"){
                    exit = true;
                }
            }
        }
        static void Battle(Character player, Character computer, ref int round){
            Character winner = null;
            bool userWins = false;
            Console.WriteLine("Welcome to Battle!");
            List<string> gameplayLog = new List<string>();
            bool playerIsPC = FirstPlayerisComputer();
            round = 1;
            while (player.health > 0 && computer.health > 0){
                AttackUI.Gameplay(player,computer,round);
                if (!playerIsPC && player.health > 0){
                    player.Attack(computer,round,ref gameplayLog);
                    round++;
                    playerIsPC = true;
                }
                AttackUI.Gameplay(player,computer,round);
                if (playerIsPC && computer.health > 0){
                    computer.Attack(player,round,ref gameplayLog);
                    round++;
                    playerIsPC = false;
                }
            }
            if (player.health<=0){
                winner = computer;
                userWins = false;
            }
            else if (computer.health<=0){
                winner = player;
                userWins = true;
            }
            Console.Clear();
            AttackUI.DisplayWinnerBanner(userWins);
            Console.WriteLine($"\nThe battle has finished! {winner.name} won with {(winner.health/100).ToString("P1")} health remaining! Here are the results of each round!\n\n");
            foreach (string roundResult in gameplayLog){
                Console.WriteLine(roundResult);
            }
            Console.WriteLine("\n\n\nWould you like to save the game log to a file? (File name for yes, Enter for no)");
            string inputForFilename = Console.ReadLine();
            if (inputForFilename!=null){
                LogFile.Write(player,computer,winner,gameplayLog,inputForFilename);
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
