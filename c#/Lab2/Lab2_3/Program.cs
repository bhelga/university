using System;

namespace Lab2_3
{
    class Program
    {
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
            Console.WriteLine("Допомiжнi iнструкцiї:\n\n1 – пiка\n2 – трефа\n3 – бубна\n4 – чирва\n\n" +
                "6 – шiстка\n7 – сiмка\n8 – вiсiмка\n9 – дев'ятка\n10 – десятка\n11 – валет\n12 – дама\n13 – король\n14 – туз.\n\n" +
                "Натиснiть будь-яку клавiшу, щоб рухатися далi.");
            Console.ReadKey();
            Console.Clear();
            int i_suit = CorrectPointInput(1, 4, "Введiть номер мастi:\t");
            int i_rank = CorrectPointInput(6, 14, "Введiть номер рангу: \t");

            string s_suit = "";
            string s_rank = "";

            switch (i_suit)
            {
                case 1:
                    s_suit = "Пiка";
                    break;
                case 2:
                    s_suit = "Трефа";
                    break;
                case 3:
                    s_suit = "Бубна";
                    break;
                case 4:
                    s_suit = "Чирва";
                    break;
            }
            switch (i_rank)
            {
                case 6:
                    s_rank = "шiстка";
                    break;
                case 7:
                    s_rank = "сiмка";
                    break;
                case 8:
                    s_rank = "вiсiмка";
                    break;
                case 9:
                    s_rank = "дев'ятка";
                    break;
                case 10:
                    s_rank = "десятка";
                    break;
                case 11:
                    s_rank = "валет";
                    break;
                case 12:
                    s_rank = "дама";
                    break;
                case 13:
                    s_rank = "король";
                    break;
                case 14:
                    s_rank = "туз";
                    break;
            }

            Console.WriteLine($"Ваша карта:\t{s_suit} {s_rank}");
            Console.ReadKey();
        }
    }
}