using System;

namespace Lab13_5
{
    class Program
    {
        static void GetRating(string athlete, (double, double, double, double, double, double) competitionPoints, double olympicCompeition)
        {
            double avarege = (competitionPoints.Item1 + competitionPoints.Item2 + competitionPoints.Item3 + competitionPoints.Item4 + competitionPoints.Item5 + competitionPoints.Item6) / 6;
            double rating = 0.8 * avarege + 1.2 * olympicCompeition;
            Console.WriteLine($"Рейтинг спортсмена {athlete} рiвний {rating}.");
        }
        static void Main(string[] args)
        {
            GetRating("Petrenko", (10, 9.5, 9.7, 9, 10, 9.3), 9.9);
        }
    }
}
