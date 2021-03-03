using System;

namespace Lab5_4
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
                    if (point > 0 && point <= 18)
                    {
                        break;
                    }
                }
            }
            return point;
        }
        static void Main(string[] args)
        {
            int carriage = 18;
            int seat = 54;
            int[,] train = new int[carriage, seat];
            Random rand = new Random();
            for (int i = 0; i < carriage; i++)
            {
                for(int j = 0; j < seat; j++)
                {
                    train[i, j] = rand.Next(0, 2);
                    Console.Write($"{train[i, j]}|");
                }
                Console.WriteLine();
            }
            int usersCarr = CorrectIntInput("Ваш вагон:\t");
            int counter = 0;
            for (int i = 0; i < seat; i++)
            {
                if (train[usersCarr - 1, i] == 0)
                {
                    Console.WriteLine($"Мiсце {i + 1} вiльне");
                    counter++;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("Вiльних мiсць немає!");
            }
        }
    }
}
