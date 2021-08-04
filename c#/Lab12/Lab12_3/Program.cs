using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab12_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory organization1 = new Factory("Volkswagen", 55600, new List<string>() { "виготовлення автомобілей" }, 10000000, 1000);
            Factory organization2 = new Factory("МАМАЛИГІВСЬКИЙ ГІПСОВИЙ ЗАВОД", 1000, new List<string>() { "гіпсова штукатурка", "фінішна гіпсова шпаклівка", "щебінь гіпсового каменю", "гіпс будівельний" }, 50000, 100);
            InsuranceCompany organization3 = new InsuranceCompany("Guardian", 500, new List<string>() { "страхування будівель", "страхування авто" }, 10000, 25);
            InsuranceCompany organization4 = new InsuranceCompany("Oranta", 150000, new List<string>() { "страхування будівель", "страхування авто", "страхування життя" }, 100000, 25000);

            var organizations = new List<Organization>() { organization1, organization2, organization3, organization4 };

            Console.WriteLine("ORGANIZATION INFO");
            foreach (var i in organizations)
            {
                i.GetInfo();
            }

            while (true)
            {
                var find = new List<Organization>();
                Console.Write("Ви хочете знайти організацію з ... ");
                string type = Console.ReadLine();
                foreach (var i in organizations)
                {
                    foreach (var j in i.TypeOfActivity)
                    {
                        if (j == type)
                        {
                            find.Add(i);
                        }
                    }
                }
                if (find.Count > 0)
                {
                    Console.WriteLine("Організції, які ви шукали : ");
                    foreach (var i in find)
                    {
                        Console.WriteLine(i.Name);
                    }
                }
                else
                {
                    Console.WriteLine("\nУпс... Щось пішло не так! В базі немає організацій з цією спеціалізацією або введені дані некоректні!\n");
                    continue;
                }
                Console.Write("\nХочете продовжити пошук? (1 якщо так, будь-що якщо ні) : ");
                var opr = Console.ReadLine();
                if (opr != "1")
                {
                    break;
                }
            }
        }
    }
}
