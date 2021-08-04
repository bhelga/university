using System;

namespace Lab8_1
{
    class Program
    {
        static string UkrInput(string text)
        {
            Console.WriteLine(text);
            string str = "";
            str = Console.ReadLine();
            str = str.Replace("?", "i");
            return str;
        }
        static void Main(string[] args)
        {
            //8.1.1
            string name = UkrInput("Введiть назву роману та натиснiть Enter:\t");
            string author = UkrInput("Введiть iм'я автора роману та натиснiть Enter:\t");
            Console.Clear();
            Console.WriteLine($"Письменник – автор роману:\t{author} – автор роману {name}");

            //8.1.2
            string first = UkrInput("Введіть перший рядок:\t");
            string second = UkrInput("Введіть другий рядок:\t");
            if (first.Length < 3 || second.Length < 2)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                string third = String.Concat(first[1], first[2], second[second.Length - 2]);
                Console.WriteLine(third);
            }

            //8.1.3
            string word = "голова";
            Console.WriteLine("Our word:\t" + word);
            word += word.Substring(4, 1);
            word += word.Substring(1, 3);
            word += word.Substring(0, 1);
            word += word.Substring(5, 1);
            word = word.Substring(6, 6);
            Console.WriteLine("Our final word:\t" + word);
            Console.ReadKey();

            //8.1.4
            string userStr = UkrInput("Введіть ваш рядок:\t");
            userStr = userStr.Replace("ах", "ух");
            Console.WriteLine(userStr);
        }
    }
}
