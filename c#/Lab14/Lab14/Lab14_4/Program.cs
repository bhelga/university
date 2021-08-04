using Lab14_4;
using System;
using System.Collections;

namespace Lab14_4
{
    class MyList<T> : IEnumerable, IEnumerator
    {

        int count = 0; //розмір масиву
        public int Count { get {return count; } }

        T[] mass = new T[1]; //створення масиву з вказам нами типом

        int position = -1; //позиція перерахунку
        int pos = -1; //позиція запису в масив

        public void Add(T mass) //добавлення елементів
        {
            count++;  //збільшуємо розмір
            Array.Resize(ref this.mass, count); //розиряємо масив
            pos++; //збільшуємо індекс
            this.mass[pos] = mass; //додаємо значення

        }
        //реалізаія методів інтерфейсу IEnumerator

        public bool MoveNext() //змінює лічильник або посилання на наступний елемент списку
        {
            position++;
            return (position < mass.Length);
        }

        public void Reset() //скинути лічильник
        {
            position = -1;
        }
        public T Current
        {
            get { try { return mass[position]; } catch (IndexOutOfRangeException) { throw new InvalidOperationException(); } }
        }


        object IEnumerator.Current //Повертає конкретний елемент списку
        {
            get { return Current; }
        }


        public IEnumerator GetEnumerator()//метод інтерфейсу IEnumerable
        {
            return mass.GetEnumerator();
        }

        public T this[int index]  //індексатор
        {
            get { return mass[index]; }
            set { mass[index] = value; }
        }


    }
}
class Program
{
    static void Main(string[] args)
    {
        // Перший варіант оголошення
        MyList<string> temp = new MyList<string>();
        temp.Add("Kyiv River Port");
        temp.Add("Pivdennyi (Southern) Bridge");
        temp.Add("National Taras Shevchenko University");
        temp.Add("The monument to St. Volodymyr");
        City Kiev = new City("Kiev", "Vitaliy Klichko", 482, "bla bla", "Ukrain", 2963199, temp);
        // Другий варіант оголошення
        City Chernivtsi = new City();
        Chernivtsi.Name = "Chernivtsi";
        Chernivtsi.Mayor = "Roman Klychuk";
        Chernivtsi.YearOfFounding = 1875;
        Chernivtsi.History = "bla bla bla";
        Chernivtsi.Geography = "Ukrain";
        Chernivtsi.Population = 267060;
        Chernivtsi.CultureArea = new MyList<string>() { "Chernivtsi Regional Museum", "Chernivtsi Art Museum", "History and Culture Museum of Bukovinian Jews",
                "Chernivtsi Regional Museum of Folk Architecture and Life", "Yuriy Fedkovich Literary Memorial Museum"};
        // Третій варіант оголошення
        City userCity = new City();
        userCity.InputInfo();
        var cityArray = new MyList<City>() { Kiev, Chernivtsi, userCity };

        Console.Clear();

        foreach (City city in cityArray)
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
