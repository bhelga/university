using System;

namespace Lab11_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // створюємо перше коло
            var circle1 = new Circle();
            int radius = 15;
            circle1.Radius = radius;
            circle1[4] = 255;                       // використовуємо індекс, щоб задати значення
            circle1.InputCoordinates();             // координати вводимо з клавіатури 
            double S1 = circle1.GetArea();
            double P1 = circle1.GetCircumference();
            
            // метод перетворення об'єкта в строку і навпаки
            var temp = (string)circle1;     // явно
            Console.WriteLine("From obj to str ->\t" + temp);
            Circle tempCircle = temp;       // неявно
            Console.WriteLine("From str to obj:\n");
            tempCircle.GetInfo();
            
            // circle1.Type = ""; – тут видає помилку, властивість доступна тільки для зчитування
            string type1 = circle1.Type;

            Console.WriteLine("\nCircle color : " + circle1[4]);

            // створюємо друге коло
            Circle circle2 = new Circle(12, 12, 0, 0, 155);  // створюємо через конструктор
            Console.WriteLine($"\nCircle1 -> ({circle1[0]},{circle1[1]})\tCircle1 -> ({circle2[0]},{circle2[1]})");
            circle2++;
            circle1--;
            Console.WriteLine($"Circle1 -> ({circle1[0]},{circle1[1]})\tCircle1 -> ({circle2[0]},{circle2[1]})");
            if (circle1) circle1 *= 3;
            if (circle2) circle2 *= 2;
            Console.WriteLine($"Circle1 -> ({circle1[0]},{circle1[1]})\tCircle1 -> ({circle2[0]},{circle2[1]})\n");
            double S2 = circle2.GetArea();
            double P2 = circle2.GetCircumference();
            string type2 = circle2.Type;

            // виводимо інформацію про наші об'єкти
            //Console.Clear();
            Console.WriteLine("First Circle : ");
            circle1.GetInfo();
            Console.WriteLine($"\nArea : {S1}\nCircumference : {P1}\nType : {type1}");
            Console.WriteLine("\nSecond Circle : ");
            circle2.GetInfo();
            Console.WriteLine($"\nArea : {S2}\nCircumference : {P2}\nType : {type2}");
        }
    }
}
