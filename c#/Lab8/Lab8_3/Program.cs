using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab8_3
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
            char[] delimiterChars = { ' ', ',', '.', ':', ';', '!', '?', '"', '\'',
                '(', ')', '–', '\t' };
            string pattern = @"\b[аеиiоуяюєї]\w*";
            string text = UkrInput("Enter your text:\t");
            string[] temp = text.Split(delimiterChars);
            var words = new List<string>(temp);
            Console.WriteLine("\n\nChecking...");
            for (int i = 0; i < words.Count;)
            {
                if (Regex.IsMatch(words[i], pattern, RegexOptions.IgnoreCase))
                {
                    Console.WriteLine(words[i]);
                    words.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
            text = String.Join(" ", words);
            Console.Write("\n\nYour checked text:\t" + text);
        }
    }
}
