using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab15_2
{
    class Deque<T> : IEnumerable<T>
    {
        /*  	push_front – додати (покласти) новий елемент на початок деку;
            	push_back – додати (покласти) новий елемент в кінець деку;
            	pop_front – видалити з деку перший елемент;
            	pop_back – видалити з деку останній елемент;
            	front – повернути значення першого елемента (не видаляючи його);
            	back – повернути значення останнього елемента (не видаляючи його);
            	size – дізнатися кількість елементів у деку;
            	clear – очистити дек (видалити з нього всі елементи).
        */
        class DoublyNode<T>
        {
            public DoublyNode(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public DoublyNode<T> Previous { get; set; }
            public DoublyNode<T> Next { get; set; }
        }
        DoublyNode<T> head; // перший елемент
        DoublyNode<T> tail; // останній елемент
        int count;          // кількість елементів

        
        public void PushBack(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }
        public void PushFront(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            DoublyNode<T> temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previous = node;
            count++;
        }
        public T PopFront()
        {
            if (count == 0)
                throw new InvalidOperationException("Deque is empty!");
            T output = head.Data;
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                head = head.Next;
                head.Previous = null;
            }
            count--;
            return output;
        }
        public T PopBack()
        {
            if (count == 0)
                throw new InvalidOperationException("Deque is empty!");
            T output = tail.Data;
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                tail = tail.Previous;
                tail.Next = null;
            }
            count--;
            return output;
        }
        public T PeekFront
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Deque is empty!");
                return head.Data;
            }
        }
        public T PeekBack
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Deque is empty!");
                return tail.Data;
            }
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            if (count == 0)
                throw new InvalidOperationException("Deque is empty!");
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
