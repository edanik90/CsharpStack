using System;
using WizardNinjaSamurai.Models;

namespace WizardNinjaSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizard wizard1 = new Wizard("Gandalph");
            Ninja ninja1 = new Ninja("Ninjjja");
            Samurai samurai1 = new Samurai("Samurrraiiii");
            // ninja1.Attack(wizard1);
            // samurai1.Attack(wizard1);
            // samurai1.Attack(wizard1);
            // wizard1.Heal(samurai1);
            // wizard1.Heal(samurai1);
            wizard1.Attack(samurai1);
            samurai1.Meditate();
            ninja1.Steal(samurai1);
        }
    }
}
