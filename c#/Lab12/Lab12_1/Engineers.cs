using System;
using System.Collections.Generic;
using System.Text;

namespace Lab12_1
{
    class Engineers : Employee
    {
        public double SalaryBonus { get; private set; }
        public int DepartmentID { get; set; }
        public string Post { get; set; }
        private uint projectComplexity;
        public uint ProjectComplexity
        {
            get
            {
                return projectComplexity;
            }
            set
            {
                if (value > 5)
                {
                    throw new Exception("\nWrong value!");
                }
                else
                {
                    switch (value)
                    {
                        case 0:
                            projectComplexity = value;
                            SalaryBonus = 0.5;
                            break;
                        case 1:
                            projectComplexity = value;
                            SalaryBonus = 1;
                            break;
                        case 2:
                            projectComplexity = value;
                            SalaryBonus = 1.2;
                            break;
                        case 3:
                            projectComplexity = value;
                            SalaryBonus = 1.5;
                            break;
                        case 4:
                            projectComplexity = value;
                            SalaryBonus = 1.7;
                            break;
                        case 5:
                            projectComplexity = value;
                            SalaryBonus = 2;
                            break;
                    }
                }
            }
        }
        public Engineers() : base() { }
        public Engineers(string name, int departmentID, string post) : base(name) 
        {
            DepartmentID = departmentID;
            Post = post;
        }
        public Engineers(string name, double salary, uint experience, uint hours, int departmentID, string post, uint complexity) : base(name, salary, experience, hours) 
        {
            ProjectComplexity = complexity;
            DepartmentID = departmentID;
            Post = post;
        }
        ~Engineers()
        {
            Console.Beep();
            Console.WriteLine("m Disposed");
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"ENGINEER EMPLOYEE:\nName : {Name}\nDepartment ID : {DepartmentID}\nPost : {Post}\nSalary : ${Salary} per hour\nHours : {Hours}\nSalary bonus : {SalaryBonus}\nExperience : {Experience} years");
        }
        public override double CalculateMonthSalary()
        {
            return Salary * Hours * SalaryBonus;
        }
    }
}
