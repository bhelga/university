using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab9_3
{
    class Program
    {
        static int CorrectInt(string data)
        {
            int point = 0;
            try
            {
                point = int.Parse(data);
            }
            catch(FormatException e)
            {
                Console.WriteLine("Value error! Change your data!");
            }
            return point;
        }
        static void Main(string[] args)
        {
            string key = "";
            string line = "";
            string path1 = "D:\\helga\\university\\programming\\university\\c#\\lab9\\calculator.txt";
            string path2 = "D:\\helga\\university\\programming\\university\\c#\\lab9\\result.txt";
            int index = 0;
            char oprt = ' ';
            double result = 0;
            int i;
            do
            {
                Console.WriteLine("Update your data and press any cay to continue!");
                Console.ReadKey();
                try
                {
                    using (StreamReader sr = new StreamReader(path1))
                    {
                        line = sr.ReadToEnd();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                line = line.Replace(" ", "");
                for (i = 0; i < line.Length; i++)
                {
                    if (line[i] == '+' || line[i] == '-' || line[i] == '*' || line[i] == '/')
                    {
                        oprt = line[i];
                        index = i;
                    }
                }
                if (index == 0)
                {
                    Console.WriteLine("Error! Change data and try again!");
                    continue;
                }
                string firstDi = line.Substring(0, index);
                string secondDi = line.Substring(index + 1, i - index - 1);
                double firstDigit, secondDigit;
                try
                {
                    firstDigit = double.Parse(firstDi);
                    secondDigit = double.Parse(secondDi);
                }
                catch(FormatException e)
                {
                    Console.WriteLine("Value error! Change your data!");
                    continue;
                }
                try
                {
                    switch (oprt)
                    {
                        case '+':
                            result = firstDigit + secondDigit;
                            break;
                        case '-':
                            result = firstDigit - secondDigit;
                            break;
                        case '*':
                            result = firstDigit * secondDigit;
                            break;
                        case '/':
                            result = firstDigit / secondDigit;
                            break;
                        default:
                            Console.WriteLine("Something is wrong!");
                            break;
                    }
                }
                catch(DivideByZeroException e)
                {
                    Console.WriteLine("Error! Divide By Zero! Change your data!");
                    continue;
                }
                try
                {
                    using (StreamWriter sw2 = new StreamWriter(path2, false, Encoding.Default))
                    {
                        sw2.WriteLine(line + "\nThe result : " + result);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("The result is : " + result);
                Console.WriteLine("\nWrite exit to break the program : ");
                key = Console.ReadLine();
            } while (key != "exit");
        }
    }
}