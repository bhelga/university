using System;
using System.Collections.Generic;
using System.Text;

namespace Lab14_4
{
    class City
    {
        /*Місто:
         * 1. Назва
         * 2. Кількість населення (метод, який виводить статус міста)
         * 3. Мер
         * 4. Дата заснування (метод, який виводить, скільки років місту на даний момент)
         * 5. Геолокація (країна, в якій знаходиться місто)
         * 6. Історія міста
         * 7. Визначні місця
         */
        public string Name { get; set; }
        public string Mayor { get; set; }
        public int YearOfFounding { get; set; }
        public string History { get; set; }
        public string Geography { get; set; }
        public uint Population { get; set; }
        public MyList<string> CultureArea { get; set; }

        public City()
        {

        }

        public City(string name, string mayor, int year, string history, string geography, uint population, MyList<string> culture)
        {
            this.Name = name;
            this.Mayor = mayor;
            this.YearOfFounding = year;
            this.History = history;
            this.Geography = geography;
            this.Population = population;
            this.CultureArea = culture;
        }

        public void InputInfo()
        {
            Console.Write("Input city name : ");
            this.Name = Console.ReadLine();
            Console.Write("\nInput mayor : ");
            this.Mayor = Console.ReadLine();
            while (true)
            {
                Console.Write("\nInput year of founding : ");
                var i = 0;
                try
                {
                    this.YearOfFounding = int.Parse(Console.ReadLine());
                    i++;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Value error! Change your data!");
                }
                if (this.YearOfFounding < 0)
                {
                    Console.WriteLine("Range error! Change your data!");
                    i = 0;
                }
                if (i != 0) break;
            }
            Console.Write("\nInput city history : ");
            this.History = Console.ReadLine();
            Console.Write("\nInput location of city : ");
            this.Geography = Console.ReadLine();
            while (true)
            {
                var i = 0;
                uint n = 0;
                Console.Write("\nWrite total population : ");
                if (!uint.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("Value error!");
                }
                else
                {
                    this.Population = n;
                    break;
                }
            }
            Console.WriteLine("\nInput your culture (type \"exit\" to stop) :");
            var culture = new MyList<string>();
            while (true)
            {
                string temp = Console.ReadLine();
                if (temp == "exit") break;
                culture.Add(temp);
            }
            this.CultureArea = culture;
        }
        public void GetInfo()
        {
            Console.WriteLine($"City : {this.Name}\nMayor : {this.Mayor}\nYear of founding : {this.YearOfFounding}\nCity history : {this.History}" +
                $"\nCity location : {this.Geography}\nThe total population : {this.Population}\nSome culture of city :\n");
            var i = 1;
            foreach (var c in this.CultureArea)
            {
                Console.WriteLine($"{i}. {c}");
                i++;
            }
        }
        private int GetCityAge()
        {
            DateTime now = DateTime.Now;
            int age = now.Year - this.YearOfFounding;
            //if (age % 5 == 0)
            //{
            //    Console.WriteLine($"Jubilee! City age is {age}!");
            //}
            //else
            //{
            //    Console.WriteLine($"City age is {age}!");
            //}
            return age;
        }
        public void GetCityStatus()
        {
            string status = "";
            if (this.Population < 50000)
            {

                status = "small";
            }
            else if (this.Population < 100000)
            {

                status = "medium";
            }
            else if (this.Population < 500000)
            {

                status = "large";
            }
            else if (this.Population < 1000000)
            {

                status = "very large";
            }
            else
            {
                status = "millionaire";
            }
            Console.WriteLine($"City {this.Name} is {status}");
        }
        public static void GetOldestCity(MyList<City> cities)
        {
            int minAge = cities[0].YearOfFounding;
            var k = 0;
            for (var i = 0; i < cities.Count; i++)
            {
                if (cities[i].YearOfFounding < minAge)
                {
                    minAge = cities[i].YearOfFounding;
                    k = i;
                }
            }
            int cityAge = cities[k].GetCityAge();
            Console.WriteLine($"The oldest city is {cities[k].Name}. Its age is : {cityAge}");
        }
        //private string GetFoundingStatus()
        //{
        //    string status = "";
        //    int year = GetCityAge();
        //    if 
        //    return status;
        //}
    }
}
