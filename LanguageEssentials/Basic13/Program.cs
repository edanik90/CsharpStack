using System;

namespace Basic13 {
    class Program {
        static void Main (string[] args) {
            int[] numbers = {-4, 3, 4, 6, -7 };
            // PrintNumbers();
            // PrintOdds();
            // PrintSum();
            // LoopArray(numbers);
            // Console.WriteLine(FindMax(numbers));
            // GetAverage(numbers);
            // OddArray();
            // Console.WriteLine(GreaterThanY(numbers, -2));
            // SquareArrayValues(numbers);
            // EliminateNegatives(numbers);
            // MinMaxAverage(numbers);
            // ShiftValues(numbers);
            // NumToString(numbers);
        }

        public static void PrintNumbers () {
            for (int i = 1; i <= 255; i++) {
                Console.WriteLine (i);
            }
        }
        public static void PrintOdds () {
            for (int i = 1; i < 256; i++) {
                if (i % 2 != 0) {
                    Console.WriteLine (i);
                }
            }
        }

        public static void PrintSum () {
            int sum = 0;
            for (int i = 0; i < 256; i++) {
                sum += i;
                Console.WriteLine ($"New number: {i} Sum: {sum}");
            }
        }

        public static void LoopArray (int[] numbers) {
            foreach (int num in numbers) {
                Console.WriteLine (num);
            }
        }

        public static int FindMax (int[] numbers) {
            int max = numbers[0];
            foreach (int num in numbers) {
                if (num > max) {
                    max = num;
                }
            }
            return max;
        }

        public static void GetAverage (int[] numbers) {
            int sum = 0;
            foreach (int num in numbers) {
                sum += num;
            }
            double average = (double) sum / (double) numbers.Length;
            Console.WriteLine ($"Average is {average}");
        }

        public static int[] OddArray () {
            int outputLength = 0;
            int j = 0;
            for (int i = 1; i < 256; i++) {
                if (i % 2 != 0) {
                    outputLength++;
                }
            }
            int[] output = new int[outputLength];
            for (int i = 1; i < 256; i++) {
                if (i % 2 != 0) {
                    output[j] = i;
                    Console.WriteLine (output[j]);
                    j++;
                }
            }
            return output;
        }

        public static int GreaterThanY (int[] numbers, int y) {
            int output = 0;
            foreach (var num in numbers) {
                if (num > y) {
                    output++;
                }
            }
            return output;
        }

        public static void SquareArrayValues (int[] numbers) {
            for (int i = 0; i < numbers.Length; i++) {
                numbers[i] = numbers[i] * numbers[i];
            }
            foreach (int num in numbers) {
                Console.WriteLine (num);
            }
        }

        public static void EliminateNegatives (int[] numbers) {
            for (int i = 0; i < numbers.Length; i++) {
                if (numbers[i] < 0) {
                    numbers[i] = 0;
                }
            }
            foreach (int num in numbers) {
                Console.WriteLine (num);
            }
        }

        public static void MinMaxAverage (int[] numbers) {
            int min = numbers[0];
            foreach (int num in numbers) {
                if (num < min) {
                    min = num;
                }
            }
            Console.WriteLine ($"Min is:{min}");
            Console.WriteLine ($"Max is: {FindMax(numbers)}");
            GetAverage (numbers);
        }

        public static void ShiftValues (int[] numbers) {
            for (int i = 0; i < numbers.Length - 1; i++) {
                numbers[i] = numbers[i + 1];
            }
            numbers[numbers.Length - 1] = 0;
            foreach (int num in numbers) {
                Console.WriteLine (num);
            }
        }
        public static object[] NumToString(int[] numbers)
        {
            object[] output = new object[numbers.Length];
            for(int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] < 0)
                {
                    output[i] = "Dojo";
                }
                else
                {
                    output[i] = numbers[i];
                }
            }
            foreach(var item in output)
            {
                Console.WriteLine(item);
            }
            return output;
        }

    }
}