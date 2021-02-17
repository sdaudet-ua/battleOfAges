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
            this.health = 100;
            this.attackBehavior = RandomType();
            this.type = attackBehavior.ToTypeString();
            this.attackPower = PowerSelector(maxPower);
            while (this.attackPower<50){
                this.attackPower = PowerSelector(maxPower);
            }
            this.defensePower = PowerSelector(80);
            while (this.defensePower>50){
                this.defensePower = PowerSelector(maxPower);
            }
        }
        public Character(string name, IAttack behavior){
            this.name = name;
            this.maxPower = PowerSelector();
            this.health = 100;
            this.attackBehavior = behavior;
            this.type = attackBehavior.ToTypeString();
            this.attackPower = PowerSelector(maxPower);
            while (this.attackPower<50){
                this.attackPower = PowerSelector(maxPower);
            }
            this.defensePower = PowerSelector(80);
            while (this.defensePower>50){
                this.defensePower = PowerSelector(maxPower);
            }
        }
        public void Attack(Character opponent, int round,ref List<string> gameplayLog){
            double opponentLastHealth = opponent.health;
            for (int i=10;i>=0;i--){
                attackBehavior.Attack(this,opponent);
                AttackUI.Gameplay(this,opponent,i,round);
            }
            double damageDone = opponentLastHealth-opponent.health;
            gameplayLog.Add($"Round {round}:\n{this.name} dealt {damageDone} to {opponent.name}.");
            Console.ReadKey();
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