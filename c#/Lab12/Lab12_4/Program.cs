using System;

namespace Lab12_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Barn barn = new Barn(100, 30, 10);
            Warehouse warehouse = new Warehouse(100, 40, 10, 10);
            Console.WriteLine($"BARN : area -> {barn.GetArea()}, volume -> {barn.GetVolume()}");
            Console.WriteLine($"WAREHOUSE : area -> {warehouse.GetArea()}, volume -> {warehouse.GetVolume()}");
        }
    }
}
