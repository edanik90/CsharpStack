using System;

namespace WizardNinjaSamurai.Models
{
    public class Wizard : Human
    {
        public Wizard(string name) : base(name)
        {
            base.health = 50;
            base.Intelligence = 25;
        }

        public override int Attack(Human target)
        {
            int hp = 5 * Intelligence;
            Regenerate(hp);
            Console.WriteLine($"{Name} attacked {target.Name} for {hp} damage!\n+{hp} hp to {Name}");
            return target.Damage(hp);            
        }

        public int Heal(Human target)
        {
            int hp = 5 * Intelligence;
            Console.WriteLine($"{Name} healed {target.Name} for {hp} hp!\n+{target.Name} health is now {target.Health}");
            return target.Regenerate(hp);
        }
        
    }
}