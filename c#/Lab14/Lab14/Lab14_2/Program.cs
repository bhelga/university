using System;
//using System.Collections.Generic;
using System.IO;

namespace Lab14_2
{
    public class LinkedList
    {
        public Node head;
        public Node tail;
        public int count;

        public class Node
        {
            public int data;
            public Node next;
            public int position;
            public Node(int d)
            {
                data = d;
                next = null;
            }
        }

        public void Add(int data)
        {
            Node node = new Node(data);

            if (head == null)
                head = node;
            else
                tail.next = node;
            tail = node;
            node.position = count;
            count++;
        }

        public Node ReverseList(Node head)
        {
            if (head == null || head.next == null) return head;

            Node prev = null, current = head, next = null;
            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            return prev;
        }

        public Node reverse(Node head, int m, int n)
        {
            Node prev = null;
            Node curr = head;

            for (int i = 0; curr != null && i < m; i++)
            {
                prev = curr;
                curr = curr.next;
            }

            Node start = curr;
            Node end = null;

            for (int i = 1; curr != null && i <= n - m + 1; i++)
            {
                Node next = curr.next;

                curr.next = end;
                end = curr;

                curr = next;
            }
            start.next = curr;
            if (prev != null)
            {
                prev.next = end;
            }
            else
            {
                head = end;
            }

            return head;
        }

        //public Node Reverse(Node head, int n, int k)
        //{
        //    if (n == k) return head;
        //    int count = 1;
        //    Node curr = head;
        //    Node revPrev = null;
        //    while (count < n)
        //    {
        //        revPrev = curr;
        //        curr = curr.next;
        //        count++;
        //    }
        //    Node revStart = curr;
        //    while (count < k)
        //    {
        //        curr = curr.next;
        //        count++;
        //    }
        //    Node revEnd = curr;
        //    Node revNext = curr.next;
        //    curr.next = null;
        //    Node revPart = ReverseList(revStart);
        //    if (revPrev != null)
        //    {
        //        revPrev.next.next = revNext;
        //        revPrev.next = revPart;
        //    }
        //    else
        //    {
        //        if (revNext != null)
        //        {
        //            head.next = revNext;
        //        }
        //    }
        //    return head;
        //}

        public void ShowList()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }
            Console.WriteLine();
        }

        public int FindMin(int data)
        {
            int minIndex = count;
            Node current = head;
            while (current != null)
            {
                if (current.data.Equals(data) && current.position < minIndex)
                    return current.position;
                current = current.next;
            }
            return -1;
        }
        public int FindMax(int data)
        {
            int maxIndex = 0;
            Node current = head;
            int result = -1;
            while (current != null)
            {
                if (current.data.Equals(data) && current.position > maxIndex)
                    result = current.position;
                current = current.next;
            }
            return result;
        }
        
    }

    class Program
    {
        static int CorrectIntInput(string str)
        {
            int point = 0;
            while (true)
            {
                Console.Write(str);
                if (!int.TryParse(Console.ReadLine(), out point))  // пробує перетворити строку в int, вертає true, якщо це можливо i записує данi в point
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
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            FileStream file = new FileStream("D:\\helga\\university\\programming\\university\\c#\\Lab14\\list.txt", FileMode.Open);
            StreamReader readFile = new StreamReader(file);
            while (!readFile.EndOfStream)
            {
                list.Add(int.Parse(readFile.ReadLine()));
            }
            readFile.Close();
            list.ShowList();
            int element = CorrectIntInput("Enter your element : ");
            int minIndex = list.FindMin(element);
            int maxIndex = list.FindMax(element);
            list.head = list.reverse(list.head, minIndex, maxIndex);
            Console.WriteLine(minIndex + " | " + maxIndex); 
            Console.WriteLine("Reversed :");
            list.ShowList();
            string listStr = "";
            var node = list.head;
            for (int i = 1; i <= list.count; i++)
            {
                listStr += node.data.ToString() + " ";
                if (i % 6 == 0)
                {
                    listStr += "\n";
                }
                node = node.next;
            }
            var path = "D:\\helga\\university\\programming\\university\\c#\\Lab14\\new_list.txt";
            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(listStr);
                fstream.Write(array, 0, array.Length);
            }
        }
    }
}
