using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab9_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path1 = "D:\\helga\\university\\programming\\university\\c#\\lab9\\file_1.txt";
            string path2 = "D:\\helga\\university\\programming\\university\\c#\\lab9\\file_2.txt";
            string line = "";
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
            string result = Regex.Replace(line, @"\b[а-я]\b", "", RegexOptions.IgnoreCase);
            Console.WriteLine(result);
            try
            {
                using (StreamWriter sw2 = new StreamWriter(path2, true, Encoding.Default))
                {
                    sw2.WriteLine(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();

        }
    }
}
