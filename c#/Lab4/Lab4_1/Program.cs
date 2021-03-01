using System;

namespace Lab4_1
{
    class Program
    {
        static double VolumeOfCylinder(double height, double diameter)
        {
            return Math.PI * Math.Pow((diameter / 2), 2) * height;

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
            double height = CorrectInput("Enter height:\t");
            double diameter = CorrectInput("Enter diameter:\t");
            Console.WriteLine("The volume of the cylinder is:\t" + VolumeOfCylinder(height, diameter));

            Console.Write("R:\t");
            double r = double.Parse(Console.ReadLine());
            Console.Write("h:\t");
            double h = double.Parse(Console.ReadLine());
            double result = 1 / 3 * Math.PI * Math.Pow(r, 2) * h;
            Console.WriteLine(result);

        }
    }
}
