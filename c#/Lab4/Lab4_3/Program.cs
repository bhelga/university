using System;

namespace Lab4_3
{
    class Program
    {
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
                    if(point > 1)
                    {
                        break;
                    }
                }
            }
            return point;
        }
        static bool IsParallelLines(double A1, double B1, double C1, double A2, double B2, double C2)
        {
            if (A1 * B2 - A2 * B1 == 0 && C1 != C2)
            {
                Console.WriteLine("Лiнiї паралельнi");
                return true;
            }
            else if (A1 * B2 - A2 * B1 == 0 && C1 == C2)
            {
                Console.WriteLine("Лiнiї збiгаються");
                return false;
            }
            else
            {
                Console.WriteLine("Лiнiї не паралельнi");
                return false;
            }
        }
        static void Main(string[] args)
        {
            int n = CorrectIntInput("Введiть кiлькiсть прямих:\t");
            int counter = 0;
            bool flag = false;
            Console.WriteLine("Ax + By + C = 0");
            double[] A = new double[n];
            double[] B = new double[n];
            double[] C = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введiть коортинати {i + 1} прямої");
                A[i] = CorrectDoubleInput("Введiть А:\t");
                B[i] = CorrectDoubleInput("Введiть B:\t");
                C[i] = CorrectDoubleInput("Введiть C:\t");
            }
            for(int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    Console.Write($"{i + 1} та {j + 1} лiнiї:\t");
                    flag = IsParallelLines(A[i], B[i], C[i], A[j], B[j], C[j]);
                    if (flag)
                    {
                        counter++;
                    }
                }

            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine($"Серед вказаних n прямих {counter * 2} прямих взаємно паралельнi");
        }
    }
}
