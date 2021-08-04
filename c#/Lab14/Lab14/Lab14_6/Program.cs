using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab13_1
{
    class Program
    {
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
                    if (point > 0)
                    {
                        break;
                    }
                }
            }
            return point;
        }
        [Serializable]
        struct Train
        {
            public string Name { get; set; }
            public int Number { get; set; }
            public DateTime Date { get; set; }
            static string format = "dd/MM/yyyy hh:mm tt";
            static CultureInfo provider = CultureInfo.InvariantCulture;

            public Train(string name, int number, string date, string time)
            {
                Name = name;
                Number = number;
                string data = $@"{date} {time}";
                Date = DateTime.ParseExact(data, format, provider);
            }
            public void GetInfo()
            {
                Console.WriteLine($"TRAIN {this.Name.ToUpper()}\n\nNumber of train : {this.Number}\nDate : {this.Date:d}\nTime : {this.Date.TimeOfDay}\n");
            }
            public void InputInfo()
            {
                Console.Write("Input train name : ");
                this.Name = Console.ReadLine();
                this.Number = CorrectIntInput("Inout number of train : ");

                while (true)
                {
                    try
                    {
                        Console.WriteLine("Enter date in format \"dd/MM/yyyy\" : ");
                        string date = Console.ReadLine();
                        Console.WriteLine("Enter time in format \"hh:mm tt\" : ");
                        string time = Console.ReadLine();
                        string data = $@"{date} {time}";
                        this.Date = DateTime.ParseExact(data, format, provider);
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Your date is wrong!");
                    }
                }
            }

            //public int CompareTo(object obj)
            //{
            //    if (obj == null) return 1;

            //    if (obj is Train otherTrain)
            //        return this.Name.CompareTo(otherTrain.Name);
            //    else
            //        throw new ArgumentException("Object is not a Temperature");
            //}
        }
        static void Main(string[] args)
        {
            string name = "STATION";
            var train1 = new Train("Train1", 1, "01/04/2021", "11:10 AM");
            var train2 = new Train("Train1", 2, "01/03/2021", "11:10 AM");
            var train3 = new Train("Train1", 3, "01/02/2021", "11:10 AM");
            var train4 = new Train("Train1", 4, "01/01/2021", "11:10 AM");
            var array = new ArrayList() { name };
            Console.WriteLine($"Amount of array : {array.Count}");
            array.Add(train4);
            array.Add(train1);
            array.Add(train2);
            array.Add(train3);
            Console.WriteLine($"Amount of array : {array.Count}");
            array.Clear();
            Console.WriteLine($"Amount of array : {array.Count}");
            Console.ReadKey();
        }
    }
}
