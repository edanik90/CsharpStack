using System;

namespace fundamentals1
{
    class Program
    {
        static void Main(string[] args)
        {
            // #1
            for(int i = 1; i <= 255; i++){
                Console.WriteLine(i);
            }
            // #2
            for(int j = 1; j <= 100; j++){
                if (j%3 == 0){
                    Console.WriteLine(j);
                }
                else if(j%5 == 0){
                    Console.WriteLine(j);
                }
            }
            // #3
            for (int k = 1; k <= 100; k++)
            {
                if (k % 3 == 0 && k % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else
                {
                    if (k % 3 == 0)
                    {
                        Console.WriteLine("Fizz");
                    }
                    if (k % 5 == 0)
                    {
                        Console.WriteLine("Buzz");
                    }
                }
            }
            // #4 
            int x = 1;
            while ( x <= 100)
            {
                if (x % 3 == 0 && x % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else
                {
                    if (x % 3 == 0)
                    {
                        Console.WriteLine("Fizz");
                    }
                    if (x % 5 == 0)
                    {
                        Console.WriteLine("Buzz");
                    }
                }
                x++;
            }
        }
    }
}
