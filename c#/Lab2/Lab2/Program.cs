using System;

namespace Lab2
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
                else break;
            }
            return point;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Чи лежить точка всерединi заштрихованої областi?\n");
            double R = CorrectInput("Введiть R:\t");

            Console.WriteLine("Введiть (x, y):\t");
            double x = CorrectInput("Введiть x:\t");
            double y = CorrectInput("Введiть y:\t");
            if (x > R || x < -R || y > R || y < -R)
            {
                Console.WriteLine("Нi!");
                Console.ReadKey();
            }
            else
            {
                double round_y = Math.Sqrt((Math.Pow(R, 2) - Math.Pow(x, 2)));              // R^2 = x^2 + y^2
                double round_x = Math.Sqrt((Math.Pow(R, 2) - Math.Pow(y, 2)));

                if (x < -round_x || x > round_x || y < -round_y || y > round_y)             // якщо лежить за межами кола

                {
                    Console.WriteLine("Нi!");
                }
                else if (x == -round_x || x == round_x || y == -round_y || y == round_y)
                {
                    Console.WriteLine("На межi!");                }
                else
                {
                    if (((x >= 0 && y > 0) || (x < 0 && y <= 0)) || (x < 0 && y < x + R))
                    {
                        Console.WriteLine("Так!");
                    }
                    else if (x < 0 && y > x + R)
                    {
                        Console.WriteLine("Нi!");
                    }
                    else if (x > 0 && y < 0)
                    {
                        Console.WriteLine("Нi!");
                    }
                    else
                    {
                        Console.WriteLine("На межi!");
                    }
                }
            }
        }
    }
}
