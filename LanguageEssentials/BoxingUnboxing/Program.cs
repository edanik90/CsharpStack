using System;
using System.Collections.Generic;

namespace BoxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> MyList = new List<object>();
            MyList.Add(9);
            MyList.Add(28);
            MyList.Add(-1);
            MyList.Add(true);
            MyList.Add("chair");
            foreach(var item in MyList)
            {
                Console.WriteLine(item);
            }
            int sum = 0;
            foreach(var item in MyList)
            {
                if(item is int)
                {
                    sum += (int)item;
                }
            }
            Console.WriteLine($"Sum of all integers: {sum}");
        }
    }
}
