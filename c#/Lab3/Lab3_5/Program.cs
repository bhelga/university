using System;

namespace Lab3_5
{
    class Program
    {
        static double CorrectInput(string str)
        {
            double point = 0;
            while (true)
            {
                Console.Write(str);
                if (!double.TryParse(Console.ReadLine(), out point))  // пробує перетворити строку в int, вертає true, якщо це можливо і записує дані в point
                {
                    Console.WriteLine("Value error!");
                }
                else if (point <= 0)
                {
                    Console.WriteLine("Range error!");
                }
                else break;
            }
            return point;
        }
        static void Main(string[] args)
        {
            double weight = CorrectInput("Введiть вагу зернятка в кг:\t");
            ulong cell;
            ulong sum = 0;
            for (int x = 0; x <= 63; x++)
            {
                cell = (ulong)Math.Pow(2, x);
                sum += cell;
                Console.WriteLine($"На клiтинцi {x+1} – {cell} зерен");
            }
            weight *= sum;
            Console.WriteLine($"Всього:\t{sum}\nВага:\t{weight} кг");
        }
    }
}
