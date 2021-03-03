﻿using System;

namespace Lab5_3
{
    class Program
    {
        static int CorrectIntInput(string str)
        {
            int point = 0;
            while (true)
            {
                Console.Write(str);
                if (!int.TryParse(Console.ReadLine(), out point))  // пробує перетворити строку в int, вертає true, якщо це можливо і записує дані в point
                {
                    Console.WriteLine("Value error!");
                }
                else
                {
                    if (point > 0 && point <= 20)
                    {
                        break;
                    }
                }
            }
            return point;
        }
        static void Main(string[] args)
        {
            int value = CorrectIntInput("Введiть розмiрнiсть матрицi:\t");
            Console.Clear();
            int[,] array = new int[value, value];
            Random rand = new Random();
            for (int i = 0; i < value; i++)
            {
                for (int j = 0; j < value; j++)
                {
                    array[i, j] = rand.Next(0, 2);
                    Console.Write(String.Format("{0, 5} | ", array[i, j]));
                }
                Console.WriteLine("");
            }
            int[] colomns = new int[value];
            int[] rows = new int[value];
            int sumCol, sumRow;
            for (int i = 0; i < value; i++)
            {
                sumCol = 0;
                sumRow = 0;
                for (int j = 0; j < value; j++)
                {
                    sumCol += array[j, i];
                    sumRow += array[i, j];
                }
                colomns[i] = sumCol;
                rows[i] = sumRow;
            }
            int counter = 0;
            for (int i = 0; i < value - 1; i++)
            {
                for (int j = i + 1; j < value; j++)
                {
                    if (colomns[i] == colomns[j] && i != j)
                    {
                        Console.WriteLine($"\nСума елементiв колонки {i + 1} дорiвнює сумi елементiв колонки {j + 1}");
                        counter++;
                    }
                    if (rows[i] == rows[j] && i != j)
                    {
                        Console.WriteLine($"\nСума елементiв рядка {i + 1} дорiвнює сумi елементiв рядка {j + 1}");
                        counter++;
                    }
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("Немає однакових сум!");
            }
        }
    }
}
