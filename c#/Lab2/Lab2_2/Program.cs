using System;

namespace Lab2_2
{
    struct Superhero
    {
        public string   superhero;
        public string   power;
        public int      point;
        public Superhero(string superhero, string power, int point)
        {
            this.superhero = superhero;
            this.power = power;
            this.point = point;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Супергерой:\t{superhero}\nОпис сили:\t{power}\nПотужність:\t{point}\n\n");
        }
    }

    struct Film
    {
        public string   name;
        public string   description;
        public string   actors;
        public int      fpoint;
        public Film(string name, string description, string actors, int fpoint)
        {
            this.name = name;
            this.description = description;
            this.actors = actors;
            this.fpoint = fpoint;
        }


        public void WriteInfo()
        {
            Console.WriteLine($"Назва фiльму:\t{name}\nОпис:\t{description}\nГоловнi актори:\t{actors}\nОцiнка:\t{fpoint}\n\n");
        }
    }

    class Program
    {
        static int CorrectInput(string str)
        {
            int point = 0;
            while (true)
            {
                Console.Write(str);
                if (!int.TryParse(Console.ReadLine(), out point))  // пробує перетворити строку в int, вертає true, якщо це можливо і записує дані в point
                {
                    Console.WriteLine("Value error!");
                }
                else break;
            }
            return point;
        }
        static int CorrectPointInput(int start, int end, string str)
        {
            int point = 0;
            while (true)
            {
                Console.Write(str);
                if (!int.TryParse(Console.ReadLine(), out point))  // пробує перетворити строку в int, вертає true, якщо це можливо і записує дані в point
                {
                    Console.WriteLine("Value error!");
                }
                else if (point < start || point > end)
                {
                    Console.WriteLine("Range error!");
                }
                else break;
            }
            return point;
        }
        static void Main(string[] args)
        {
            Superhero firstHero, secondHero, thirdHero;
            Film firstFilm, secondFilm, thirdFilm;
            int start = 1;
            int end = 10;
            int firstEvil = CorrectInput("Введiть розмiри першого зла:\t");
            int secondEvil = CorrectInput("Введiть розмiри другого зла:\t");
            Console.Clear();

            if (firstEvil < secondEvil)
            {
                Console.Write("Введiть iм'я першого супергероя:\t");
                firstHero.superhero = Console.ReadLine();
                Console.Write("Опишiть його силу:\t");
                firstHero.power = Console.ReadLine();
                firstHero.point = CorrectPointInput(start, end, "Оцiнiть його силу вiд 1 до 10:\t");
                Console.Clear();

                Console.Write("Введiть iм'я другого супергероя:\t");
                secondHero.superhero = Console.ReadLine();
                Console.Write("Опишiть його силу:\t");
                secondHero.power = Console.ReadLine();
                secondHero.point = CorrectPointInput(start, end, "Оцiнiть його силу вiд 1 до 10:\t");
                Console.Clear();

                Console.Write("Введiть iм'я третього супергероя:\t");
                thirdHero.superhero = Console.ReadLine();
                Console.Write("Опишiть його силу:\t");
                thirdHero.power = Console.ReadLine();
                thirdHero.point = CorrectPointInput(start, end, "Оцiнiть його силу вiд 1 до 10:\t");
                Console.Clear();

                Console.WriteLine("Вашi супергерої:\n");
                firstHero.DisplayInfo();
                secondHero.DisplayInfo();
                thirdHero.DisplayInfo();
            }
            else
            {
                Console.Write("Назва фільму:\t");
                firstFilm.name = Console.ReadLine();
                Console.Write("Опис:\t");
                firstFilm.description = Console.ReadLine();
                Console.Write("Головні актори:\t");
                firstFilm.actors = Console.ReadLine();
                firstFilm.fpoint = CorrectPointInput(start, end, "Оцінка від 1 до 10:\t");
                Console.Clear();

                Console.Write("Назва фільму:\t");
                secondFilm.name = Console.ReadLine();
                Console.Write("Опис:\t");
                secondFilm.description = Console.ReadLine();
                Console.Write("Головні актори:\t");
                secondFilm.actors = Console.ReadLine();
                secondFilm.fpoint = CorrectPointInput(start, end, "Оцінка від 1 до 10:\t");
                Console.Clear();

                Console.Write("Назва фільму:\t");
                thirdFilm.name = Console.ReadLine();
                Console.Write("Опис:\t");
                thirdFilm.description = Console.ReadLine();
                Console.Write("Головні актори:\t");
                thirdFilm.actors = Console.ReadLine();
                thirdFilm.fpoint = CorrectPointInput(start, end, "Оцінка від 1 до 10:\t");
                Console.Clear();

                Console.WriteLine("Вашi фiльми:\n");
                firstFilm.WriteInfo();
                secondFilm.WriteInfo();
                thirdFilm.WriteInfo();
            }
            Console.ReadKey();
        }
    }
}
