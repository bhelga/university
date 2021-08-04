using System;
using System.Collections.Generic;
using System.Text;

namespace Lab15_1
{
    class Stack<T>
    {
        private T[] items; 
        private int count;  
        const int n = 10;   // кількість елементів за замовчуванням
        
        public Stack()
        {
            items = new T[n];
        }
        
        public Stack(int length)
        {
            items = new T[length];
        }

        public bool IsEmpty { get { return count == 0; } }

        public int Count { get { return count; } }
        
        public void Push(T item)
        {
            // якщо стек заповнений, розширюємо
            if (count == items.Length)
                Resize(items.Length + 10);
            items[count++] = item;
        }
        
        public T Pop()
        {
            // якщо стек пустий, кидаємо помилку
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");

            T item = items[--count];
            items[count] = default(T); // сбрасываем ссылку

            if (count > 0 && count < items.Length - 10)
                Resize(items.Length - 10);

            return item;
        }
        // вертаємо елемент з верхушки пам'яті
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");
            return items[count - 1];
        }

        private void Resize(int max)
        {
            T[] tempItems = new T[max];
            for (int i = 0; i < count; i++)
                tempItems[i] = items[i];
            items = tempItems;
        }
    }
}
