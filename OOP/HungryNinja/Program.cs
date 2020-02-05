using System;
using System.Collections.Generic;

namespace HungryNinja
{
    class Food
    {
        public string Name;
        public int Calories;
        public bool IsSpicy; 
        public bool IsSweet; 
        
        public Food(string name, int cal, bool spicy, bool sweet)
        {
            Name = name;
            Calories = cal;
            IsSpicy = spicy;
            IsSweet = sweet;
        }
    }

    class Buffet
    {
        public List<Food> Menu;
        public Buffet()
        {
            Menu = new List<Food>()
            {
                new Food("Donut", 195 , false, true),
                new Food("Ice cream", 137 , false, true),
                new Food("Spicy chicken sandwich", 450, true, false),
                new Food("Orange chicken", 1698, true, true),
                new Food("Some spicy food", 600, true, false),
                new Food("Some sweet food", 800, false, true),
                new Food("Some both spicy and sweet food", 1000, true, true)
            };
        }
         
        public Food Serve()
        {
            Random rand = new Random();
            Food output = Menu[rand.Next(0, Menu.Count)];
            return output;
        }
    }

    class Ninja
    {
        private int calorieIntake;
        public List<Food> FoodHistory;
         
        public Ninja()
        {
            calorieIntake = 0;
            FoodHistory = new List<Food>();
        }

        public bool IsFull
        {
            get
            {
                if (calorieIntake > 1200)
                {
                    return true;
                }
                return false;
            }
        }

        public void Eat(Food item)
        {
            if(IsFull == false)
            {
                FoodHistory.Add(item);
                calorieIntake += item.Calories;
                Console.Write(item.Name);
                if(item.IsSpicy && item.IsSweet)
                {
                    Console.Write(" is sweet and spicy\n");
                }
                else
                {
                    if(item.IsSweet)
                    {
                        Console.Write(" is sweet\n");
                    }
                    else
                    {
                        Console.Write(" is spicy\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nOops! You've eaten enough for today!");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Buffet newBuffet = new Buffet();
            Console.WriteLine($"Here is {newBuffet.Serve().Name} for you! Enjoy!");
            Ninja newNinja = new Ninja();
            while(newNinja.IsFull is false)
            {
                newNinja.Eat(newBuffet.Serve());
            }
            Console.WriteLine("Ooops! Looks like you are full!");
        }
    }
}
