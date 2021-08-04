using System;
using System.IO;
using System.Text;

namespace tryy
{
    struct State
    {
        public string name;
        public string capital;
        public int area;
        public double people;

        public State(string n, string c, int a, double p)
        {
            name = n;
            capital = c;
            people = p;
            area = a;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            State[] states = new State[2];
            states[0] = new State("Germany", "Berlin", 357168, 80.8);
            states[1] = new State("France", "Paris", 640679, 64.7);
            //System.Text.Encoding encoding = ;

            string path = @"D:\helga\university\programming\university\c#\Lab13\states.txt";

            try
            {
                // создаем объект BinaryWriter
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate), Encoding.ASCII))
                {
                    // записываем в файл значение каждого поля структуры
                    foreach (State s in states)
                    {
                        writer.Write(s.name);
                        writer.Write(s.capital);
                        writer.Write(s.area);
                        writer.Write(s.people);
                    }
                }
                // создаем объект BinaryReader
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open), Encoding.ASCII))
                {
                    // пока не достигнут конец файла
                    // считываем каждое значение из файла
                    while (reader.PeekChar() > -1)
                    {
                        string name = reader.ReadString();
                        string capital = reader.ReadString();
                        int area = reader.ReadInt32();
                        double population = reader.ReadDouble();

                        Console.WriteLine("Country: {0}  capital: {1}  area {2}; amount: {3}",
                            name, capital, area, population);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
