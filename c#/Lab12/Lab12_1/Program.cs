using System;
using System.Collections.Generic;

namespace Lab12_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             1. 3 поля
             2. 3 конструктори
             3. Деструктор
             4. Метод 
             5. Вивід інформації
             Ієрархія:
             - база – робітник -> інженер/адміністрація, кадри
             */
            Engineers employee1 = new Engineers("Andew", 10000, 10, 168, 100500, "Senior Full Stack Software Engineer (.NET+JS)", 5);
            Engineers employee2 = new Engineers("Helga", 10, 0, 168, 100500, "Trainee .net Software Engineer", 0);
            Engineers employee3 = new Engineers("Stas", 100000, 12, 168, 1000, "Middle Full Stack Software Engineer", 5);
            Administration employee4 = new Administration("Sveta", 3, 10, 4, "Helpdesk specialist", 2);
            Administration employee5 = new Administration("Victor", 3, 10, 4, "Director", 2);
            var list = new List<Employee>() { employee1, employee2, employee3, employee4, employee5 };
            var project = new Employees(employee5, "MicroRaptor", list);
            project.ShowInfo();
            Console.WriteLine("\n\nBudget : " + project.CalculateBudget());
            Console.ReadKey();
        }
    }
}
