using System;

namespace Lab10_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // створюємо перше коло
            var circle1 = new Circle();
            double radius = 15.3;
            circle1.Radius = radius;                // радіус задаємо за допомогою властивостей
            circle1.InputCoordinates();             // координати вводимо з клавіатури 
            double S1 = circle1.GetArea();
            double P1 = circle1.GetCircumference();
            // circle1.Type = ""; – тут видає помилку, властивість доступна тільки для зчитування
            string type1 = circle1.Type;

            // створюємо друге коло
            Circle circle2 = new Circle(12, 12, 0, 0);  // створюємо через конструктор
            double S2 = circle2.GetArea();
            double P2 = circle2.GetCircumference();
            string type2 = circle2.Type;

            // виводимо інформацію про наші об'єкти
            Console.Clear();
            Console.WriteLine("First Circle : ");
            circle1.GetInfo();
            Console.WriteLine($"\nArea : {S1}\nCircumference : {P1}\nType : {type1}");
            Console.WriteLine("\nSecond Circle : ");
            circle2.GetInfo();
            Console.WriteLine($"\nArea : {S2}\nCircumference : {P2}\nType : {type2}");
        }
    }
}
