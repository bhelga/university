using System;

namespace Lab11_2
{
    class Program
    {
        static void OutputArray(long[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " | ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            VectorLong.ShowNum();
            var vector1 = new VectorLong();
            Console.WriteLine("First vect : ");
            vector1.GetElements();
            vector1++;
            Console.WriteLine("First vect after : ");
            vector1.GetElements();
            var vector2 = new VectorLong(4);
            Console.WriteLine("Second vect : ");
            vector2.GetElements();
            vector2.InputElements();
            Console.WriteLine("Second vect after : ");
            vector2.GetElements();
            var vector3 = new VectorLong(4, 5);
            Console.WriteLine("Third vect : ");
            vector3.GetElements();
            vector3.SetParam(2);
            Console.WriteLine("Third vect after : ");
            vector3.GetElements();

            Console.WriteLine("//////////////////////////////////////");
            vector1[0] = 5;
            Console.WriteLine(vector2[3]);
            Console.WriteLine("\nFirst vect : ");
            vector1.GetElements();


            var temp = vector3 ^ vector2;
            Console.WriteLine("Vect2 + Vect3 = ");
            OutputArray(temp);

            if (vector2 != vector3)
            {
                temp = vector2 + 5;
                OutputArray(temp);
            }

            VectorLong.ShowNum();
            Console.ReadKey();

        }
    }
}
