using System;

namespace Lab3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int x = 10; x >= 0; x--)
            {
                if (x == 0)
                {
                    Console.WriteLine($"{x} green bottles hanging on the wall,\n" +
                    $"{x} green bottles hanging on the wall,\n" +
                    $"And no one green bottle should accidentally fall,\n");
                }
                else
                {
                    Console.WriteLine($"{x} green bottles hanging on the wall,\n" +
                    $"{x} green bottles hanging on the wall,\n" +
                    $"And if one green bottle should accidentally fall,\n" +
                    $"There'll be {x - 1} green bottles hanging on the wall.\n\n");
                }
            }
        }
    }
}
