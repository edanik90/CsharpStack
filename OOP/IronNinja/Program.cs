using System;
using IronNinja.Models;

namespace IronNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            SweetTooth tooth = new SweetTooth("Hidetaka");
            SpiceHound hound = new SpiceHound("Hideo");
            Buffet newBuffet = new Buffet();
            while(!tooth.IsFull || !hound.IsFull)
            {
                tooth.Consume(newBuffet.Serve());
                hound.Consume(newBuffet.Serve());
            }
            if(tooth.IsFull)
                Console.WriteLine($"{tooth.Name} consumed {tooth.ConsumptionHistory.Count} items");
            else
                Console.WriteLine($"{hound.Name} consumed {tooth.ConsumptionHistory.Count} items");
        }
    }
}