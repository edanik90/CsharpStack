using System;

namespace WizardNinjaSamurai.Models
{
    public class Human
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        protected int health;

        public int Health
        {
            get { return health; }
        }

        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }

        public Human(string name, int str, int intel, int dex, int hp)
        {
            Name = name;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            health = hp;
        }

        public int Regenerate(int hp)
        {
            health += hp;
            return health;
        }

        public int Damage(int hp)
        {
            health -= hp;
            return health;
        }

        public virtual int Attack(Human target)
        {
            int hp = Strength * 3;
            Console.WriteLine($"{Name} attacked {target.Name} for {hp} damage!");
            return target.Damage(hp);
        }
    }

}