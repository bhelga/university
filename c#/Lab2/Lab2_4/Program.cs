using System;

namespace Lab2_4
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
        static bool Queen(int queeneX, int queeneY, int anotherX, int anotherY)
        {
            int R1 = queeneY - queeneX;
            int R2 = queeneY + queeneX;
            if (anotherY == anotherX + R1 || anotherY == -anotherX + R2 || anotherY == queeneY || anotherX == queeneX)
            {
                return true;
            }
            else return false;

        }
        static bool King(int kingX, int kingY, int anotherX, int anotherY)
        {
            if (Math.Abs(anotherX - kingX) <=1 && Math.Abs(anotherY - kingY) <= 1)
            {
                return true;
            }
            else return false;
        }
        static void Main(string[] args)
        {
            //bool black_queen, black_king, white_kqueen, zahust1, zahust2;
            //black_queen = black_king = white_kqueen = zahust1 = zahust2 =false;
            int start = 1;
            int end = 8;
            int wqx, wqy, bqx, bqy, bkx, bky;
            string zahust = ""; 

            Console.Write("Введiть координати фiгур!\n\nБiлий ферзь:\n");
            wqx = CorrectPointInput(start, end, "x:\t");
            wqy = CorrectPointInput(start, end, "y:\t");

            Console.Write("\nЧорний король:\n");
            while (true)
            {
                bkx = CorrectPointInput(start, end, "x:\t");
                bky = CorrectPointInput(start, end, "y:\t");
                if (bkx == wqx && bky == wqy)
                {
                    Console.WriteLine("Error! This cell is full!\n");
                }
                else break;
            }

            Console.Write("\nЧорний ферзь:\n");
            while (true)
            {
                bqx = CorrectPointInput(start, end, "x:\t");
                bqy = CorrectPointInput(start, end, "y:\t");
                if ((bqx == wqx && bqy == wqy) || (bqx == bkx && bqy == bky))
                {
                    Console.WriteLine("Error! This cell is full!\n");
                }
                else break;
            }
            Console.Clear();
            Console.Write($"Введенi данi\n\nБiлий ферзь:\t({wqx}, {wqy})\nЧорний король:\t({bkx}, {bky})\nЧорний ферзь:\t({bqx}, {bqy})\n");
            if (Queen(bqx, bqy, bkx, bky))
            {
                zahust += "\nЧорний ферзь захищає короля";
            }
            if (King(bkx, bky, bqx, bqy))
            {
                zahust += "\nЧорний король захищає ферзя";
            }

            if (King(bkx, bky, wqx, wqy) && Queen(wqx, wqy, bqx, bqy))
            {
                Console.WriteLine("Бiлий ферзь може побити чорного ферзя i короля та навпаки залежно вiд ходу." + zahust);
            }
            else if (Queen(wqx, wqy, bqx, bqy) && !King(bkx, bky, wqx, wqy) && !Queen(wqx, wqy, bkx, bky))
            {
                Console.WriteLine("Бiлий ферзь може побити чорного ферзя та навпаки залежно вiд ходу." + zahust);
            }
            else if (Queen(wqx, wqy, bkx, bky) && Queen(wqx, wqy, bqx, bqy) && !King(bkx, bky, wqx, wqy))
            {
                Console.WriteLine("Бiлий ферзь може побити чорного ферзя та навпаки залежно вiд ходу i чорного короля." + zahust);
            }
            else if (King(bkx, bky, wqx, wqy) && !Queen(wqx, wqy, bqx, bqy))
            {
                Console.WriteLine("Бiлий ферзь може побити чорного короля." + zahust);
            }
            else
            {
                Console.WriteLine("Нiхто нiкого не б'є" + zahust);
            }
            Console.ReadKey();
        }
    }
}