using System;
using System.Collections.Generic;
using System.Text;

namespace Lab12_1
{
    class Employees
    {
        public Employee Director { get; set; }
        public string ProjectName { get; set; }
        public List<Employee> ListOfEmployees { get; set; }
        public Employees()
        {

        }
        public Employees(List<Employee> list, string name)
        {
            ProjectName = name;
            ListOfEmployees = list;
            if (list != null && list.Count != 0)
            {
                Director = list[0];
            }
        }
        public Employees(Employee director, string name, List<Employee> list)
        {
            ProjectName = name;
            ListOfEmployees = list;
            Director = director;
        }
        ~Employees()
        {
            Console.Beep();
            Console.WriteLine("m Disposed");
        }
        public double CalculateBudget()
        {
            double sum = 0;
            foreach (var i in ListOfEmployees)
            {
                sum += i.CalculateMonthSalary();
            }
            return sum;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"{ProjectName.ToUpper()}\n\nDirector : {Director.Name}\nEmployees :\n");
            foreach (var i in ListOfEmployees)
            {
                Console.WriteLine();
                i.ShowInfo();
            }
        }
    }
}
