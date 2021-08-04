using System;
using System.Collections.Generic;
using System.Text;

namespace Lab11_3
{
    
    class MatrixLong
    {
        static long CorrectInput(string str)
        {
            long point = 0;
            while (true)
            {
                Console.Write(str);
                if (!long.TryParse(Console.ReadLine(), out point))  // пробує перетворити строку в int, вертає true, якщо це можливо і записує дані в point
                {
                    Console.WriteLine("Value error!");
                }
                else
                {
                    break;
                }
            }
            return point;
        }

        private long[,] LongArray;
        private uint n { get; }
        private uint m { get; }
        private int codeError { get; set; }
        static int num_m;
        public MatrixLong()
        {
            this.m = this.n = 1;
            this.LongArray = new long[,] { { 0 } };
            Counter();
        }
        public MatrixLong(uint n, uint m)
        {
            this.n = n;
            this.m = m;
            LongArray = new long[n,m];
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    LongArray[i,j] = 0;
                }
            }
            Counter();
        }
        public MatrixLong(uint n, uint m, long item)
        {
            this.n = n;
            this.m = m;
            LongArray = new long[n, m];
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    LongArray[i, j] = item;
                }
            }
            Counter();
        }
        ~MatrixLong()
        {
            Console.Beep();
            Console.WriteLine("m Disposed");
        }
        public static void Counter()
        {
            num_m++;
        }
        public static void ShowNum()
        {
            Console.WriteLine("Num vec : " + num_m);
        }
        public void InputElements()
        {
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    this.LongArray[i,j] = CorrectInput("Enter your element : ");
                }
            }
        }
        public void GetElements()
        {
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    Console.Write(this.LongArray[i,j] + " | ");
                }
                Console.WriteLine();
            }
        }
        public void SetParam(long param)
        {
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    this.LongArray[i, j] = param;
                }
            }
        }
        public long? this[uint n, uint m]
        {
            get
            {
                if (n < this.n && m < this.m)
                {
                    codeError = 0;
                    return LongArray[n, m];
                }
                else
                {
                    codeError = -1;
                    return null;
                }
            }
            set
            {
                if (n < this.n && m < this.m)
                {
                    codeError = (int)value;
                    //codeError = 0;
                    //LongArray[n, m] = (long)value;
                }
                else
                {
                    codeError = -1;
                }
            }
        }
        public long? this[uint k]
        {
            get
            {
                if (k < this.n * this.m)
                {
                    codeError = 0;
                    return LongArray[k / this.n, k % this.m];
                }
                else
                {
                    codeError = -1;
                    return null;
                }
            }
            set
            {
                if (k < this.n * this.m)
                {
                    codeError = (int)value;
                    //codeError = 0;
                    //LongArray[k / this.n, k % this.m] = (long)value;
                }
                else
                {
                    codeError = -1;
                }
            }
        }

        public static MatrixLong operator ++(MatrixLong matrixLong)
        {
            for (var i = 0; i < matrixLong.n; i++)
            {
                for (var j = 0; j < matrixLong.m; j++)
                {
                    matrixLong.LongArray[i, j]++;
                }
            }
            return matrixLong;
        }

        public static MatrixLong operator --(MatrixLong matrixLong)
        {
            for (var i = 0; i < matrixLong.n; i++)
            {
                for (var j = 0; j < matrixLong.m; j++)
                {
                    matrixLong.LongArray[i, j]--;
                }
            }
            return matrixLong;
        }

        public static bool operator true(MatrixLong matrixLong)
        {
            bool flag = matrixLong.m * matrixLong.n != 0;
            for (var i = 0; i < matrixLong.n; i++)
            {
                for (var j = 0; j < matrixLong.m; j++)
                {
                    if (matrixLong.LongArray[i, j] == 0)
                    {
                        flag = false;
                        break;
                    }
                }
            }
            return flag;
        }

        public static bool operator false(MatrixLong matrixLong)
        {
            bool flag = matrixLong.m * matrixLong.n == 0;
            for (var i = 0; i < matrixLong.n; i++)
            {
                for (var j = 0; j < matrixLong.m; j++)
                {
                    if (matrixLong.LongArray[i, j] != 0)
                    {
                        flag = false;
                        break;
                    }
                }
            }
            return flag;
        }

        public static bool operator !(MatrixLong matrixLong)
        {
            return matrixLong.m * matrixLong.n != 0;
        }

        public static MatrixLong operator ~(MatrixLong matrixLong)
        {
            for (var i = 0; i < matrixLong.n; i++)
            {
                for (var j = 0; j < matrixLong.m; j++)
                {
                    matrixLong.LongArray[i, j] = ~matrixLong.LongArray[i, j];
                }
            }
            return matrixLong;
        }
        public static long[,]? operator +(MatrixLong matrixLong1, MatrixLong matrixLong2)
        {
            if (matrixLong1.n == matrixLong2.n && matrixLong1.m == matrixLong2.m)
            {
                for (var i = 0; i < matrixLong1.n; i++)
                {
                    for (var j = 0; j < matrixLong1.m; j++)
                    {
                        matrixLong1.LongArray[i, j] += matrixLong2.LongArray[i, j];
                    }
                }
                return matrixLong1.LongArray;
            }
            else
            {
                Console.WriteLine("\nCan't do this operation!");
                return null;
            }
        }
        public static long[,]? operator -(MatrixLong matrixLong1, MatrixLong matrixLong2)
        {
            if (matrixLong1.n == matrixLong2.n && matrixLong1.m == matrixLong2.m)
            {
                for (var i = 0; i < matrixLong1.n; i++)
                {
                    for (var j = 0; j < matrixLong1.m; j++)
                    {
                        matrixLong1.LongArray[i, j] -= matrixLong2.LongArray[i, j];
                    }
                }
                return matrixLong1.LongArray;
            }
            else
            {
                Console.WriteLine("\nCan't do this operation!");
                return null;
            }
        }
        public static long[,]? operator *(MatrixLong matrixLong1, MatrixLong matrixLong2)
        {
            var res = new long[matrixLong1.n, matrixLong2.m];
            if (matrixLong1.m == matrixLong2.n)
            {
                for (var i = 0; i < matrixLong1.n; i++)
                {
                    for (var j = 0; j < matrixLong2.m; j++)
                    {
                        res[i, j] = 0;
                        for (var k = 0; k < matrixLong1.m; k++)
                        {
                            res[i, j] += matrixLong1.LongArray[i, k] * matrixLong2.LongArray[k, j];
                        }
                    }
                }
                return res;
            }
            else
            {
                Console.WriteLine("\nCan't do this operation!");
                return null;
            }
        }
        public static long[,]? operator /(MatrixLong matrixLong1, MatrixLong matrixLong2)
        {
            var res = new long[matrixLong1.n, matrixLong2.m];
            if (matrixLong1.n == matrixLong2.m)
            {
                for (var i = 0; i < matrixLong1.n; i++)
                {
                    for (var j = 0; j < matrixLong2.m; j++)
                    {
                        res[i, j] = 0;
                        for (var k = 0; k < matrixLong1.m; k++)
                        {
                            res[i, j] += matrixLong1.LongArray[i, k] / matrixLong2.LongArray[k, j];
                        }
                    }
                }
                return res;
            }
            else
            {
                Console.WriteLine("\nCan't do this operation!");
                return null;
            }
        }
        public static long[,]? operator %(MatrixLong matrixLong1, MatrixLong matrixLong2)
        {
            var res = new long[matrixLong1.n, matrixLong2.m];
            if (matrixLong1.n == matrixLong2.m)
            {
                for (var i = 0; i < matrixLong1.n; i++)
                {
                    for (var j = 0; j < matrixLong2.m; j++)
                    {
                        res[i, j] = 0;
                        for (var k = 0; k < matrixLong1.m; k++)
                        {
                            res[i, j] += matrixLong1.LongArray[i, k] % matrixLong2.LongArray[k, j];
                        }
                    }
                }
                return res;
            }
            else
            {
                Console.WriteLine("\nCan't do this operation!");
                return null;
            }
        }
        public static long[,] operator +(MatrixLong matrixLong, long param)
        {
            for (var i = 0; i < matrixLong.n; i++)
            {
                for (var j = 0; j < matrixLong.m; j++)
                {
                    matrixLong.LongArray[i, j] += param;
                }
            }
            return matrixLong.LongArray;
        }
        public static long[,] operator -(MatrixLong matrixLong, long param)
        {
            for (var i = 0; i < matrixLong.n; i++)
            {
                for (var j = 0; j < matrixLong.m; j++)
                {
                    matrixLong.LongArray[i, j] -= param;
                }
            }
            return matrixLong.LongArray;
        }
        public static long[,] operator *(MatrixLong matrixLong, long param)
        {
            for (var i = 0; i < matrixLong.n; i++)
            {
                for (var j = 0; j < matrixLong.m; j++)
                {
                    matrixLong.LongArray[i, j] *= param;
                }
            }
            return matrixLong.LongArray;
        }
        public static long[,] operator /(MatrixLong matrixLong, long param)
        {
            for (var i = 0; i < matrixLong.n; i++)
            {
                for (var j = 0; j < matrixLong.m; j++)
                {
                    matrixLong.LongArray[i, j] /= param;
                }
            }
            return matrixLong.LongArray;
        }
        public static long[,] operator %(MatrixLong matrixLong, long param)
        {
            for (var i = 0; i < matrixLong.n; i++)
            {
                for (var j = 0; j < matrixLong.m; j++)
                {
                    matrixLong.LongArray[i, j] %= param;
                }
            }
            return matrixLong.LongArray;
        }
        public static long[,]? operator &(MatrixLong matrixLong1, MatrixLong matrixLong2)
        {
            var res = new long[matrixLong1.n, matrixLong2.m];
            if (matrixLong1.n == matrixLong2.m)
            {
                for (var i = 0; i < matrixLong1.n; i++)
                {
                    for (var j = 0; j < matrixLong2.m; j++)
                    {
                        res[i, j] = 0;
                        for (var k = 0; k < matrixLong1.m; k++)
                        {
                            res[i, j] += matrixLong1.LongArray[i, k] & matrixLong2.LongArray[k, j];
                        }
                    }
                }
                return res;
            }
            else
            {
                Console.WriteLine("\nCan't do this operation!");
                return null;
            }
        }
        public static long[,]? operator |(MatrixLong matrixLong1, MatrixLong matrixLong2)
        {
            if (matrixLong1.n == matrixLong2.n && matrixLong1.m == matrixLong2.m)
            {
                for (var i = 0; i < matrixLong1.n; i++)
                {
                    for (var j = 0; j < matrixLong1.m; j++)
                    {
                        matrixLong1.LongArray[i, j] |= matrixLong2.LongArray[i, j];
                    }
                }
                return matrixLong1.LongArray;
            }
            else
            {
                Console.WriteLine("\nCan't do this operation!");
                return null;
            }
        }
        public static long[,]? operator ^(MatrixLong matrixLong1, MatrixLong matrixLong2)
        {
            if (matrixLong1.n == matrixLong2.n && matrixLong1.m == matrixLong2.m)
            {
                for (var i = 0; i < matrixLong1.n; i++)
                {
                    for (var j = 0; j < matrixLong1.m; j++)
                    {
                        matrixLong1.LongArray[i, j] ^= matrixLong2.LongArray[i, j];
                    }
                }
                return matrixLong1.LongArray;
            }
            else
            {
                Console.WriteLine("\nCan't do this operation!");
                return null;
            }
        }
        public static long[,] operator |(MatrixLong matrixLong, long param)
        {
            for (var i = 0; i < matrixLong.n; i++)
            {
                for (var j = 0; j < matrixLong.m; j++)
                {
                    matrixLong.LongArray[i, j] |= param;
                }
            }
            return matrixLong.LongArray;
        }
        public static long[,] operator &(MatrixLong matrixLong, long param)
        {
            for (var i = 0; i < matrixLong.n; i++)
            {
                for (var j = 0; j < matrixLong.m; j++)
                {
                    matrixLong.LongArray[i, j] &= param;
                }
            }
            return matrixLong.LongArray;
        }
        public static long[,] operator ^(MatrixLong matrixLong, long param)
        {
            for (var i = 0; i < matrixLong.n; i++)
            {
                for (var j = 0; j < matrixLong.m; j++)
                {
                    matrixLong.LongArray[i, j] ^= param;
                }
            }
            return matrixLong.LongArray;
        }
        public static long[,] operator >>(MatrixLong matrixLong, int param)
        {
            for (var i = 0; i < matrixLong.n; i++)
            {
                for (var j = 0; j < matrixLong.m; j++)
                {
                    matrixLong.LongArray[i, j] = (int)matrixLong.LongArray[i, j]  >> param;
                }
            }
            return matrixLong.LongArray;
        }
        public static long[,] operator <<(MatrixLong matrixLong, int param)
        {
            for (var i = 0; i < matrixLong.n; i++)
            {
                for (var j = 0; j < matrixLong.m; j++)
                {
                    matrixLong.LongArray[i, j] = (int)matrixLong.LongArray[i, j] << param;
                }
            }
            return matrixLong.LongArray;
        }
        public static bool operator ==(MatrixLong matrixLong1, MatrixLong matrixLong2)
        {
            var flag = true;
            if (matrixLong1.n == matrixLong2.n && matrixLong1.m == matrixLong2.m)
            {
                for (var i = 0; i < matrixLong1.n; i++)
                {
                    for (var j = 0; j < matrixLong1.m; j++)
                    {
                        if (matrixLong1.LongArray[i, j] != matrixLong2.LongArray[i, j])
                        {
                            flag = false;
                            break;
                        }
                    }
                }
            }
            else
            {
                flag = false;
            }
            return flag;
        }
        public static bool operator !=(MatrixLong matrixLong1, MatrixLong matrixLong2)
        {
            var flag = true;
            if (matrixLong1.n == matrixLong2.n && matrixLong1.m == matrixLong2.m)
            {
                for (var i = 0; i < matrixLong1.n; i++)
                {
                    for (var j = 0; j < matrixLong1.m; j++)
                    {
                        if (matrixLong1.LongArray[i, j] == matrixLong2.LongArray[i, j])
                        {
                            flag = false;
                            break;
                        }
                    }
                }
            }
            else
            {
                flag = false;
            }
            return flag;
        }
        public static bool operator >(MatrixLong matrixLong1, MatrixLong matrixLong2)
        {
            var flag = true;
            if (matrixLong1.n == matrixLong2.n && matrixLong1.m == matrixLong2.m)
            {
                for (var i = 0; i < matrixLong1.n; i++)
                {
                    for (var j = 0; j < matrixLong1.m; j++)
                    {
                        if (matrixLong1.LongArray[i, j] <= matrixLong2.LongArray[i, j])
                        {
                            flag = false;
                            break;
                        }
                    }
                }
            }
            else
            {
                flag = false;
            }
            return flag;
        }
        public static bool operator <(MatrixLong matrixLong1, MatrixLong matrixLong2)
        {
            var flag = true;
            if (matrixLong1.n == matrixLong2.n && matrixLong1.m == matrixLong2.m)
            {
                for (var i = 0; i < matrixLong1.n; i++)
                {
                    for (var j = 0; j < matrixLong1.m; j++)
                    {
                        if (matrixLong1.LongArray[i, j] >= matrixLong2.LongArray[i, j])
                        {
                            flag = false;
                            break;
                        }
                    }
                }
            }
            else
            {
                flag = false;
            }
            return flag;
        }
        public static bool operator <=(MatrixLong matrixLong1, MatrixLong matrixLong2)
        {
            var flag = true;
            if (matrixLong1.n == matrixLong2.n && matrixLong1.m == matrixLong2.m)
            {
                for (var i = 0; i < matrixLong1.n; i++)
                {
                    for (var j = 0; j < matrixLong1.m; j++)
                    {
                        if (matrixLong1.LongArray[i, j] > matrixLong2.LongArray[i, j])
                        {
                            flag = false;
                            break;
                        }
                    }
                }
            }
            else
            {
                flag = false;
            }
            return flag;
        }
        public static bool operator >=(MatrixLong matrixLong1, MatrixLong matrixLong2)
        {
            var flag = true;
            if (matrixLong1.n == matrixLong2.n && matrixLong1.m == matrixLong2.m)
            {
                for (var i = 0; i < matrixLong1.n; i++)
                {
                    for (var j = 0; j < matrixLong1.m; j++)
                    {
                        if (matrixLong1.LongArray[i, j] < matrixLong2.LongArray[i, j])
                        {
                            flag = false;
                            break;
                        }
                    }
                }
            }
            else
            {
                flag = false;
            }
            return flag;
        }
    }
}
