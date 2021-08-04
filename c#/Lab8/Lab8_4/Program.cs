using System;

namespace Lab8_4
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
        static string[] CreateText(string[] firstText, string[] secondText)
        {
            string[] final = new string[firstText.Length];
            string key = " ";
            for (int i = 0; i < firstText.Length; i++)
            {
                for (int j = 0; j < secondText.Length; j++)
                {
                    if (firstText[i] == secondText[j])
                    {
                        break;
                    }
                    if (j == secondText.Length - 1)
                    {
                        if (firstText[i] != key)
                        {
                            final[i] = firstText[i];
                        }
                        key = firstText[i];
                    }
                }
            }
            return final;
        }
        static void Main(string[] args)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', ';', '!', '?', '"', '\'',
                '(', ')', '–', '\t' };
            string firstText = UkrInput("Enter first text:");
            string secondText = UkrInput("\n\nEnter second text:");
            string[] first = firstText.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            string[] second = secondText.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            string[] final = CreateText(first, second);
            string finalText = String.Join(" ", final);
            Console.WriteLine("\n\nFinal text is:\t" + finalText);
        }
    }
}
