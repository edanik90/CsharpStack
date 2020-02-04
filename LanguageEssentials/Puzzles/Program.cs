using System;
using System.Collections.Generic;

namespace Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            // RandomArray();
            // Console.WriteLine(TossCoin());
            // Console.WriteLine(TossMultipleCoins(11));
            Names();
        }

        public static int[] RandomArray()
        {
            Random rand = new Random();
            int[] output = new int[10];
            for(int i = 0; i < output.Length; i++)
            {
                output[i] = rand.Next(5,25);
            }
            int max = output[0];
            int min = output[0];
            int sum = 0;
            for(int i = 0; i < output.Length; i++)
            {
                if(output[i] > max)
                {
                    max = output[i];
                }
                else if(output[i] < min)
                {
                    min = output[i];
                }
                sum += output[i];
            }
            foreach(int num in output)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine($"\nMax is: {max}, Min is: {min}, Sum is: {sum}");
            return output;
        }

        public static string TossCoin()
        {
            // Console.WriteLine("Tossing a coin...");
            Random rand = new Random();
            if(rand.Next(0,2) == 0)
            {
                return "it's Heads!";
            }
            else
            {
                return "it's Tails!";
            }
        }

        public static double TossMultipleCoins(int num)
        {
            double output = 0;
            double count = 0;
            for(int i = 1; i <= num; i++)
            {
                if(TossCoin() == "it's Heads!")
                {
                    count++;
                }
            }
            Console.WriteLine($"Out of {num} tosses, Heads came out {count} times");
            output = (count * 100) / num;
            return output;
        }

        public static List<object> Names()
        {
            List<string> NewList = new List<string>();
            List<object> output = new List<object>();
            NewList.Add("Todd");
            NewList.Add("Tiffany");
            NewList.Add("Charlie");
            NewList.Add("Geneva");
            NewList.Add("Sydney");
            Random rand = new Random();
            for(int i = 0; i < NewList.Count; i++)
            {
                int x = rand.Next(0,5);
                string temp = NewList[i];
                NewList[i] = NewList[x];
                NewList[x] = temp;
            }
            foreach(var name in NewList)
            {
                Console.Write($"{name} ");
            }
            for(int i = 0; i < NewList.Count; i++)
            {
                if(NewList[i].Length > 5)
                {
                    output.Add(NewList[i]);
                }
            }
            return output;
        }
    }
}
