using System;

namespace Lab14_3
{
    public class LinkedList
    {
        public Node head;
        public Node tail;
        public int count;

        public class Node
        {
            public string data;
            public Node next;
            public int position;
            public Node(string d)
            {
                data = d;
                next = null;
            }
        }
        public void Add(string data)
        {
            Node node = new Node(data);

            if (head == null)
            {
                head = node;
                tail = node;
                tail.next = head;
            }
            else
            {
                node.next = head;
                tail.next = node;
                tail = node;
            }
            count++;
            node.position = count;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList team1 = new LinkedList();
            
            LinkedList team2 = new LinkedList();
            
            for (int i = 1; i < 11; i++)
            {
                team1.Add($"Player {i}");
                team2.Add($"Player {i}");
            }
            var head1 = team1.head;
            var head2 = team2.head;
            var rand = new Random();
            int count = 10;
            int m = rand.Next(1, 10);
            int n = rand.Next(1, 10);
            //int m = 7;
           // int n = 2;
            if (m%2 == 0 && n%2 == 0)
            {
                count = 5;
            }
            string schedule = String.Format("NUMBER OF GAME | FIRST TEAM | SECOND TEAM\n");
            int num1 = 0;
            int num2 = 0;
            for (int i = 0; i < count; i++)
            {
                //num1 += m;
                //num2 += n;
                //if (num1 > 10) num1 -= 10;
                //if (num2 > 10) num2 -= 10;
                //while (head1.position != num1)
                //{
                //    head1 = head1.next;
                //}
                //while (head2.position != num2)
                //{
                //    head2 = head2.next;
                //}
                for (int j = 0; j < m; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }
                    head1 = head1.next;
                }
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }
                    head2 = head2.next;
                }
                schedule += String.Format("{0,15}| {1,-10} | {2,-10}", i + 1, head1.data, head2.data);
                schedule += "\n";
            }
            Console.WriteLine(m + " | " + n + "\n" + schedule);
            Console.ReadKey();
        }
    }
}
