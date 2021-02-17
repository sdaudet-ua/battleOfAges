using System;

namespace pa2_sdaudet_ua_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int round = 0;
            Console.WriteLine("Welcome to Battle of the Ages!\n\n Let's create your character!");
            Console.Write("Please enter the name of your character: ");
            string playerName = Console.ReadLine();
            Console.WriteLine($"Thanks {playerName}! Now we will choose your player type!\n\nPress 1 for Earth\nPress 2 for Air/Wind\nPress 3 for Fire");
            string playerType = Console.ReadLine();
            int attackMethod = Int32.Parse(playerType);
            Character player = new Character(playerName,ParseAttackMethod(attackMethod));
            Console.WriteLine($"Your character {playerName} has been spawned! Here are your stats: ");
            player.DisplayDetails();
            Console.WriteLine("Now that your character has been created, let's check out your opponent!");
            Character computer = new Character();
            computer.DisplayDetails();
            Console.WriteLine("Are you ready to begin battle? Press any key to continue!");
            Console.ReadKey();
            Battle(player, computer, ref round);
            player.Attack(computer,round);

        }
        public static void Battle(Character player, Character computer, ref int round){
            Console.WriteLine("Welcome to Battle!");
            bool exit = false;
            bool playerIsPC = FirstPlayerisComputer();
            round = 1;
            while (!exit && player.health > 0 && computer.health > 0){
                if (!playerIsPC && player.health > 0){
                    //AttackUI.Gameplay(player, computer);
                    player.Attack(computer,round);
                    round++;
                    playerIsPC = true;
                }
                if (playerIsPC && computer.health > 0){
                    //AttackUI.Gameplay(computer, player);
                    computer.Attack(player,round);
                    round++;
                    playerIsPC = false;
                }
            }
        }
        private static bool FirstPlayerisComputer(){
            Random random = new Random();
            int num = random.Next(10);
            if (num<=5){
                return true;
            }
            else{
                return false;
            }
        }
        private static IAttack ParseAttackMethod(int method){
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
            return null;
        }
    }
}
