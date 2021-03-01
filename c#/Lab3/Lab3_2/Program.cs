using System;

namespace Lab3_2
{
    class Program
    {
        static long Factorial(int n)
        {
            long fact = 1;
            if (n == 0) return 1;
            else
            {
                for(int i = n; i > 0; i--)
                {
                    checked
                    {
                        try
                        {
                            fact *= i;
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Error! More than max-value-size!\nException: {0} > {1:E}.",
                                              fact, long.MaxValue);
                            return 0;
                        }
                    }
                }
                return fact;
            }
        }
        static double CorrectEpsInput(string str)
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
            double eps = CorrectEpsInput("Введiть точнiсть:\t");
            int k;
            int x = 1;
            double sum1 = 0, sum2 = 0;
            double num;
            long denominator = 0, factorial = 0;
            bool flag = true;

            checked
            {
                try
                {
                    while (x <= 5 && flag)
                    {
                        k = 0;
                        while (true)
                        {
                            factorial = Factorial(k + 2);
                            if (factorial == 0)
                            {
                                flag = false;
                                break;
                            }
                            Console.WriteLine("factorial " + factorial);
                            denominator = (k + 1) * factorial;
                            Console.WriteLine("denominator " + denominator);
                            if (denominator == 0)
                            {
                                Console.WriteLine($"Error! When k = {k} denominator is zero");
                                flag = false;
                                break;
                            }
                            num = Math.Pow(-1, k) * Math.Pow(x, (k + 2)) / denominator;
                            Console.WriteLine("num " + num);
                            if (Math.Abs(num) >= eps)
                            {
                                sum1 += num;
                                k++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        sum2 += sum1;
                        x++;
                        Console.WriteLine($"k is {k}");
                    }
                }
                catch
                {
                    Console.WriteLine("Error! More than max-value-size!\n");
                }
            }

            Console.WriteLine($"The result is:\t{sum2}");
            Console.ReadKey();
        }
    }
}