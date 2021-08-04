using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab12_5.cs
{
    class Goods : IComparable
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Size { get; set; }

        public Goods(string name, double price, double size)
        {
            Name = name;
            Price = price;
            Size = size;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name : {Name}\nPrice : {Price}\nSize : {Size}\n");
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Goods otherGoods = obj as Goods;
            if (otherGoods != null)
            {
                return this.Price.CompareTo(otherGoods.Price);
            }
            else
            {
                throw new ArgumentException("Object is not a Goods");
            }
        }

        
    }
    class GoodsComparer : IComparer<Goods>
    {
        public int Compare(Goods x, Goods y)
        {
            if (x.Price > y.Price)
            {
                return 1;
            }
            else
            {
                if (x.Size > y.Size)
                    return 1;
                else return -1;
            }
            //else
            //{
            //    return 0;
            //}
        }
    }
    class GoodsEnumerator : IEnumerable
    {
        public Goods[] goods { get; set; }
        public GoodsEnumerator(Goods[] goods)
        {
            Array.Sort(goods);
            this.goods = goods;
        }

        public IEnumerator GetEnumerator()
        {
            foreach(var i in goods)
            {
                yield return i;
            }
        }
    }


}
