using System;
using System.Collections.Generic;
using System.Text;

namespace Lab11_2
{
    class VectorLong
    {
        private long[] longArray;
        private uint size { get; }
        private int codeError { get; set; }
        private static uint num_vec = 0;
        public VectorLong()
        {
            this.size = 1;
            this.longArray = new long[] { 0 };
            Counter();
        }
        public VectorLong(uint size)
        {
            this.size = size;
            longArray = new long[size];
            for (var i = 0; i < size; i++)
            {
                longArray[i] = 0;
            }
            Counter();
        }
        public VectorLong(uint size, long item)
        {
            this.size = size;
            longArray = new long[size];
            for (var i = 0; i < size; i++)
            {
                longArray[i] = item;
            }
            Counter();
        }
        ~VectorLong()
        {
            Console.Beep();
            Console.WriteLine("m Disposed");
        }
        public static void Counter()
        {
            num_vec++;
        }
        public static void ShowNum()
        {
            Console.WriteLine("Num vec : " + num_vec);
        }
        public void InputElements()
        {
            for (var i = 0; i < this.size; i++)
            {
                Console.Write("Input element : ");
                this.longArray[i] = long.Parse(Console.ReadLine());
            }
        }
        public void GetElements()
        {
            for (var i = 0; i < this.size; i++)
            {
                Console.Write(this.longArray[i] + " | ");
            }
            Console.WriteLine();
        }
        public void SetParam(long param)
        {
            for (var i = 0; i < this.size; i++)
            {
                this.longArray[i] = param;
            }
        }
        public long? this[uint index]
        {
            get
            {
                if (index < size)
                {
                    codeError = 0;
                    return longArray[index];
                }
                else
                {
                    codeError = -1;
                    return null;
                }
            }
            set
            {
                if (index < size)
                {
                    //codeError = (int)value;
                    codeError = 0;
                    longArray[index] = (long)value;
                }
                else
                {
                    codeError = -1;
                }
            }
        }
        public static VectorLong operator ++(VectorLong vectorLong)
        {
            for (var i = 0; i < vectorLong.size; i++)
            {
                vectorLong.longArray[i]++;
            }
            return vectorLong;
        }

        public static VectorLong operator --(VectorLong vectorLong)
        {
            for (var i = 0; i < vectorLong.size; i++)
            {
                vectorLong.longArray[i]--;
            }
            return vectorLong;
        }

