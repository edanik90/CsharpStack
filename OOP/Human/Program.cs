using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human witcher = new Human("Geralt", 8, 15, 15, 100);
            Human witcher2 = new Human("Letho");
            Console.WriteLine($"Letho's health is:{witcher2.Health}");
            witcher.Attack(witcher2);
            Console.WriteLine($"Geralt uses Igni sign; Letho's health reduced to:{witcher2.Health}");
        }
    }
    class Human
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        private int health;

        public int Health
        {
            get
            {
                return health;
            }
        }

        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }

        public Human(string name, int strength, int intelligence, int dexterity, int hlth)
        {
            Name = name;
            Strength = strength;
            Intelligence = intelligence;
            Dexterity = dexterity;
            health = hlth;
        }
        public int Attack(Human target)
        {
            target.health = target.health - (5 * Strength);
            return target.health;
        }
    }
    

}
