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
                //Console Interface to initialize the game.
                Console.Clear();
                Console.WriteLine("Welcome to Battle of the Ages!\n\nLet's create your character!");
                Console.Write("Please enter the name of your character (Leave blank for a computer-selected name): ");
                string playerName = Console.ReadLine();
                Console.WriteLine($"Thanks {playerName}! Now we will choose your player type!\n\nPress 1 for Earth\nPress 2 for Air/Wind\nPress 3 for Fire");
                int attackMethod;
                //User enters 1,2, or 3 for character type. The following code error checks the input and parses it to get an actual attack Type. 
                string attackInput = Console.ReadLine();
                bool isValid = int.TryParse(attackInput,out attackMethod);
                if (attackMethod<1 || attackMethod>3){isValid=false;}
                while(!isValid){
                    Console.WriteLine("Input must be a number between 1-3. Please try again.");
                    attackInput = Console.ReadLine();
                    isValid = int.TryParse(attackInput,out attackMethod);
                    if (attackMethod<1 || attackMethod>3){isValid=false;}
                }
                //If the input is in a proper format, send to the parsing method and instantiate the Character. 
                Character player = new Character(playerName,attackMethod);
                Console.Clear();
                Console.WriteLine($"Your character {playerName} has been spawned! Here are your stats: ");
                player.DisplayDetails();//Show player details. 
                Console.WriteLine("\n\nNow that your character has been created, let's check out your opponent!");
                Character computer = new Character();//Using different Constructor than player, all info is assigned randomly. 
                computer.DisplayDetails();
                Console.Clear();
                //Both players have been instantiated, game is ready to play.
                Console.WriteLine("\n\nAre you ready to begin battle? Press any key to continue!");
                Console.ReadKey();
                Battle(player, computer);
                Console.Write("Would you like to play again?\nY for yes, N for no: ");
                if (Console.ReadLine().ToUpper()!="Y"){
                    exit = true;
                }
            }
        }
        static void Battle(Character player, Character computer){
            int round = 1; //Running count during game to show how many times the battle alternated. 
            Character winner = null;//Used when displaying the game log. (Had to set to null due to the setter statements being nested in 'if' statements.)
            bool userWins = false;//Used when calling the post-gameplay banner. 
            Console.WriteLine("Welcome to Battle!");
            List<string> gameplayLog = new List<string>();//Initialize a list to keep up with all the rounds, will be used to display results after the battle. 
            bool playerIsPC = FirstPlayerisComputer(); //Randomly selects the first player. Since there are only 2 players in any battle, this is just a boolean for simplicity. 
            while (player.health > 0 && computer.health > 0){//While both players are alive, alternate between who attacks whom. 
                AttackUI.Gameplay(player,computer,round);//Show gameplay UI.
                if (!playerIsPC && player.health > 0){//Check health before attacking. 
                    player.Attack(computer,round,ref gameplayLog);//Use player's attack strategy to attack computer. 
                    round++;//Increment round. 
                    playerIsPC = true;//Change currentplayer so next round is played by opponent. 
                }
                AttackUI.Gameplay(player,computer,round);//Same as above but other character.
                if (playerIsPC && computer.health > 0){
                    computer.Attack(player,round,ref gameplayLog);
                    round++;
                    playerIsPC = false;
                }
            }
            //after the battle finishes, set the winner variable to the winner of the game. 
            if (player.health<=0){
                winner = computer;//Passing entire instance of the Character so the post-game UI can show any details about the winning character it wants to. 
                userWins = false;//Causes the post-game banner to show "You Lose" in ASCII Art. 
            }
            else if (computer.health<=0){//Same as above but other character.
                winner = player;
                userWins = true;
            }
            Console.Clear();
            AttackUI.DisplayWinnerBanner(userWins);//Show "You Win" or "You Lose" after the game. 
            Console.WriteLine($"\nThe battle has finished! {winner.name} won with {(winner.health/100).ToString("P1")} health remaining! Here are the results of each round!\n\n");
            foreach (string roundResult in gameplayLog){//Print all the round details in the console. 
                Console.WriteLine(roundResult);
            }
            Console.WriteLine("\n\n\nWould you like to save the game log to a file? (File name for yes, Enter for no)");
            string inputForFilename = Console.ReadLine();//This function allows a user to save the game info to a txt file. Entering a file name will export the data to that file in the root directory of this program. No input will result in no file being generated. 
            if (inputForFilename!=null){
                LogFile.Write(player,computer,winner,gameplayLog,inputForFilename);//must pass all relevant information to the LogFile class for proper battle documentation. 
            }
        }
        static bool FirstPlayerisComputer(){//Generates a random number between 1 and 10 and if it is less than/equal to 5 returns true, greater than 5 returns false. Used for determining the first player to attack. 
            Random random = new Random();
            int num = random.Next(10);
            if (num<=5){
                return true;
            }
            else{
                return false;
            }
        }
    }
}
