using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1_Data_Change_Detection
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = new int[100];
            int [] prevData = new int[100];

            while (true)
            {
                int position = 0;
                Console.WriteLine("Enter position");
                string positionInput = Console.ReadLine();

                Console.WriteLine("Enter value");
                int value = 0;
                string valueInput = Console.ReadLine();

                if (int.TryParse(positionInput, out position) & int.TryParse(valueInput, out value))
                {
                    data[position] = value;
                }
                else
                {
                    Console.WriteLine("Invalue inputs");
                    continue;
                }
                Console.WriteLine("Checking the difference..");
                if (CheckDataChanged(prevData, data))
                {
                    Console.WriteLine("Data has been changed");
                }
                else
                {
                    Console.WriteLine("Data has not been changed");
                }
                data.CopyTo(prevData, 0);
            }
        }


        static bool CheckDataChanged(int[] prevData, int[]currData)
        {
            bool changed = false;
            if (prevData.Length != currData.Length)
            {
                throw new ArgumentException("Two lists have different length");
            }
            if (!prevData.SequenceEqual(currData))
            {
                changed = true;
                for (int i = 0; i < prevData.Length; i++)
                {
                    if (prevData[i] != currData[i])
                    {
                        Console.WriteLine($"Position : {i}, Previous value : {prevData[i]}, Current value : {currData[i]}");
                    }
                }
            }
            else
            {
                changed = false;
            }

            return changed;
        }
    }
}
