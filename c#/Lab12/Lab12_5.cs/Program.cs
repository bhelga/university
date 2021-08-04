using System;
using System.Collections.Generic;

namespace Lab12_5.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Goods goods1 = new Goods("Toy", 1500, 15);
            Goods goods2 = new Goods("Bread", 1500, 10);
            Goods goods3 = new Goods("Water", 1500, 15);

            Goods[] goods = new Goods[] { goods1, goods2, goods3 };
            Console.WriteLine("GOODS\n");
            foreach (var i in goods)
            {
                i.ShowInfo();
            }
            //Array.Sort(goods);
            //Console.WriteLine("\nGOODS SORTED BY PRIZE\n");
            //foreach (var i in goods)
            //{
            //    i.ShowInfo();
            //}
            Array.Sort(goods, new GoodsComparer());
            Console.WriteLine("\nGOODS SORTED BY PRIZE AND SIZE\n");
            foreach (var i in goods)
            {
                i.ShowInfo();
            }
            Goods goods4 = new Goods("Barbie", 2500, 30);
            Goods goods5 = new Goods("Cigarettes", 70, 7);
            Goods goods6 = new Goods("Phone", 25000, 12);

            GoodsEnumerator ge = new GoodsEnumerator(new Goods[] { goods4, goods5, goods6 });
            foreach (var i in ge)
            {
                Goods temp = (Goods)i;
                temp.ShowInfo();
            }
        }
    }
}
