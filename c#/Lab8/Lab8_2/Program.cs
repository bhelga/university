using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab8_2
{
    class Program
    {
        static void OutputArray<T>(List<T> array)
        {
            foreach (var i in array)
            {
                Console.Write($"{i}\n");
            }
        }
        static string UkrInput(string text)
        {
            Console.WriteLine(text);
            string str = "";
            str = Console.ReadLine();
            str = str.Replace("?", "i");
            return str;
        }
        static int CorrectIntInput(string str)
        {
            int point = 0;
            while (true)
            {
                Console.Write(str);
                if (!int.TryParse(Console.ReadLine(), out point))  // пробує перетворити строку в int, вертає true, якщо це можливо і записує дані в point
                {
                    Console.WriteLine("Value error! Try again!");
                }
                else
                {
                    if (point == 1 || point == 0)
                    {
                        break;
                    }
                    else Console.WriteLine("Range error! Try again!");
                }
            }
            return point;
        }
        static void Main(string[] args)
        {
            int counter;
            string str = "";
            var sr = new StreamReader("D:\\helga\\university\\programming\\university\\test.txt");
            StreamWriter sw;

            while (sr.EndOfStream != true)
            {
                str += sr.ReadLine();
            }
            sr.Close();

            string[] temp = str.Split(' ');
            var text = new List<string>(temp);
            Console.WriteLine("Text file:");
            OutputArray<string>(text);
            int flag = CorrectIntInput("\n\nDo you wanna change something(1 for \"Yes\", 0 for \"No\")?\t");
            if (flag == 1)
            {
                flag = CorrectIntInput("\nDo you wanna replace or remove element(1 for \"Replace\", 0 for \"Remove\")?\t");
                if (flag == 1)
                {
                    string element1 = UkrInput("\nEnter the element you want to replace:\t");
                    counter = -1;
                    for (int i = 0; i < text.Count; i++)
                    {
                        if (element1 == text[i])
                        {
                            counter = i;
                        }
                    }
                    if (counter != -1)
                    {
                        string element2 = UkrInput("\nEnter new element:\t");
                        text[counter] = element2;
                        Console.WriteLine("New data:");
                        OutputArray<string>(text);
                    }
                    else Console.WriteLine("Error! Can't find this element!");
                }
                else if (flag == 0)
                {
                    string element = UkrInput("Enter the element you wanna remove:\t");
                    counter = -1;
                    for (int i = 0; i < text.Count; i++)
                    {
                        if (element == text[i])
                        {
                            counter = i;
                        }
                    }
                    if (counter != -1)
                    {
                        text.Remove(element);
                        Console.WriteLine("New data:");
                        OutputArray<string>(text);
                    }
                    else Console.WriteLine("Error! Can't find this element!");
                }
            }
            string pattern = @"https?:\/\/[-a-zA-Z0-9@:%_\+.~#?&\/=]{2,256}\.com\b(\/[-a-zA-Z0-9@:%_\+.~#?&\/=]*)?";
            counter = 0;
            Console.WriteLine("\n\nChecking...");
            for (int i = 0; i < text.Count;)
            {
                if (Regex.IsMatch(text[i], pattern, RegexOptions.IgnoreCase))
                {
                    counter++;
                    Console.WriteLine(text[i]);
                    i++;
                }
                else
                {
                    text.RemoveAt(i);
                }
            }

            Console.WriteLine("\n\nOur file:");
            OutputArray<string>(text);
            var fi = new FileInfo("D:\\helga\\university\\programming\\university\\result.txt");
            sw = fi.CreateText();

            for (int i = 0; i < text.Count; i++)
            {
                sw.WriteLine(text[i].ToString());
            }
            Console.WriteLine($"\nNumber of elements:\t{counter}");
            sw.Close();
            Console.ReadKey();
        }
    }
}
