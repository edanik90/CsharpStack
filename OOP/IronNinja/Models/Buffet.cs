using System;
using System.Collections.Generic;

namespace IronNinja.Models
{
    class Buffet
    {
        public List<IConsumable> Menu;
        public Buffet()
        {
            Menu = new List<IConsumable>()
            {
                new Food("Donut", 195 , false, true),
                new Food("Ice cream", 137 , false, true),
                new Food("Spicy chicken sandwich", 450, true, false),
                new Food("Orange chicken", 1698, true, true),
                new Drink("Sprite", 120, false),
                new Drink("Milk shake", 90, false),
                new Drink("Cherry coke", 100, false),
                new Drink("Latte", 103, false),
                new Drink("Juice", 600, false)
            };
        }

        public IConsumable Serve()
        {
            Random rand = new Random();
            IConsumable output = Menu[rand.Next(Menu.Count)];
            return output;
        }
    }
}