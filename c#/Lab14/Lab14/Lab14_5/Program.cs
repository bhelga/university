using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace Lab14_5
{

    class Program
    {
        [Serializable]
        public struct Train
        {
            public string Name { get; set; }
            public int Number { get; set; }
            public DateTime Date { get; set; }
            static string format = "dd/MM/yyyy hh:mm tt";
            static CultureInfo provider = CultureInfo.InvariantCulture;

            public Train(string name, int number, string date, string time)
            {
                Name = name;
                Number = number;
                string data = $@"{date} {time}";
                Date = DateTime.ParseExact(data, format, provider);
            }
            public void GetInfo()
            {
                Console.WriteLine($"TRAIN {this.Name.ToUpper()}\n\nNumber of train : {this.Number}\nDate : {this.Date:d}\nTime : {this.Date.TimeOfDay}\n");
            }
            public void InputInfo()
            {
                Console.Write("Input train name : ");
                this.Name = Console.ReadLine();
                this.Number = CorrectIntInput("Inout number of train : ");

                while (true)
                {
                    try
                    {
                        Console.WriteLine("Enter date in format \"dd/MM/yyyy\" : ");
                        string date = Console.ReadLine();
                        Console.WriteLine("Enter time in format \"hh:mm tt\" : ");
                        string time = Console.ReadLine();
                        string data = $@"{date} {time}";
                        this.Date = DateTime.ParseExact(data, format, provider);
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Your date is wrong!");
                    }
                }
            }

            //public int CompareTo(object obj)
            //{
            //    if (obj == null) return 1;

            //    if (obj is Train otherTrain)
            //        return this.Name.CompareTo(otherTrain.Name);
            //    else
            //        throw new ArgumentException("Object is not a Temperature");
            //}
        }
        public class LinkedList : IEnumerable
        {
            public Node head;
            public Node tail;
            public int count;

            public class Node
            {
                public Train data;
                public Node next;
                public int position;
                public Node(Train d)
                {
                    data = d;
                    next = null;
                }
            }
            public void Add(Train data)
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

            //видалення елемента
            public bool Remove(Train data)
            {
                Node current = head;
                Node previous = null;

                while (current != null)
                {
                    if (current.data.Equals(data))
                    {
                        // якщо вузол вкiнцi чи всерединi
                        if (previous != null)
                        {
                            // забираємо вузол current, тепер previous посилається не на current, а на current.Next 
                            previous.next = current.next;

                            // Якщо current.Next не встановлений, то вузол останнiй, змiнюємо tail
                            if (current.next == null)
                                tail = previous;
                        }
                        else
                        {
                            // якщо видаляється перший елемент, перевстановлюємо значення head
                            head = head.next;

                            // якщо пiсля видалення список пустий, то видаляємо i tail
                            if (head == null)
                                tail = null;
                        }
                        count--;
                        return true;
                    }

                    previous = current;
                    current = current.next;
                }
                return false;
            }
            //видалення елемента на позицiї
            public bool RemovePosition(int position)
            {
                Node current = head;
                Node previous = null;

                while (current != null)
                {
                    if (current.data.Number.Equals(position))
                    {
                        // якщо вузол вкiнцi чи всерединi
                        if (previous != null)
                        {
                            // забираємо вузол current, тепер previous посилається не на current, а на current.Next 
                            previous.next = current.next;

                            // Якщо current.Next не встановлений, то вузол останнiй, змiнюємо tail
                            if (current.next == null)
                                tail = previous;
                        }
                        else
                        {
                            // якщо видаляється перший елемент, перевстановлюємо значення head
                            head = head.next;

                            // якщо пiсля видалення список пустий, то видаляємо i tail
                            if (head == null)
                                tail = null;
                        }
                        count--;
                        return true;
                    }

                    previous = current;
                    current = current.next;
                }
                return false;
            }

            public void ShowList()
            {
                Node temp = head;
                while (temp != null)
                {
                    temp.data.GetInfo();
                    temp = temp.next;
                }
                Console.WriteLine();
            }

            public int Find(string fName)
            {
                int position = -1;
                Node current = head;
                while (current != null)
                {
                    if (current.data.Name == fName)
                    {
                        return current.position;
                    }
                    current = current.next;
                }
                throw new ArgumentOutOfRangeException();
            }

            public IEnumerator GetEnumerator()
            {
                Node current = head;
                while (current != null)
                {
                    yield return current.data;
                    current = current.next;
                }
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }
        }
        static int CorrectIntInput(string str)
        {
            int point = 0;
            while (true)
            {
                Console.Write(str);
                if (!int.TryParse(Console.ReadLine(), out point))  // пробує перетворити строку в int, вертає true, якщо це можливо і записує дані в point
                {
                    Console.WriteLine("Value error!");
                }
                else
                {
                    if (point > 0)
                    {
                        break;
                    }
                }
            }
            return point;
        }
        
        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();
            var train1 = new Train("Train 1", 1, "01/04/2021", "11:10 AM");
            var train2 = new Train("Train 2", 2, "01/03/2021", "11:10 AM");
            var train3 = new Train("Train 3", 3, "01/02/2021", "11:10 AM");
            var train4 = new Train("Train 4", 4, "01/01/2021", "11:10 AM");
            linkedList.Add(train1);
            linkedList.Add(train2);
            linkedList.Add(train3);
            linkedList.Add(train4);
            Console.WriteLine("LINKED TRAIN LIST :");
            linkedList.ShowList();
            Console.WriteLine("\nChoose element to delete\n");
            var temp = new Train();
            temp.InputInfo();
            linkedList.Remove(temp);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("NEW LINKED TRAIN LIST:");
            linkedList.ShowList();
            Console.WriteLine($"\nList count : {linkedList.count}");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Пошук елемента : ");
            try
            {
                Console.WriteLine("Ввеiть данi, котрi хочете знайти : ");
                string name = Console.ReadLine();
                int counter = linkedList.Find(name);
                Console.WriteLine($"Шуканий елемент на позицiї {counter}");
            }
            catch (ArgumentOutOfRangeException)
                {
                Console.WriteLine("Такого елемента немає в списку!");
            }
            Console.ReadKey();
            Console.Clear();

        }
    }
}
