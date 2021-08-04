using System;

namespace Lab12_2
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
        static void Main(string[] args)
        {
            Console.WriteLine("YOUR COMPUTER : ");
            var cpu1 = CorrectDoubleInput("Enter CPU Frequency (in MHz) : ");
            var numOfCores1 = CorrectIntInput("Input number of cores : ");
            var memory1 = CorrectIntInput("Input memory (in MB) : ");
            var hardDiskCapacity1 = CorrectDoubleInput("Input Hard Disk Capacity (in GB) : ");
            Computer device1 = new Computer(cpu1, numOfCores1, memory1, hardDiskCapacity1);
            Console.WriteLine("\nYOUR LAPTOP : ");
            var cpu2 = CorrectDoubleInput("Enter CPU Frequency (in MHz) : ");
            var numOfCores2 = CorrectIntInput("Input number of cores : ");
            var memory2 = CorrectIntInput("Input memory (in MB) : ");
            var hardDiskCapacity2 = CorrectDoubleInput("Input Hard Disk Capacity (in GB) : ");
            var batteryDuration = CorrectIntInput("Input battery duration (in min) : ");
            Laptop device2 = new Laptop(cpu2, numOfCores2, memory2, hardDiskCapacity2, batteryDuration);
            Console.WriteLine("\nYOUR TABLET : ");
            var cpu3 = CorrectDoubleInput("Enter CPU Frequency (in MHz) : ");
            var numOfCores3 = CorrectIntInput("Input number of cores : ");
            var memory3 = CorrectIntInput("Input memory (in MB) : ");
            var hardDiskCapacity3 = CorrectDoubleInput("Input Hard Disk Capacity (in GB) : ");
            var weight = CorrectDoubleInput("Inout weight (in kg) : ");
            Tablet device3 = new Tablet(cpu3, numOfCores3, memory3, hardDiskCapacity3, weight);

            Console.Clear();

            device1.GetInfo();
            device2.GetInfo();
            device3.GetInfo();

            Console.ReadKey();
        }
    }
}
