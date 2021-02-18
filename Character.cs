using System.Collections.Generic;
using System;
using pa2_sdaudet_ua_1;

namespace pa2_sdaudet_ua_1
{
    public class Character
    {
        public string name {get; set;}
        private double maxPower {get; set;}
        public double health {get; set;}
        public IAttack attackBehavior {get; set;}
        public string type {get; set;}//Derived from attackBehavior and retrieved from IAttack.ToTypeString()
        public double attackPower {get; set;}
        public double defensePower {get; set;}

        public Character(){//Constructor for the computer's character. 
            this.name = RandomName();//Chooses a random name from a predetermined list.
            this.maxPower = PowerSelector();//Gets a random value between 0 and 100. 
            while (this.maxPower<20){//Ensures maxPower is over 20 to prevent untimely/unpleasant gameplay. (Some values being generated were in the decimals and required hundreds of rounds to complete.) 
                this.maxPower = PowerSelector();
            }
            this.health = 100;
            this.attackBehavior = RandomType();//Randomly selects a Attack Method. 
            this.type = attackBehavior.ToTypeString();//Retrieves string from IAttack to easily keep track of opponent type for the type bonus. 
            this.attackPower = PowerSelector(maxPower);//Generates a random number with a maximum limit of maxPower.
            while (this.attackPower<10){//Ensures attackPower is over 10 to prevent untimely/unpleasant gameplay. (Some values being generated were in the decimals and required hundreds of rounds to complete.) 
                this.attackPower = PowerSelector(maxPower);//Generates a random number with a maximum limit of maxPower. 
            }
            this.defensePower = PowerSelector(80);
            while (this.defensePower<10){//Ensures defensePower is over 10. 
                this.defensePower = PowerSelector(maxPower);//Generates a random number with a maximum limit of maxPower.
            }
        }
        public Character(string name, int attackMethod){//Constructor for user's player. 
            if(name==""){//If user does not enter a name, one will be selected randomly.
                this.name = RandomName();
            }
            else{
                this.name = name;
            }
            this.maxPower = PowerSelector();//Gets a random value between 0 and 100.
            while (this.maxPower<20){//Ensures maxPower is over 20 to prevent untimely/unpleasant gameplay. (Some values being generated were in the decimals and required hundreds of rounds to complete.)
                this.maxPower = PowerSelector();
            }
            this.health = 100;
            this.attackBehavior = ParseAttackMethod(attackMethod);//Gets an IAttack AttackMethod based on input integer. 
            this.type = attackBehavior.ToTypeString();//Retrieves string from IAttack to easily keep track of opponent type for the type bonus. 
            this.attackPower = PowerSelector(maxPower);//Generates a random number with a maximum limit of maxPower.
            while (this.attackPower<10){
                this.attackPower = PowerSelector(maxPower);//Generates a random number with a maximum limit of maxPower.
            }
            this.defensePower = PowerSelector(80);
            while (this.defensePower<10){
                this.defensePower = PowerSelector(maxPower);//Generates a random number with a maximum limit of maxPower.
            }
        }
        public void Attack(Character opponent, int round,ref List<string> gameplayLog){
            double opponentLastHealth = opponent.health;//Record opponent health before attacking. 
            for (int i=5;i>=0;i--){
                attackBehavior.Attack(this,opponent);
                System.Threading.Thread.Sleep(100);
            }
            if (opponent.health <= 0){
                opponent.health = 0;
            }
            double damageDone = opponentLastHealth-opponent.health;
            gameplayLog.Add($"Round {round}: {this.name} dealt {damageDone.ToString("F1")} to {opponent.name}.");
        }
        public string GetDetails(){//Return character details to calling method as a string (used in LogFile.cs)
            return ($"Name: {name} ({type})\nHealth: {health}\nAttack Power: {attackPower}\nDefensive Power: {defensePower}%");
        }
        public void DisplayDetails(){//Print character details to the console and wait for user interaction. 
            Console.WriteLine("Name: {0} ({1})\nHealth: {2}\nAttack Power: {3}\nDefensive Power: {4}%\n\nPress any key to continue!", name,type,health,attackPower,defensePower);
            Console.ReadKey();
        }
        private double PowerSelector(){//Generates a random value between 0 and 100.
            Random power = new Random();
            return power.Next(100);
        }
        private double PowerSelector(double charMaxPower){//Generates a random number with a maximum limit of maxPower.
            Random power = new Random();
            return power.Next(Convert.ToInt32(charMaxPower));
        }
        private IAttack RandomType(){//Selects a random AttackMethod to assign to the computer's player. 
            List<IAttack> typeList = new List<IAttack>();
            typeList.Add(new EarthAttack());
            typeList.Add(new AirAttack());
            typeList.Add(new FireAttack());
            Random random = new Random();
            int number = random.Next(typeList.Count); //Generate a random number between 0 and list count.
            return typeList[number];//Return list item at index of random number. 
        }
        private static IAttack ParseAttackMethod(int method){//Takes input of 1,2, or 3 and returns the associated Concrete Attack Method Implementation. 
            if (method==1){
                return new EarthAttack();
            }
            else if (method==2){
                return new AirAttack();
            }
            else if (method==3){
                return new FireAttack();
            }
            Console.WriteLine("ERROR: Input to AttackMethod parser for character type was not an integer 1,2,or 3.");//If 1,2,or3 is not passed to this method, this message will be displayed. Error checking occurs in the calling method. 
            Console.ReadKey();
            return null;
        }
        private string RandomName(){//Return a random name for use by the computer's character.
            string[] names = {
                "DK",
                "Mortem",
                "Vonner",
                "Vexifer",
                "Venkalth",
                "Peregrine",
                "Thorne",
                "Umbra",
                "Dixbya",
                "Blacmajic",
                "Magiccraze",
                "Trackclaw",
                "Fastdrool",
                "Blazeooze"
            };//Use array to make list of Computer character names. It is cleaner to make the list out of an array, because an array can be instantiated all in one shot, eliminating the need for many List.Add calls. 
            List<string> charList = new List<string>(names);//Array names are added to the list to make it easier to derive the total count of items. 
            Random random = new Random();
            int number = random.Next(charList.Count);//Generate a random number between 0 and list count.
            return charList[number];//Return list item at index of random number. 
        }
    }
}