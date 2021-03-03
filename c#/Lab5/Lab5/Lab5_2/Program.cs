using System;

namespace Lab5_2
{
    class Program
    {
        static void Swap<T>(ref T a, ref T b)
        {
            T temp;
            temp = a;
            a = b;
            b = temp;
        }
        static void Main(string[] args)
        {
            int value = 20;
            int[] array = new int[value];
            Random rand = new Random();
            for (int i = 0; i < value; i++)
            {
                array[i] = rand.Next(-11, 20);
            }
            Console.WriteLine("Your array:");
            foreach (var i in array)
            {
                Console.Write($"{i} | ");
            }
            int min = array[0], minIndex = 0;
            int max = array[0], maxIndex = 0;
            for (int i = 0; i < value; i++)
            {
                if (min > array[i])
                {
                    min = array[i];
                    minIndex = i;
                }
                if (max < array[i])
                {
                    max = array[i];
                    maxIndex = i;
                }
            }
            Console.WriteLine($"\n\nMin element is: {min}\tPosition:\t[{minIndex}]\nMax element is: {max}\tPosition:\t[{maxIndex}]");
            Swap<int>(ref array[minIndex], ref array[maxIndex]);
            if (minIndex > maxIndex)
            {
                Swap<int>(ref minIndex, ref maxIndex);
            }
            int sum = 0;
            for (int k = minIndex; k <= maxIndex; k++)
            {
                sum += array[k];
                //Console.WriteLine("\nThe sum is:\t" + sum);
            }
            Console.WriteLine("\nYour new array:");
            foreach (var i in array)
            {
                Console.Write($"{i} | ");
            }
            Console.WriteLine("\nThe sum is:\t" + sum);
        }
    }
}
