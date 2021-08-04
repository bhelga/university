using System;
using System.Collections.Generic;
using System.Text;

namespace Lab12_1
{
    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public uint Experience { get; set; }
        public uint Hours { get; set; }

        public Employee()
        {

        }
        public Employee(string name)
        {
            Name = name;
            Salary = 3;
            Experience = 0;
            Hours = 160;
        }
        public Employee(string name, double salary, uint experience, uint hours)
        {
            Name = name;
            Salary = salary;
            Experience = experience;
            Hours = hours;
        }
        ~Employee()
        {
            Console.Beep();
            Console.WriteLine("m Disposed");
        }
        public virtual void ShowInfo()
        {
            Console.WriteLine($"EMPLOYEE:\nName : {Name}\nSalary : ${Salary} per hour\nHours : {Hours}\nExperience : {Experience} years");
        }
        public virtual double CalculateMonthSalary()
        {
            return Salary * Hours;
        }
    }
}
