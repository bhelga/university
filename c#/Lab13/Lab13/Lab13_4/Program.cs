using System;

namespace Lab13_4
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
        static double CorrectDoubleInput(string str)
        {
            double point = 0;
            while (true)
            {
                Console.Write(str);
                if (!double.TryParse(Console.ReadLine(), out point))  // пробує перетворити строку в int, вертає true, якщо це можливо і записує дані в point
                {
                    Console.WriteLine("Value error!");
                }
                else break;
            }
            return point;
        }
        static void ShowTuple((string name, double lenght, int numberOfBilding, string location) tuple)
        {
            Console.WriteLine($"\nStreet {tuple.name} :\n\nLenght : {tuple.lenght}\nNumber of building : {tuple.numberOfBilding}\nLocation : {tuple.location}\n");
        }
        static void Main(string[] args)
        {
            int n = CorrectIntInput("Enter amount of streets in your city : ");
            var city = new (string name, double lenght, int numberOfBilding, string location)[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Street name : ");
                string name = Console.ReadLine();
                double lenght = CorrectDoubleInput("Street len : ");
                int numOfBuilding = CorrectIntInput("Number of building : ");
                Console.Write("Street location : ");
                string location = Console.ReadLine();
                city[i] = (name:name, lenght:lenght, numberOfBilding:numOfBuilding, location:location);
            }
            Console.Clear();
            double avarage = 0;
            Console.WriteLine("-------------------CITY STREETS-------------------");
            foreach (var i in city)
            {
                ShowTuple(i);
                avarage += i.lenght;
            }
            avarage /= n;
            int counter = 0;
            foreach (var i in city)
            {
                if(i.lenght > avarage)
                {
                    Console.WriteLine($"Street {i.name} need double water");
                    counter++;
                }
            }
            Console.WriteLine($"\nAmount of streets, which need double water : {counter}");
        }
    }
}
