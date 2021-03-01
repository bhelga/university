using System;

namespace Lab3_3
{
    class Program
    {
        static double CorrectInput(string str)
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
        static void Main(string[] args)
        {
            Console.WriteLine("Чи потрапив вистрiл у мiшень?\n");
            double r = Math.Abs(CorrectInput("Введiть |R|:\t"));
            var header = String.Format(" {0,20}| {1,-25}| {2,-15}",
                              "Номер пострiлу", "Координати пострiлу", "Результат");
            string output = " ";
            //Console.Write(header);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Введiть (x, y) вистрiлу {i + 1}:\t");
                double x = CorrectInput("Введiть x:\t");
                double y = CorrectInput("Введiть y:\t");
                if (x > r || x < -r || y > r || y < -r)
                {
                    Console.WriteLine("Нi!");
                    output = String.Format("\n {0,-20}| {1,-25}| {2,-15}", i + 1, $"({x}, {y})", "Промах");
                }
                else
                {
                    double round_y = Math.Sqrt((Math.Pow(r, 2) - Math.Pow(x, 2)));              // r^2 = x^2 + y^2
                    double round_x = Math.Sqrt((Math.Pow(r, 2) - Math.Pow(y, 2)));

                    if (x < -round_x || x > round_x || y < -round_y || y > round_y)             // якщо лежить за межами кола

                    {
                        Console.WriteLine("Нi!");
                        output = String.Format("\n {0,-20}| {1,-25}| {2,-15}", i + 1, $"({x}, {y})", "Промах");
                    }
                    else if(x == -round_x || x == round_x || y == -round_y || y == round_y)
                    {
                        Console.WriteLine("На межi!");
                        output = String.Format("\n {0,-20}| {1,-25}| {2,-15}", i + 1, $"({x}, {y})", "На межi!");
                    }
                    else
                    {
                        if (((x >= 0 && y >= 0) || (x <= 0 && y <= 0)) || (x < 0 && y < x + r))
                        {
                            Console.WriteLine("Так!");
                            output = String.Format("\n {0,-20}| {1,-25}| {2,-15}", i + 1, $"({x}, {y})", "В цiль!");
                        }
                        else if (x < 0 && y > x + r)
                        {
                            Console.WriteLine("Нi!");
                            output = String.Format("\n {0,-20}| {1,-25}| {2,-15}", i + 1, $"({x}, {y})", "Промах");
                        }
                        else if(x > 0 && y < 0)
                        {
                            Console.WriteLine("Нi!");
                            output = String.Format("\n {0,-20}| {1,-25}| {2,-15}", i + 1, $"({x}, {y})", "Промах");
                        }
                        else
                        {
                            Console.WriteLine("На межi!");
                            output = String.Format("\n {0,-20}| {1,-25}| {2,-15}", i + 1, $"({x}, {y})", "На межi!");
                        }
                    }
                }
                header += output;
            }
            Console.Clear();
            Console.Write(header);
            Console.ReadKey();
        }
    }
}
