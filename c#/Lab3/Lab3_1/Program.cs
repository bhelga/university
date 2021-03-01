using System;

namespace Lab3_1
{
    class Program
    {
        static double CorrectDInput(string str)
        {
            double point = 0.0;
            while (true)
            {
                Console.Write(str);
                if (!double.TryParse(Console.ReadLine(), out point))  // пробує перетворити строку в int, вертає true, якщо це можливо і записує дані в point
                {
                    Console.WriteLine("Value error!");
                }
                else if(point == 0)
                {
                    Console.WriteLine("Range error!");
                }
                else break;
            }
            return point;
        }
        static int CorrectIInput(string str)
        {
            int point = 0;
            while (true)
            {
                Console.Write(str);
                if (!int.TryParse(Console.ReadLine(), out point))  // пробує перетворити строку в int, вертає true, якщо це можливо і записує дані в point
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
            double a = CorrectDInput("Введiть дiйсне a:\t");
            int n = Convert.ToInt32(CorrectIInput("Введiть натуральне n(>0):\t"));
            double sum = 0;

            for(int i = n; i > 0; i--)
            {
                sum += Math.Log(Math.Abs(Math.Pow(a, i)));
            }

            Console.WriteLine($"The result is:\t{sum}");
            Console.ReadKey();
        }
    }
}
