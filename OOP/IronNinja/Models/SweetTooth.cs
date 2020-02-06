using System;

namespace IronNinja.Models
{
    class SweetTooth : Ninja
    {
        public SweetTooth(string name) : base(name){}

        public override bool IsFull
        {
            get
            {
                return (calorieIntake >= 1500);
            }
        }

        public override void Consume(IConsumable item)
        {
            if(IsFull)
            {
                Console.WriteLine($"{Name} is full and cannot eat anymore!");
            }
            else 
            {
                calorieIntake += item.Calories;
                if (item.IsSweet)
                    {
                        calorieIntake += 10;
                    }
                ConsumptionHistory.Add(item);
                if(item is Drink)
                    Console.WriteLine($"{Name} had {item.GetInfo()}");
                if(item is Food)
                    Console.WriteLine($"{Name} ate {item.GetInfo()}");
            }
        }
    }
}