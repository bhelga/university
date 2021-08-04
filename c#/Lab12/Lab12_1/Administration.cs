using System;
using System.Collections.Generic;
using System.Text;

namespace Lab12_1
{
    class Administration : Employee
    {
        private const uint PRIZE = 10;
        public string Post { get; set; }
        public uint AmountOfAssignment { get; set; }

        
        public Administration() : base() { }
        public Administration(string name, string post) : base(name)
        {
            Post = post;
        }
        public Administration(string name, double salary, uint experience, uint hours, string post, uint assignment) : base(name, salary, experience, hours)
        {
            Post = post;
            AmountOfAssignment = assignment;
        }
        ~Administration()
        {
            Console.Beep();
            Console.WriteLine("m Disposed");
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"ADMINISTRATION EMPLOYEE:\nName : {Name}\nPost : {Post}\nSalary : ${Salary} per hour\nHours : {Hours}\nAmount of Assignment : {AmountOfAssignment}\nExperience : {Experience} years");
        }
        public override double CalculateMonthSalary()
        {
            return Salary * Hours + (PRIZE * AmountOfAssignment);
        }
    }
}
