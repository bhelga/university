using System;

namespace Lab4_2
{
    class Program
    {
        static double Func(double x, int i=1)
        {
            if (x > 3 && i < 17)
            {
                return Math.Pow(Math.Sin(x), i) + Func(x, ++i);                
            }
            else if (x <= 3)
            {
                if (i > 5)
                {
                    return 15;
                }
                else
                {
                    return Math.Tan(x) + Func(Math.Tan(x), ++i);
                }
            }
            else
            {
                return 0;
            }
        }
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
                else break;
            }
            return point;
        }
        static void Main(string[] args)
        {
            double a = CorrectInput("Enter a:\t");
            double b = CorrectInput("Enter b:\t");
            Console.WriteLine("The result is:\t" + Math.Min(Func(a), Func(b)));
        }
    }
}
