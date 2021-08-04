using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person(43, 2225, "Bodya gay");
            Person person2 = new Person(19, 2123123.0, "Olga");
            Person person3 = new Person(22, 22.5, "Dick");
            Person person4 = new Person(53, 0.5, "Huy");
            Person person5 = new Person();

            person5.InputInfo();
            Person[] personArray = new Person[] { person1, person2, person3, person4, person5};

            foreach(var p in personArray)
            {
                p.GetInfo();
                Console.WriteLine();
                Console.WriteLine("Year salary of " + p.Name + " is " + p.YearSalary());
            }

            Console.WriteLine("Amount of young people : " + Person.GetAmountOfYoungPeople(personArray));
            Console.ReadLine();
        }
    }
}
