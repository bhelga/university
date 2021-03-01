using System;                                   // підключаємо простір імен

namespace HelloApp                              // оголошуємо новий простір імен
{
    class Program                               // оголошуємо новий клас
    {
        static void Main(string[] args)         // оголошуємо новий метод
        {
            Console.WriteLine("Enter your name: ");  // дія методу
            string name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}");

            Console.WriteLine(true);
            Console.WriteLine(false);

            Console.WriteLine(0b11);        // 3
            Console.WriteLine(0b1011);      // 11
            Console.WriteLine(0b100001);    // 33

            Console.WriteLine(0x0A);    // 10
            Console.WriteLine(0xFF);    // 255
            Console.WriteLine(0xA1);    // 161

            Console.WriteLine(3.2e3);   // 3.2 * 10^3 = 3200
            Console.WriteLine(1.2E-1);  // 1.2 * 10^-1 = 0.12

            Console.WriteLine('\x78');    // x (\x повертає символ в ASCII)
            Console.WriteLine('\x5A');    // Z

            Console.WriteLine('\u0420');    // Р (\u повертає символ в Unicode)
            Console.WriteLine('\u0421');    // С

            var hello = "Hell to World";
            var c = 20;

            Console.WriteLine(c.GetType().ToString());
            Console.WriteLine(hello.GetType().ToString());

            int x1 = 5;
            int z1 = ++x1; // z1=6; x1=6
            Console.WriteLine($"{x1} - {z1}");

            int x2 = 5;
            int z2 = x2++; // z2=5; x2=6
            Console.WriteLine($"{x2} - {z2}");

            int a = 3;
            int b = 5;
            int e = 40;
            int d = e-- - b * a;    // a=3  b=5  e=39  d=25
            Console.WriteLine($"a={a}  b={b}  e={e}  d={d}");

            Console.ReadKey();
        }
    }
}
