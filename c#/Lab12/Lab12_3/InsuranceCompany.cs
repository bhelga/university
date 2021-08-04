using System;
using System.Collections.Generic;
using System.Text;

namespace Lab12_3
{
    class InsuranceCompany : Organization
    {
        public int NumberOfGeneralManager { get; set; }
        public int NumOfOrder { get; private set; } = 0;

        public InsuranceCompany(string name, int numberOfEmployees, List<string> typeOfActivity, double totalIncome, int numOfGeneralManager) : base(name, numberOfEmployees, typeOfActivity, totalIncome) 
        {
            this.NumberOfGeneralManager = numOfGeneralManager;
        }

        public override void GetInfo()
        {
            Console.WriteLine($"ORGANIZATION {this.Name.ToUpper()}\n\nNumber of employees : {this.NumberOfEmployees}\nType of activities :");
            foreach (var i in this.TypeOfActivity)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine($"Total income : {this.TotalIncome}\nPayment for taxes : {this.GetPaymentForTaxes()}\nProfit : {this.GetProfit()}Number of general managers : {this.NumberOfGeneralManager}\nNumber of order : {this.NumOfOrder}\n");
        }

        public override double GetPaymentForTaxes()
        {
            return this.TotalIncome * 0.18;
        }

        public override double GetProfit()
        {
            return this.TotalIncome - GetPaymentForTaxes() - 6000 * this.NumberOfEmployees - 2000 * this.NumberOfGeneralManager;
        }

        public void Order(string typeOfOrder)
        {
            foreach (var i in this.TypeOfActivity)
            {
                if (i == typeOfOrder)
                {
                    this.NumOfOrder++;
                }
            }
        }
    }
}
