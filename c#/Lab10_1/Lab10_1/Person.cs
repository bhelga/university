using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_1
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }

        public Person()
        {

        }

        public Person(int age, double salary, string name)
        {
            this.Age = age;
            this.Salary = salary;
            this.Name = name;
        }
             
        public void GetInfo()
        {
            Console.WriteLine("Name : " + this.Name + "\nAge : " + this.Age + "\nSalary : " + this.Salary); 
        }

        public void InputInfo()
        {
            Console.WriteLine("Input age :");
            this.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input name :");
            this.Name = Console.ReadLine();
            Console.WriteLine("Input Salary : ");
            this.Salary = double.Parse(Console.ReadLine());
        }

        public double YearSalary()
        {
            double year = this.Salary * 12;
            return year;
        }

        public static int GetAmountOfYoungPeople(Person[] people)
        {
            int count = 0;
            foreach(var p in people)
            {
                if (p.Age < 40)
                {
                    count++;
                }
            }
            return count;
        }



    }
}
