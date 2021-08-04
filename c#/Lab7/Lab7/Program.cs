using System;

namespace Lab7
{
    class Program
    {
        static void OutputArray(int[] array)
        {
            foreach (var i in array)
            {
                Console.Write($"{i} | ");
            }
        }
        static void Swap<T>(ref T a, ref T b)
        {
            T temp;
            temp = a;
            a = b;
            b = temp;
        }
        static int[] QuickSort(int[] array, int left, int right)
        {
            Random rand = new Random();
            int i = left, j = right;
            int pivot = array[rand.Next(0, right - left) + left];
            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }
                while (array[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    Swap<int>(ref array[i], ref array[j]);
                    i++;
                    j--;
                }
                if (left < j)
                {
                    QuickSort(array, left, j);
                }
                if (i < right)
                {
                    QuickSort(array, i, right);
                }
            }
            return array;
        }
        static void LineSearch(int[] arrayA, int[] arrayB)
        {
            int key = 3509;
            int valueA = arrayA.Length;
            int valueB = arrayB.Length;
            if (valueA <= 1 || valueB <= 1)
            {
                Console.WriteLine("\nError!");
            }
            Console.Write("\n\nSearching elements:\t");
            for (int i = 0; i < valueA - 1; i++)
            {
                for (int j = i + 1; j < valueA; j++)
                {
                    if (arrayA[i] == arrayA[j])
                    {
                        for (int k = 0; k < valueB; k++)
                        {
                            if (arrayA[i] == arrayB[k])
                            {
                                break;
                            }
                            if (k == valueB - 1)
                            {
                                if (arrayA[i] != key)
                                {
                                    Console.Write($"{arrayA[i]} | ");
                                }
                                key = arrayA[i];
                            }
                        }
                    }
                }
            }
        }
        static void BinarySearch(int[] arrayA, int[] arrayB)
        {
            int key = 3535;
            QuickSort(arrayA, 0, arrayA.Length - 1);
            QuickSort(arrayB, 0, arrayB.Length - 1);
            Console.Write("\n\nSearching elements:\t");
            for (int i = 0; i < arrayA.Length - 1; i++)
            {
                if (arrayA[i] == key)
                {
                    continue;
                }
                for (int j = i + 1; j < arrayA.Length; j++)
                {
                    if (arrayA[i] == arrayA[j])
                    {
                        if (Binary(arrayB, arrayA[i], 0, arrayB.Length - 1) == -78)
                        {
                            Console.Write($"{arrayA[i]} | ");
                            key = arrayA[i];
                            break;
                        }
                    }
                }
            }
        }
        static int Binary(int[] array, int key, int first, int last)
        {
            if (first > last)
            {
                return -78;
            }

            var middle = (first + last) / 2;
            var middleValue = array[middle];

            if (middleValue == key)
            {
                return middle;
            }
            else
            {
                if (middleValue > key)
                {
                    return Binary(array, key, first, middle - 1);
                }
                else
                {
                    return Binary(array, key, middle + 1, last);
                }
            }
        }
        static string LongestCommonSubstring(int[] aa, int[] bb)
        {
            string a = String.Concat<int>(aa);
            string b = String.Concat<int>(bb);
            var n = a.Length;
            var m = b.Length;
            var array = new int[n, m];
            var maxValue = 0;
            var maxI = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (a[i] == b[j])
                    {
                        array[i, j] = (i == 0 || j == 0)
                            ? 1
                            : array[i - 1, j - 1] + 1;
                        if (array[i, j] > maxValue)
                        {
                            maxValue = array[i, j];
                            maxI = i;
                        }
                    }
                }
            }

            return a.Substring(maxI + 1 - maxValue, maxValue);
        }
        static void Main(string[] args)
        {
            const int value = 10;
            int[] arrayA = new int[value];
            int[] arrayB = new int[value];
            Random rand = new Random();
            for (int i = 0; i < value; i++)
            {
                arrayA[i] = rand.Next(1, 10);
                arrayB[i] = rand.Next(1, 10);
            }
            Console.WriteLine("*** Array A ***");
            OutputArray(arrayA);
            Console.WriteLine("\n____________________________________________________\n\n*** Array B ***");
            OutputArray(arrayB);
            Console.Write("\n\nSorted array A:\t");
            OutputArray(QuickSort(arrayA, 0, value - 1));
            Console.Write("\n\nSorted array B:\t");
            OutputArray(QuickSort(arrayB, 0, value - 1));
            LineSearch(arrayA, arrayB);
            BinarySearch(arrayA, arrayB);
            Console.Write("\n\nThe biggest coincidence:\t");
            Console.WriteLine(LongestCommonSubstring(arrayA, arrayB));
        }
    }
}
