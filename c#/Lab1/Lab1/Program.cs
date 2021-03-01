using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("First task\nType the length of a side:\t");

            double side = double.Parse(Console.ReadLine());
            double perimeter = side * 4;
            double area = side * side;

            Console.WriteLine($"The square perimeter is {perimeter} " +
                $"and the area of the squares is {area}");

            Console.Write("\n__________________________________\nSecond task\n\nEnter x1:\t");

            double x1 = double.Parse(Console.ReadLine());
            Console.Write("Enter x2:\t");
            double x2 = double.Parse(Console.ReadLine());

            double result1 = (6 - Math.Cos(3 + x1)) 
                / (34 - 9 * Math.Pow(x2, 3.0) + x2);

            Console.WriteLine($"The result is:\t{result1}");

            Console.WriteLine("\n__________________________________\nThird task\n\nEnter alpha:\t");

            double alpha = double.Parse(Console.ReadLine()) 
                * Math.PI / 180; // якщо приймаємо в градусах

            double result2 = 1 - 0.25 * Math.Pow(Math.Sin(2 * alpha), 2) 
                + Math.Cos(2 * alpha);
            double result3 = Math.Pow(Math.Cos(alpha), 2) 
                + Math.Pow(Math.Cos(alpha), 4);

            Console.WriteLine($"The first answer is {result2}.\n" +
                $"The second answer is {result3}");

            Console.ReadKey();
        }
    }
}
