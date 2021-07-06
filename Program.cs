using System;
using System.Linq;

namespace Multidimensional_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = ReadingInputs();

            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                int[] filler = ReadingInputs();

                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = filler[col];
                }
            }
            int sum = 0;

            foreach (var item in matrix)
            {
                sum += item;
            }
            Console.WriteLine(size[0]);
            Console.WriteLine($"{size[1]}{Environment.NewLine}" + $"{sum}");

        }

        private static int[] ReadingInputs()
        {
           return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            

        }
    }
}
