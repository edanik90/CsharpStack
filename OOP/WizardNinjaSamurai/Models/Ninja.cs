using System;

namespace WizardNinjaSamurai.Models
{
    public class Ninja : Human
    {
        public Ninja(string name) : base(name)
        {
            base.Dexterity = 175;
        }
        
        public override int Attack(Human target)
        {
            Random rand = new Random();
            int hp = 5 * Dexterity;
            Console.WriteLine($"{Name} attacked {target.Name} for {hp} damage!");
            if(rand.Next(0,5) == 1)
            {
                hp += 10;
                Console.WriteLine($"Additional 10 damage!");
            }
            return target.Damage(hp);            
        }

        public int Steal(Human target)
        {
            int hp = 5;
            Regenerate(hp);
            Console.WriteLine($"{Name} stole {hp} hp from {target.Name}\n{Name} health is {health} hp now");
            return target.Damage(hp);
        }
    }
}