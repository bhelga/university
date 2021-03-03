using System;

namespace Lab5_1
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
        static double CorrectDoubleInput(string str)
        {
            double point = 0;
            while (true)
            {
                Console.Write(str);
                if (!double.TryParse(Console.ReadLine(), out point))  // пробує перетворити строку в int, вертає true, якщо це можливо і записує дані в point
                {
                    Console.WriteLine("Value error!");
                }
                else break;
            }
            return point;
        }
        static void Main(string[] args)
        {
            int value = CorrectIntInput("Введiть розмiрнiсть масиву:\t");
            double[] array = new double[value];
            for (int i = 0; i < value; i++)
            {
                array[i] = CorrectDoubleInput($"Введiть {i + 1} елемент масиву:\t");
            }
            Console.Clear();
            Console.WriteLine("Ваш масив:");
            foreach (var i in array)
            {
                Console.Write($"{i} | ");
            }
            double sum = 0;
            int x, y;
            while (true)
            {
                Console.WriteLine($"\nВведiть дiапазон вiд 1 до {value}:");
                x = CorrectIntInput("Початок:\t");
                y = CorrectIntInput("Кiнець:\t");
                if (x < value && y < value && x < y)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Range error! Try again!");
                }
            }
            for (; x <= y; x++)
            {
                sum += array[x - 1];
            }
            Console.WriteLine("Сума:\t" + sum);
        }
    }
}
