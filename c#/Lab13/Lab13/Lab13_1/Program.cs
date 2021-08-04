using Microsoft.VisualBasic;
using System;
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
            DateTime date;
            int n = CorrectIntInput("Enter number of items in schedule : ");
            var schedule = new Train[n];
            for (int i = 0; i < n; i++)
            {
                Train temp = new Train();
                temp.InputInfo();
                schedule[i] = temp;
            }
            var list = new List<Train>();
            string path = @"D:\helga\university\programming\university\c#\Lab13\train.bin";

            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream fs = File.Create(path))
                bf.Serialize(fs, schedule);

            using (FileStream fs = File.OpenRead(path))
            {
                Train[] newSchedule = (Train[])bf.Deserialize(fs);
                //Array.Sort(newSchedule, (x, y) => String.Compare(x.Name, y.Name));
                //Array.Sort(newSchedule, (x, y) => x.Number.CompareTo(y.Number));
                //Array.Sort(newSchedule, (x, y) => x.Date.CompareTo(y.Date));
                foreach (var i in newSchedule)
                {
                    i.GetInfo();
                }
                Console.Write("Enter your date in format ");
                string d = Console.ReadLine();
                d += " 00:00:00";
                Console.WriteLine("Trains :");
                foreach (var i in newSchedule)
                {
                    if (i.Date.Date.ToString() == d)
                    {
                        Console.WriteLine(i.Name);
                        list.Add(i);
                    }
                }

                Console.ReadKey();
            }
            using (FileStream fls = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.None))
            {
                bf.Serialize(fls, list);
            }

            Console.Clear();
            Array.Sort(schedule, (x, y) => String.Compare(x.Name, y.Name));
            foreach (var i in schedule)
            {
                i.GetInfo();
            }
            Console.WriteLine("Press any key to start finding...");
            Console.ReadKey();
            Console.Clear();
            
            while (true)
            {
                Console.Write("Enter date and time you want to find (format : dd/MM/yyyy hh:mm tt) : ");
                string data = Console.ReadLine();
                try
                {
                    date = DateTime.ParseExact(data, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Your date is wrong! Try again!");
                }
            }
            var foundTrain = new List<Train>();
            foreach (var i in schedule)
            {
                if (i.Date > date)
                {
                    foundTrain.Add(i);
                }
            }
            if (foundTrain.Count == 0)
            {
                Console.WriteLine("Can't find train for you!");
            }
            else
            {
                Console.WriteLine("Trains you're looking for :\n");
                foreach (var i in foundTrain)
                {
                    i.GetInfo();
                    Console.WriteLine();
                }
            }

            Console.ReadKey();
        }
    }
}
