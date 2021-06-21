using System;
using System.Collections.Generic;

namespace HW2_Exercise_2
{

    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player() { Name = "Bob", Strength = 20 };
            var warrior = new Warrior() { Name = "Baltek", Strength = 100, Bonus = 10 };
            var wizard = new Wizard() { Name = "Pentagorn", Strength = 50, Energy = 50 };

            var players = new List<Player>();
            players.Add(player);
            players.Add(warrior);
            players.Add(wizard);

            DoBattle(players);

            Console.ReadLine();
        }

        static void DoBattle(List<Player> players)
        {
            foreach (var player in players)
            {
                player.Attack();
                Console.WriteLine("");
            }
        }
    }

    internal class Wizard:Player
    {
        internal override void Attack()
        {
            int minAtkInt = 0;
            int maxAtkInt = 100;
            int minManaUseInt = 1;
            int maxManaUseInt = 10;

            Random random = new Random();
            int AtkInt = random.Next(minAtkInt, maxAtkInt);
            int manaUseInt = random.Next(minManaUseInt, maxManaUseInt);

            Console.WriteLine($"{Name} attacks for {AtkInt}! \n (Uses {manaUseInt}.)");
        }

        
        public int Energy { get; set; }
    }

    internal class Warrior:Player
    {
       internal override void Attack()
        {
            int minAtkInt = 20;
            int maxAtkInt = 45;
            int minBonusInt = 5;
            int maxBonusInt = 10;

            Random random = new Random();
            int AtkInt = random.Next(minAtkInt, maxAtkInt);
            int BonusInt = random.Next(minBonusInt, maxBonusInt);

            Console.WriteLine($"{Name} attacks for {AtkInt}! \n (recieved +{BonusInt} bonus to attack).");
        }

        
        public int Bonus { get; set; }
    }

    internal class Player
    {
        public string Name { get; set; }
        public int Strength { get; set; }

        internal virtual void Attack()
        {
            int minAtkInt = 15;
            int maxAtkInt = 30;

            Random random = new Random();
            int AtkInt = random.Next(minAtkInt, maxAtkInt);

            Console.WriteLine($"{Name} attacks for {AtkInt}!");
           
        }
    }
}


