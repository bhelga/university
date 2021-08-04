using System;
using System.Collections.Generic;
using System.Text;

namespace Lab12_3
{
    class Factory : Organization
    {
        public int NumberOfMachines { get; set; }
        public Factory(string name, int numberOfEmployees, List<string> typeOfActivity, double totalIncome, int numOfMachines)
            : base(name, numberOfEmployees, typeOfActivity, totalIncome) 
        {
            this.NumberOfMachines = numOfMachines;
        }

        public override void GetInfo()
        {
            Console.WriteLine($"ORGANIZATION {this.Name.ToUpper()}\n\nNumber of employees : {this.NumberOfEmployees}\nType of activities :");
            foreach (var i in this.TypeOfActivity)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine($"Total income : {this.TotalIncome}\nPayment for taxes : {this.GetPaymentForTaxes()}\nProfit : {this.GetProfit()}\nNumber of machines : {this.NumberOfMachines}");
        }

        public override double GetPaymentForTaxes()
        {
            return this.NumberOfEmployees * 6000 * 0.22;
        }

        public override double GetProfit()
        {
            return this.TotalIncome - GetPaymentForTaxes() - 6000 * this.NumberOfEmployees - this.NumberOfMachines * 1500;
        }

        public int GetAmuntOfProduction()
        {
            return (this.NumberOfMachines * 1000) + (this.NumberOfEmployees * 100);
        }
    }
}
