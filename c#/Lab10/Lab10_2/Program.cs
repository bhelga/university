using System;

namespace Lab10_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Перший спосіб задання
            var number1 = new Binary("100");
            Console.WriteLine("Status is : " + number1.ConvertStatus);
            // Другий спосіб задання
            var number2 = new Binary();
            number2.InputBinary();
            Console.WriteLine("Status is : " + number2.ConvertStatus);

            Console.Clear();

            int shift = 1;
            Console.WriteLine("Logic Block\n");
            Console.WriteLine($"{number1.BinaryNumber} & {number2.BinaryNumber} = " + number1.LogicMultiplication(number2) + "\nNumber status : " + number1.BinaryStatus);
            Console.WriteLine($"\n{number1.BinaryNumber} | {number2.BinaryNumber} = " + number1.LogicAddition(number2) + "\nNumber status : " + number1.BinaryStatus);
            Console.WriteLine($"\n{number1.BinaryNumber} ^ {number2.BinaryNumber} = " + number1.XOR(number2) + "\nNumber status : " + number1.BinaryStatus);
            Console.WriteLine($"\n~{number1.BinaryNumber} = " + number1.Inverse() + "\nNumber status : " + number1.BinaryStatus);
            Console.WriteLine($"\n~{number1.BinaryNumber} + 1 = " + number1.TwosComplement() + "\nNumber status : " + number1.BinaryStatus);
            Console.WriteLine($"\n{number1.BinaryNumber} << {shift} = " + number1.LeftShift(shift) + "\nNumber status : " + number1.BinaryStatus);
            Console.WriteLine($"\n{number1.BinaryNumber} >> {shift} = " + number1.RightShift(shift) + "\nNumber status : " + number1.BinaryStatus);

            Console.WriteLine("\n\nArithmetic Block\n");
            Console.WriteLine($"\n{number1.BinaryNumber} + {number2.BinaryNumber} = " + number1.Addition(number2) + "\nNumber status : " + number1.BinaryStatus);
            Console.WriteLine($"\n{number1.BinaryNumber} - {number2.BinaryNumber} = " + number1.Subtraction(number2) + "\nNumber status : " + number1.BinaryStatus);
            Console.WriteLine($"\n{number1.BinaryNumber} * {number2.BinaryNumber} = " + number1.Multiplication(number2) + "\nNumber status : " + number1.BinaryStatus);
            Console.WriteLine($"\n{number1.BinaryNumber} / {number2.BinaryNumber} = " + number1.Division(number2) + "\nNumber status : " + number1.BinaryStatus);

        }
    }
}
