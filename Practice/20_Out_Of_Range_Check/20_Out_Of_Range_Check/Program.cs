using System;

namespace _20_Out_Of_Range_Check
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] items = new int[5] { 10, 20, 30, 40, 50};

            for (int i = -2; i < 10; i++)
            {
                var lowerBound = items.GetLowerBound(0);
                var upperBound = items.GetUpperBound(0);
                if (i < lowerBound || i > upperBound)
                {
                    continue;
                }
                Console.WriteLine($"The value is : {items[i]}");
            }
        }
    }
}
