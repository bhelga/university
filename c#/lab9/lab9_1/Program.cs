using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace lab9_1
{
    class Program
    {
        static void OutputArray<T>(List<T> array)
        {
            var d = 1;
            foreach (var i in array)
            {
                Console.Write($"{d++}.\t{i}\n");
            }
        }
        static string GenRandomString(string Alphabet, int Length)
        {
            //string Ret = "";
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder(Length - 1);
            int Position = 0;

            for (int i = 0; i < Length; i++)
            {
                Position = rnd.Next(0, Alphabet.Length - 1);
                sb.Append(Alphabet[Position]);
                //Ret = Ret + Alphabet[Position]; //- так делать не стоит, в данном случае StringBuilder дает явный выигрыш в скорости
            }

            //return Ret;

            return sb.ToString();
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            var temp = new List<string>();
            var size = rnd.Next(1, 10);
            var i = 0;
            while (i < size)
            {
                temp.Add(GenRandomString("QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm", rnd.Next(1, 26)));
                i++;
            }
            string path1 = "D:\\helga\\university\\programming\\university\\c#\\lab9\\TF_1.txt";
            string path2 = "D:\\helga\\university\\programming\\university\\c#\\lab9\\TF_2.txt";
            try
            {
                using (StreamWriter sw1 = new StreamWriter(path1, true, Encoding.Default))
                {
                    foreach (var l in temp)
                    {
                        sw1.WriteLine(l);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\n********* Text file *********\n");
            OutputArray<string>(temp);
            //File.WriteAllLines(@path1, temp);
            const int border = 20;
            string value;
            for (i = 0; i < size; i++)
            {
                if (temp[i].Length < border)
                {
                    value = new string(' ', border - temp[i].Length).Replace(" ", "&");
                    temp[i] += value; 
                }
                else if (temp[i].Length > border)
                {
                    temp[i] = temp[i].Substring(0, border);
                    try
                    {
                        using (StreamWriter sw2 = new StreamWriter(path2, true, Encoding.Default))
                        {
                            sw2.WriteLine(temp[i]);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            //File.WriteAllLines(@path1, temp);
            try
            {
                using (StreamWriter sw1 = new StreamWriter(path1, false, Encoding.Default))
                {
                    foreach (var l in temp)
                    {
                        sw1.WriteLine(l);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\n********* Text file after *********\n");
            //OutputArray<string>(temp);
            try
            {
                using (StreamReader sr = new StreamReader(path1))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\n\n********** Text file TF_2 ***********");
            try
            {
                using (StreamReader sr = new StreamReader(path2))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
