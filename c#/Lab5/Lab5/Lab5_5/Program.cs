using System;

namespace Lab5_5
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
                    if (point > 0)
                    {
                        break;
                    }
                }
            }
            return point;
        }
        static int CorrectInput(string str)
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
                    break;
                }
            }
            return point;
        }

        static void Main(string[] args)
        {
            int value = CorrectIntInput("Введiть кiлькiсть рядкiв:\t");
            int[][] array = new int[value][];
            int chain;
            for (int i = 0; i < value; i++)
            {
                chain = CorrectIntInput($"Введiть довжину {i + 1} ланцюга:\t");
                array[i] = new int[chain];
                for (int j = 0; j < chain; j++)
                {
                    array[i][j] = CorrectInput($"Введiть елемент [{i+1}][{j+1}]:\t");
                }
            }
            for (int i = 0; i < value; i++)
            {
                for (int j = 0; j < array[i].GetLength(0); j++)
                {
                    Console.Write($"{array[i][j]} | ");
                }
                Console.WriteLine();
            }
            int number = CorrectInput("Введiть ваше число:\t");
            int counter;
            int[] vector = new int[value];
            for (int i = 0; i < value; i++)
            {
                counter = 0;
                for (int j = 0; j < array[i].GetLength(0); j++)
                {
                    if (array[i][j] > number)
                    {
                        counter++;
                    }
                }
                vector[i] = counter;
                Console.WriteLine($"Кiльксть бiльших чисел в {i + 1} рядку:\t{vector[i]}");
            }

        }
    }
}
