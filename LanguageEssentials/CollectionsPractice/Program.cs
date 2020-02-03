using System;
using System.Collections.Generic;

namespace CollectionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Three Basic Arrays
            int[] FirstArray = {0,1,2,3,4,5,6,7,8,9};
            string[] SecondArray = {"Tim", "Martin", "Nikki", "Sara"};
            bool[] ThirdArray = {true, false, true, false, true, false, true, false, true, false};
            Console.WriteLine(ThirdArray.Length);

            // List of Favors
            List<string> IceCreamFLavors = new List<string>();
            IceCreamFLavors.Add("Chocolate");
            IceCreamFLavors.Add("Vanilla");
            IceCreamFLavors.Add("Banana");
            IceCreamFLavors.Add("Strawberry");
            IceCreamFLavors.Add("Mango");
            Console.WriteLine(IceCreamFLavors.Count);
            Console.WriteLine(IceCreamFLavors[2]);
            IceCreamFLavors.RemoveAt(2);
            Console.WriteLine(IceCreamFLavors.Count);

            // User Info Dictionary
            Dictionary<string,string> MyDictionary = new Dictionary<string,string>();
            for (int i = 0; i < SecondArray.Length; i++)
            {
                MyDictionary.Add(SecondArray[i], IceCreamFLavors[i]);
            }
            foreach (KeyValuePair<string,string> entry in MyDictionary)
            {
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }
        }
    }
}
