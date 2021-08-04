using System;
using System.Collections.Generic;

namespace Lab10_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Перший варіант оголошення
            City Kiev = new City("Kiev", "Vitaliy Klichko", 482, "bla bla", "Ukrain", 2963199, 
                new List<string>(){ "Kyiv River Port", "Pivdennyi (Southern) Bridge", "National Taras Shevchenko University", "The monument to St. Volodymyr"});
            // Другий варіант оголошення
            City Chernivtsi = new City();
            Chernivtsi.Name = "Chernivtsi";
            Chernivtsi.Mayor = "Roman Klychuk";
            Chernivtsi.YearOfFounding = 1875;
            Chernivtsi.History = "bla bla bla";
            Chernivtsi.Geography = "Ukrain";
            Chernivtsi.Population = 267060;
            Chernivtsi.CultureArea = new List<string>() { "Chernivtsi Regional Museum", "Chernivtsi Art Museum", "History and Culture Museum of Bukovinian Jews",
                "Chernivtsi Regional Museum of Folk Architecture and Life", "Yuriy Fedkovich Literary Memorial Museum"};
            // Третій варіант оголошення
            City userCity = new City();
            userCity.InputInfo();
            var cityArray = new List<City>() { Kiev, Chernivtsi, userCity };

            Console.Clear();

            foreach (var city in cityArray)
            {
                city.GetInfo();
                city.GetCityStatus();
            }
            //Вивід інформації
            //Kiev.GetInfo();
            //Kiev.GetCityStatus();
            //Kiev.GetCityAge();

            //Chernivtsi.GetInfo();
            //Chernivtsi.GetCityStatus();
            //Chernivtsi.GetCityAge();

            //userCity.GetInfo();
            //userCity.GetCityStatus();
            //userCity.GetCityAge();

            City.GetOldestCity(cityArray);
        }
    }
}
