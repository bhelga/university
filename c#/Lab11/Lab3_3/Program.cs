using System;

namespace Lab11_3
{
    class Program
    {
        static void OutputArray(long[,] array)
        {
            for (var i = 0; i < array.GetUpperBound(0) + 1; i++)
            {
                for (var j = 0; j < (array.Length / (array.GetUpperBound(0) + 1)); j++)
                    Console.Write(array[i, j] + " | ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            MatrixLong.ShowNum();
            var vector1 = new MatrixLong();
            Console.WriteLine("First vect : ");
            vector1.GetElements();
            vector1++;
            Console.WriteLine("First vect after : ");
            vector1.GetElements();
            var vector2 = new MatrixLong(2, 2);
            Console.WriteLine("Second vect : ");
            vector2.GetElements();
            vector2.InputElements();
            Console.WriteLine("Second vect after : ");
            vector2.GetElements();
            var vector3 = new MatrixLong(2, 2, 5);
            Console.WriteLine("Third vect : ");
            vector3.GetElements();
            vector3.SetParam(7);
            Console.WriteLine("Third vect after : ");
            vector3.GetElements();

            Console.WriteLine("//////////////////////////////////////");
            vector1[0] = 5;
            Console.WriteLine(vector2[3]);
            Console.WriteLine("\nFirst vect : ");
            vector1.GetElements();


            var temp = vector3 + vector2;
            Console.WriteLine("Vect2 + Vect3 = ");
            OutputArray(temp);

            if (vector2 != vector3)
            {
                temp = vector2 + 5;
                OutputArray(temp);
            }

            var vector4 = new MatrixLong(2, 4, 1);
            Console.WriteLine("\nFourth vect : ");
            vector4.GetElements();
            Console.WriteLine("Third vect after : ");
            vector3.GetElements();
            temp = vector3 * vector4;
            Console.WriteLine("\nVect3 * Vect4 = ");
            OutputArray(temp);

            MatrixLong.ShowNum();
            Console.ReadKey();

        }
    }
}
