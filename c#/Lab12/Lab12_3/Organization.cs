using System;
using System.Collections.Generic;
using System.Text;

namespace Lab12_3
{
    abstract class Organization
    {
        public string Name { get; set; }
        public int NumberOfEmployees { get; set; }
        public List<string> TypeOfActivity { get; set; }
        public double TotalIncome { get; set; }

        public Organization(string name, int numberOfEmployees, List<string> typeOfActivity, double totalIncome)
        {
            this.Name = name;
            this.NumberOfEmployees = numberOfEmployees;
            this.TypeOfActivity = typeOfActivity;
            this.TotalIncome = totalIncome;
        }
        public abstract void GetInfo();
        public abstract double GetPaymentForTaxes();
        public abstract double GetProfit();
    }
}