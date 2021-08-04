using System;

namespace Lab15_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Deque<int> deque = new Deque<int>();
            int size = 10;
            for (var i = 0; i < size/2; i++)
            {
                deque.PushBack(i);
                deque.PushFront(i + size);
            }
            Console.WriteLine("Our deque :");
            foreach (var i in deque)
            {
                Console.Write(i + " | ");
            }
            Console.WriteLine($"\n\nDeque front : {deque.PeekFront}\nDeque back : {deque.PeekBack}");
            for (var i = 0; i < size / 2; i++)
            {
                Console.WriteLine("\n\nPop back :");
                deque.PopBack();
                foreach (var j in deque)
                {
                    Console.Write(j + " | ");
                }
                Console.WriteLine("\nPop front :");
                deque.PopFront();
                foreach (var j in deque)
                {
                    Console.Write(j + " | ");
                }
            }
            try
            {
                deque.PopBack();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("\nDeque is empty!");
            }
            deque.PushBack(100);
            deque.PushFront(99);
            Console.WriteLine("\n\nDeque to clear : ");
            foreach (var i in deque)
            {
                Console.Write(i + " | ");
            }
            Console.WriteLine($"\n\nDeque count : {deque.Count}\n\nDeleting...");
            deque.Clear();
            Console.WriteLine($"\n\nDeque count : {deque.Count}");
        }
    }
}