        public static bool operator true(VectorLong vectorLong)
        {
            bool flag = vectorLong.size != 0;
            for (var i = 0; i < vectorLong.size; i++)
            {
                if (vectorLong.longArray[i] == 0)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        public static bool operator false(VectorLong vectorLong)
        {
            bool flag = vectorLong.size == 0;
            for (var i = 0; i < vectorLong.size; i++)
            {
                if (vectorLong.longArray[i] != 0)
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        public static bool operator !(VectorLong vectorLong)
        {
            return vectorLong.size != 0;
        }

        public static VectorLong operator ~(VectorLong vectorLong)
        {
            for (var i = 0; i < vectorLong.size; i++)
            {
                vectorLong.longArray[i] = ~vectorLong.longArray[i];
            }
            return vectorLong;
        }

        public static long[]? operator +(VectorLong vectorLong1, VectorLong vectorLong2)
        {
            if (vectorLong1.size == vectorLong2.size)
            {
                for (var i = 0; i < vectorLong1.size; i++)
                {
                    vectorLong1.longArray[i] += vectorLong2.longArray[i];
                }
                return vectorLong1.longArray;
            }
            else
            {
                Console.WriteLine("\nCan't do this operation!");
                return null;
            }
        }
        public static long[] operator +(VectorLong vectorLong1, long param)
        {
            for (var i = 0; i < vectorLong1.size; i++)
            {
                vectorLong1.longArray[i] += param;
            }
            return vectorLong1.longArray;
        }
        public static long[]? operator -(VectorLong vectorLong1, VectorLong vectorLong2)
        {
            if (vectorLong1.size == vectorLong2.size)
            {
                for (var i = 0; i < vectorLong1.size; i++)
                {
                    vectorLong1.longArray[i] -= vectorLong2.longArray[i];
                }
                return vectorLong1.longArray;
            }
            else
            {
                Console.WriteLine("\nCan't do this operation!");
                return null;
            }
        }
        public static long[] operator -(VectorLong vectorLong1, long param)
        {
            for (var i = 0; i < vectorLong1.size; i++)
            {
                vectorLong1.longArray[i] -= param;
            }
            return vectorLong1.longArray;
        }
        public static long[]? operator *(VectorLong vectorLong1, VectorLong vectorLong2)
        {
            if (vectorLong1.size == vectorLong2.size)
            {
                for (var i = 0; i < vectorLong1.size; i++)
                {
                    vectorLong1.longArray[i] *= vectorLong2.longArray[i];
                }
                return vectorLong1.longArray;
            }
            else
            {
                Console.WriteLine("\nCan't do this operation!");
                return null;
            }
        }
        public static long[] operator *(VectorLong vectorLong1, long param)
        {
            for (var i = 0; i < vectorLong1.size; i++)
            {
                vectorLong1.longArray[i] *= param;
            }
            return vectorLong1.longArray;
        }
        public static long[]? operator /(VectorLong vectorLong1, VectorLong vectorLong2)
        {
            if (vectorLong1.size == vectorLong2.size)
            {
                for (var i = 0; i < vectorLong1.size; i++)
                {
                    vectorLong1.longArray[i] /= vectorLong2.longArray[i];
                }
                return vectorLong1.longArray;
            }
            else
            {
                Console.WriteLine("\nCan't do this operation!");
                return null;
            }
        }
        public static long[] operator /(VectorLong vectorLong1, long param)
        {
            for (var i = 0; i < vectorLong1.size; i++)
            {
                vectorLong1.longArray[i] /= param;
            }
            return vectorLong1.longArray;
        }
        public static long[]? operator %(VectorLong vectorLong1, VectorLong vectorLong2)
        {
            if (vectorLong1.size == vectorLong2.size)
            {
                for (var i = 0; i < vectorLong1.size; i++)
                {
                    vectorLong1.longArray[i] %= vectorLong2.longArray[i];
                }
                return vectorLong1.longArray;
            }
            else
            {
                Console.WriteLine("\nCan't do this operation!");
                return null;
            }
        }
        public static long[] operator %(VectorLong vectorLong1, long param)
        {
            for (var i = 0; i < vectorLong1.size; i++)
            {
                vectorLong1.longArray[i] %= param;
            }
            return vectorLong1.longArray;
        }
        public static long[]? operator |(VectorLong vectorLong1, VectorLong vectorLong2)
        {
            if (vectorLong1.size == vectorLong2.size)
            {
                for (var i = 0; i < vectorLong1.size; i++)
                {
                    vectorLong1.longArray[i] |= vectorLong2.longArray[i];
                }
                return vectorLong1.longArray;
            }
            else
            {
                Console.WriteLine("\nCan't do this operation!");
                return null;
            }
        }
        public static long[] operator |(VectorLong vectorLong1, long param)
        {
            for (var i = 0; i < vectorLong1.size; i++)
            {
                vectorLong1.longArray[i] |= param;
            }
            return vectorLong1.longArray;
        }
        public static long[]? operator &(VectorLong vectorLong1, VectorLong vectorLong2)
        {
            if (vectorLong1.size == vectorLong2.size)
            {
                for (var i = 0; i < vectorLong1.size; i++)
                {
                    vectorLong1.longArray[i] &= vectorLong2.longArray[i];
                }
                return vectorLong1.longArray;
            }
            else
            {
                Console.WriteLine("\nCan't do this operation!");
                return null;
            }
        }
        public static long[] operator &(VectorLong vectorLong1, long param)
        {
            for (var i = 0; i < vectorLong1.size; i++)
            {
                vectorLong1.longArray[i] &= param;
            }
            return vectorLong1.longArray;
        }
        public static long[]? operator ^(VectorLong vectorLong1, VectorLong vectorLong2)
        {
            if (vectorLong1.size == vectorLong2.size)
            {
                for (var i = 0; i < vectorLong1.size; i++)
                {
                    vectorLong1.longArray[i] ^= vectorLong2.longArray[i];
                }
                return vectorLong1.longArray;
            }
            else
            {
                Console.WriteLine("\nCan't do this operation!");
                return null;
            }
        }
        public static long[] operator ^(VectorLong vectorLong1, long param)
        {
            for (var i = 0; i < vectorLong1.size; i++)
            {
                vectorLong1.longArray[i] ^= param;
            }
            return vectorLong1.longArray;
        }
        //public static long[]? operator <<(VectorLong vectorLong1, VectorLong vectorLong2)
        //{
        //    if (vectorLong1.size == vectorLong2.size)
        //    {
        //        for (var i = 0; i < vectorLong1.size; i++)
        //        {
        //            vectorLong1.longArray[i] = (int)vectorLong1.longArray[i] << (int)vectorLong2.longArray[i];
        //        }
        //        return vectorLong1.longArray;
        //    }
        //    else
        //    {
        //        Console.WriteLine("\nCan't do this operation!");
        //        return null;
        //    }
        //}
        //public static long[]? operator >>(VectorLong vectorLong1, VectorLong vectorLong2)
        //{
        //    if (vectorLong1.size == vectorLong2.size)
        //    {
        //        for (var i = 0; i < vectorLong1.size; i++)
        //        {
        //            vectorLong1.longArray[i] = (int)vectorLong1.longArray[i] >> (int)vectorLong2.longArray[i];
        //        }
        //        return vectorLong1.longArray;
        //    }
        //    else
        //    {
        //        Console.WriteLine("\nCan't do this operation!");
        //        return null;
        //    }
        //}
        public static long[] operator <<(VectorLong vectorLong1, int param)
        {
            for (var i = 0; i < vectorLong1.size; i++)
            {
                vectorLong1.longArray[i] = (int)vectorLong1.longArray[i] << param;
            }
            return vectorLong1.longArray;
        }
        public static long[] operator >>(VectorLong vectorLong1, int param)
        {
            for (var i = 0; i < vectorLong1.size; i++)
            {
                vectorLong1.longArray[i] = (int)vectorLong1.longArray[i] >> param;
            }
            return vectorLong1.longArray;
        }

        public static bool operator ==(VectorLong vectorLong1, VectorLong vectorLong2)
        {
            var flag = true;
            if (vectorLong1.size == vectorLong2.size)
            {
                for (var i = 0; i < vectorLong1.size; i++)
                {
                    if(vectorLong1.longArray[i] != vectorLong2.longArray[i])
                    {
                        flag = false;
                        break;
                    }
                }
            }
            else
            {
                flag = false;
            }
            return flag;
        }
        public static bool operator !=(VectorLong vectorLong1, VectorLong vectorLong2)
        {
            var flag = true;
            int counter = 0;
            if (vectorLong1.size == vectorLong2.size)
            {
                for (var i = 0; i < vectorLong1.size; i++)
                {
                    if (vectorLong1.longArray[i] != vectorLong2.longArray[i])
                    {
                        counter++;
                    }
                }
                if (counter == vectorLong1.size) flag = false;
            }
            else
            {
                flag = true;
            }
            return flag;
        }
        public static bool operator >(VectorLong vectorLong1, VectorLong vectorLong2)
        {
            var flag = true;
            if (vectorLong1.size == vectorLong2.size)
            {
                for (var i = 0; i < vectorLong1.size; i++)
                {
                    if (vectorLong1.longArray[i] <= vectorLong2.longArray[i])
                    {
                        flag = false;
                        break;
                    }
                }
            }
            else
            {
                flag = false;
            }
            return flag;
        }
        public static bool operator >=(VectorLong vectorLong1, VectorLong vectorLong2)
        {
            var flag = true;
            if (vectorLong1.size == vectorLong2.size)
            {
                for (var i = 0; i < vectorLong1.size; i++)
                {
                    if (vectorLong1.longArray[i] < vectorLong2.longArray[i])
                    {
                        flag = false;
                        break;
                    }
                }
            }
            else
            {
                flag = false;
            }
            return flag;
        }
        public static bool operator <(VectorLong vectorLong1, VectorLong vectorLong2)
        {
            var flag = true;
            if (vectorLong1.size == vectorLong2.size)
            {
                for (var i = 0; i < vectorLong1.size; i++)
                {
                    if (vectorLong1.longArray[i] >= vectorLong2.longArray[i])
                    {
                        flag = false;
                        break;
                    }
                }
            }
            else
            {
                flag = false;
            }
            return flag;
        }
        public static bool operator <=(VectorLong vectorLong1, VectorLong vectorLong2)
        {
            var flag = true;
            if (vectorLong1.size == vectorLong2.size)
            {
                for (var i = 0; i < vectorLong1.size; i++)
                {
                    if (vectorLong1.longArray[i] > vectorLong2.longArray[i])
                    {
                        flag = false;
                        break;
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
