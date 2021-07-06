using System;
using System.Linq;

namespace WarShips
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            string[] commands = Console.ReadLine().Split(',');

            int firstPlayerShips = 0;
            int secondPlayerShips = 0;
            int shipsSunk = 0;

            for (int rows = 0; rows < size; rows++)
            {
                //2 147 483 647
                char[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int cols = 0; cols < size; cols++)
                {
                    matrix[rows, cols] = input[cols];
                    if (input[cols] == '<')
                    {
                        firstPlayerShips++;
                    }
                    else if (input[cols] == '>')
                    {
                        secondPlayerShips++;
                    }
                }
            }

            for (int i = 0; i < commands.Length; i++)
            {
                
                int[] digits = commands[i].Split().Select(int.Parse).ToArray();
                int currRow = digits[0];
                int currCol = digits[1];

                int[] result = new int[3] { 0, 0, 0 };
                if (currRow < 0 || currRow >= size || currCol < 0 || currCol >= size)
                {
                    continue;
                }
                char currentSymbol = matrix[currRow, currCol];

                result = Verificator(ref matrix, currRow, currCol);
                NewMethod(ref firstPlayerShips, ref secondPlayerShips, ref shipsSunk, result);

                if (currentSymbol == '#')
                {
                    matrix[currRow, currCol] = 'X';
                    if (currRow - 1 >= 0)
                    {
                        currRow -= 1;
                        result = Verificator(ref matrix, currRow, currCol);
                        NewMethod(ref firstPlayerShips, ref secondPlayerShips, ref shipsSunk, result);
                        currRow += 1;
                    }
                    if (currRow + 1 < size)
                    {
                        currRow += 1;
                        result = Verificator(ref matrix, currRow, currCol);
                        NewMethod(ref firstPlayerShips, ref secondPlayerShips, ref shipsSunk, result);
                        currRow -= 1;
                    }
                    if (currCol - 1 >= 0)
                    {
                        currCol -= 1;
                        result = Verificator(ref matrix, currRow, currCol);
                        NewMethod(ref firstPlayerShips, ref secondPlayerShips, ref shipsSunk, result);
                        currCol += 1;
                    }
                    if (currCol + 1 < size)
                    {
                        currCol += 1;
                        result = Verificator(ref matrix, currRow, currCol);
                        NewMethod(ref firstPlayerShips, ref secondPlayerShips, ref shipsSunk, result);
                        currCol -= 1;
                    }
                    if (currRow - 1 >= 0 && currCol - 1 >= 0)
                    {
                        currRow -= 1;
                        currCol -= 1;
                        result = Verificator(ref matrix, currRow, currCol);
                        NewMethod(ref firstPlayerShips, ref secondPlayerShips, ref shipsSunk, result);
                        currRow += 1;
                        currCol += 1;
                    }
                    if (currRow - 1 >= 0 && currCol + 1 < size)
                    {
                        currRow -= 1;
                        currCol += 1;
                        result = Verificator(ref matrix, currRow, currCol);
                        NewMethod(ref firstPlayerShips, ref secondPlayerShips, ref shipsSunk, result);
                        currRow += 1;
                        currCol -= 1;
                    }
                    if (currRow + 1 < size && currCol - 1 >= 0)
                    {
                        currRow += 1;
                        currCol -= 1;
                        result = Verificator(ref matrix, currRow, currCol);
                        NewMethod(ref firstPlayerShips, ref secondPlayerShips, ref shipsSunk, result);
                        currRow -= 1;
                        currCol += 1;
                    }
                    if (currRow + 1 < size && currCol + 1 < size)
                    {
                        currRow += 1;
                        currCol += 1;
                        result = Verificator(ref matrix, currRow, currCol);
                        NewMethod(ref firstPlayerShips, ref secondPlayerShips, ref shipsSunk, result);
                        currRow -= 1;
                        currCol -= 1;
                    }
                }
                if (secondPlayerShips <= 0)
                {
                    Console.WriteLine($"Player One has won the game! {shipsSunk} ships have been sunk in the battle.");
                    break;
                }
                else if (firstPlayerShips <= 0)
                {
                    Console.WriteLine($"Player Two has won the game! {shipsSunk} ships have been sunk in the battle.");
                    break;
                }
            }
            if (firstPlayerShips > 0 && secondPlayerShips > 0)
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {secondPlayerShips} ships left.");
            }

             
        }

        private static void NewMethod(ref int firstPlayerShips, ref int secondPlayerShips, ref int shipsSunk, int[] result)
        {
            firstPlayerShips -= result[1];
            secondPlayerShips -= result[2];
            shipsSunk += result[0];
        }

        private static int[] Verificator(ref char[,] matrix, int currRow, int currCol)
        {
            int[] verificator = new int[] { 0, 0, 0 };
            char currentSymbol = matrix[currRow, currCol];
            if (currentSymbol == '>')
            {
                verificator[0] += 1;
                verificator[2] += 1;
                matrix[currRow, currCol] = 'X';
            }
            else if (currentSymbol == '<')
            {
                verificator[0] += 1;
                verificator[1] += 1;
                matrix[currRow, currCol] = 'X';
            }
            return verificator;
        }
    }
}
