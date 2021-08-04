using System;

namespace Lab6_1
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
        static int[] BubbleSort(int[] array, int k = 0)
        {
            int value = array.Length;
            for (int i = 0; i < value; i++)
            {
                for (int j = 0; j < value - 1; j++)
                {
                    if (k == 0 && array[j] > array[j + 1])
                    {
                        Swap<int>(ref array[j], ref array[j + 1]);
                    }
                    else if (k == 1 && array[j] < array[j + 1])
                    {
                        Swap<int>(ref array[j], ref array[j + 1]);
                    }
                }
            }
            return array;
        }
        static int[] CoctailSort(int[] array, int k = 0)
        {
            bool flag = true;
            int start = 0;
            int end = array.Length;
            while (flag)
            {
                flag = false;
                for (int i = start; i < end - 1; i++)
                {
                    if (k == 0 && array[i] > array[i + 1])
                    {
                        Swap<int>(ref array[i], ref array[i + 1]);
                        flag = true;
                    }
                    else if (k == 1 && array[i] < array[i + 1])
                    {
                        Swap<int>(ref array[i], ref array[i + 1]);
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    break;
                }
                flag = false;
                --end;
                for (int i = end - 1; i >= start; i--)
                {
                    if (k == 0 && array[i] > array[i + 1])
                    {
                        Swap<int>(ref array[i], ref array[i + 1]);
                        flag = true;
                    }
                    else if (k == 1 && array[i] < array[i + 1])
                    {
                        Swap<int>(ref array[i], ref array[i + 1]);
                        flag = true;
                    }
                }
                ++start;
            }
            return array;
        }
        static int[] InsertionSort(int[] array, int k = 0)
        {
            int value = array.Length;
            for (var i = 1; i < value; i++)
            {
                var key = array[i];
                var j = i - 1;
                for (j = i - 1; j >= 0; j--)
                {
                    if (array[j] < key && k == 0)
                    {
                        break;
                    }else if (array[j] > key && k == 1)
                    {
                        break;
                    }
                    array[j + 1] = array[j];
                }
                array[j + 1] = key;
            }
            return array;
        }
        static int[] StoogeSort(int[] array, int start, int end, int k = 0)
        {
            if (k == 0)
            {
                if (array[start] > array[end])
                {
                    Swap<int>(ref array[start], ref array[end]);
                }
                if (end - start > 1)
                {
                    int temp = (end - start + 1) / 3;
                    StoogeSort(array, start, end - temp);
                    StoogeSort(array, start + temp, end);
                    StoogeSort(array, start, end - temp);
                }
            }
            else if (k == 1)
            {
                if (array[start] < array[end])
                {
                    Swap<int>(ref array[start], ref array[end]);
                }
                if (end - start > 1)
                {
                    int temp = (end - start + 1) / 3;
                    StoogeSort(array, start, end - temp, 1);
                    StoogeSort(array, start + temp, end, 1);
                    StoogeSort(array, start, end - temp, 1);
                }
            }
            return array;
        }
        static int[] ShellSort(int[] array, int k = 0)
        {
            int value = array.Length;
            for (int h = value/2; h > 0; h /= 2)
            {
                for (int i = h; i < value; i++)
                {
                    int temp = array[i];
                    int j = i;
                    if (k == 0)
                    {
                        for (; j >= h && array[j - h] > temp; j -= h)
                        {
                            array[j] = array[j - h];
                        }
                    }
                    else if (k == 1)
                    {
                        for (; j >= h && array[j - h] < temp; j -= h)
                        {
                            array[j] = array[j - h];
                        }
                    }
                    array[j] = temp;
                }
            }
            return array;
        }
        static int[] Merge(int[] left, int[] right)
        {
            int resutValue = left.Length + right.Length;
            int[] result = new int[resutValue];
            int indexLeft = 0, indexRight = 0, indexResult = 0;
            while (indexLeft < left.Length || indexRight < right.Length)
            {
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    if (left[indexLeft] <= right[indexRight])
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            return result;
        }
        static int[] MergeSort(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }
            int middle = array.Length / 2;
            int[] left = new int[middle];
            int[] right;
            if (array.Length % 2 == 0)
            {
                right = new int[middle];
            }
            else
            {
                right = new int[middle + 1];
            }
            int[] result = new int[array.Length];
            for (int i = 0, x = middle; i < middle; i++, x++)
            {
                left[i] = array[i];
            }
            for (int i = middle, x = 0; i < array.Length; i++, x++)
            {
                right[x] = array[i];
            }
            left = MergeSort(left);
            right = MergeSort(right);
            result = Merge(left, right);
            return result;
        }
        static int[] SelectionSort(int[] array, int k = 0)
        {
            if (k == 0)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    int min = i;
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[j] < array[min])
                        {
                            min = j;
                        }
                    }
                    Swap<int>(ref array[i], ref array[min]);
                }

            }
            else if (k == 1)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    int max = i;
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[j] > array[max])
                        {
                            max = j;
                        }
                    }
                    Swap<int>(ref array[i], ref array[max]);
                }

            }
            return array;
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
                while(array[j] > pivot)
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
        static void Main(string[] args)
        {
            const int value = 10;
            int[] arrayA = new int[value];
            int[] arrayB = new int[value];
            Random rand = new Random();
            for (int i = 0; i < value; i++)
            {
                arrayA[i] = rand.Next(-49, 51);
                arrayB[i] = rand.Next(-49, 51);
            }
            Console.WriteLine("*** Array A ***");
            OutputArray(arrayA);

            //Bubble Sort a <= b
            arrayA = BubbleSort(arrayA);
            Console.WriteLine("\n\nBubble Sort:");
            OutputArray(arrayA);

            //Coctail Sort a >= b
            arrayA = CoctailSort(arrayA, 1);
            Console.WriteLine("\n\nCoctail Sort:");
            OutputArray(arrayA);

            //Insertion Sort a <= b
            arrayA = InsertionSort(arrayA);
            Console.WriteLine("\n\nInsertion Sort:");
            OutputArray(arrayA);

            //Stooge Sort a >= b
            arrayA = StoogeSort(arrayA, 0, value - 1, 1);
            Console.WriteLine("\n\nStooge Sort:");
            OutputArray(arrayA);

            Console.WriteLine("\n____________________________________________________\n\n*** Array B ***");
            OutputArray(arrayB);

            //Shell Sort a <= b
            arrayB = ShellSort(arrayB, 1);
            Console.WriteLine("\n\nShell Sort:");
            OutputArray(arrayB);

            //Merge Sort a >= b
            arrayB = MergeSort(arrayB);
            Console.WriteLine("\n\nMerge Sort:");
            OutputArray(arrayB);

            //Selection Sort a <= b
            arrayB = SelectionSort(arrayB, 1);
            Console.WriteLine("\n\nSelection Sort:");
            OutputArray(arrayB);

            //Quick Sort a >= b
            arrayB = QuickSort(arrayB, 0, arrayB.Length - 1);
            Console.WriteLine("\n\nQuick Sort:");
            OutputArray(arrayB);
        }
    }
}
