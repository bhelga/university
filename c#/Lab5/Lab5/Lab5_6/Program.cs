using System;

namespace Lab5_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 6, b = 4;
            int[,] matrix = new int[a, b];
            Random rand = new Random();
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    matrix[i, j] = rand.Next(0, 100);
                    Console.Write(String.Format("{0, 5} | ", matrix[i, j]));
                }
                Console.WriteLine();
            }
            int max = 0, sum = 0, index = 0;
            for (int i = 0; i < b; i++)
            {
                sum = 0;
                for (int j = 0; j < a; j++)
                {
                    sum += matrix[j, i];
                }
                if (max < sum)
                {
                    max = sum;
                    index = i + 1;
                }
            }
            Console.WriteLine($"Стовпець {index} мiстить найбiльшу суму елементiв – {max}");

        }
    }
}
