using System.Collections.Generic;
using System;
using pa2_sdaudet_ua_1;

namespace pa2_sdaudet_ua_1
{
    public class Character
    {
        public string name {get; set;}
        public double maxPower {get; set;}
        public double health {get; set;}
        public IAttack attackBehavior {get; set;}
        public string type {get; set;}
        public double attackPower {get; set;}
        public double defensePower {get; set;}

        public Character(){
            this.name = RandomName();
            this.maxPower = PowerSelector();
            while (this.maxPower<20){
                this.maxPower = PowerSelector();
            }
            this.health = 100;
            this.attackBehavior = RandomType();
            this.type = attackBehavior.ToTypeString();
            this.attackPower = PowerSelector(maxPower);
            while (this.attackPower<10){
                this.attackPower = PowerSelector(maxPower);
            }
            this.defensePower = PowerSelector(80);
            while (this.defensePower<10){
                this.defensePower = PowerSelector(maxPower);
            }
        }
        public Character(string name, IAttack behavior){
            this.name = name;
            this.maxPower = PowerSelector();
            while (this.maxPower<20){
                this.maxPower = PowerSelector();
            }
            this.health = 100;
            this.attackBehavior = behavior;
            this.type = attackBehavior.ToTypeString();
            this.attackPower = PowerSelector(maxPower);
            this.attackPower = PowerSelector(maxPower);
            while (this.attackPower<10){
                this.attackPower = PowerSelector(maxPower);
            }
            this.defensePower = PowerSelector(80);
            while (this.defensePower<10){
                this.defensePower = PowerSelector(maxPower);
            }
        }
        public void Attack(Character opponent, int round,ref List<string> gameplayLog){
            double opponentLastHealth = opponent.health;
            for (int i=5;i>=0;i--){
                attackBehavior.Attack(this,opponent);
                System.Threading.Thread.Sleep(100);
                // AttackUI.Gameplay(this,opponent,i,round);
            }
            if (opponent.health <= 0){
                opponent.health = 0;
            }
            double damageDone = opponentLastHealth-opponent.health;
            gameplayLog.Add($"Round {round}: {this.name} dealt {damageDone.ToString("F1")} to {opponent.name}.");
        }
        public string GetDetails(){
            return ($"Name: {name} ({type})\nHealth: {health}\nAttack Power: {attackPower}\nDefensive Power: {defensePower}%");
        }
        public void DisplayDetails(){
            Console.WriteLine("Name: {0} ({1})\nHealth: {2}\nAttack Power: {3}\nDefensive Power: {4}%\n\nPress any key to continue!", name,type,health,attackPower,defensePower);
            Console.ReadKey();
        }
        private double PowerSelector(){
            Random power = new Random();
            return power.Next(100);
        }
        private double PowerSelector(double charMaxPower){
            Random power = new Random();
            return power.Next(Convert.ToInt32(charMaxPower));
        }
        private IAttack RandomType(){
            List<IAttack> typeList = new List<IAttack>();
            typeList.Add(new EarthAttack());
            typeList.Add(new AirAttack());
            typeList.Add(new FireAttack());
            Random random = new Random();
            int number = random.Next(typeList.Count);
            return typeList[number];
        }
        private string RandomName(){
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
            };
            List<string> charList = new List<string>(names);
            Random random = new Random();
            int number = random.Next(charList.Count);
            return charList[number];
        }
    }
}