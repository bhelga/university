using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab14_1
{

    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public Node(T data, Node<T> next)
        {
            Data = data;
            Next = next;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public int Number { get; set; }

        public static bool Compare(T a, T b, int res)
        {
            Comparer<T> comparer = Comparer<T>.Default;
            return comparer.Compare(a, b) == res ? true : false;
        }

        public static bool IsBiggerThan(T a, T b) { return Compare(a, b, 1); }

        public static bool IsEqualTo(T a, T b) { return Compare(a, b, 0); }

        public static bool IsLessThan(T a, T b) { return Compare(a, b, -1); }
    }
    public class MyLinkedList<T> : IEnumerable<T>  // однозв'язний список
    {
        Node<T> head; // перший елемент
        Node<T> tail; // останнiй елемент
        int count;  // кiлькiсть елементiв в списку
        public void Sort()
        {
            Node<T> current1 = head;
            
            while (current1 != null)
            {
                Node<T> current2 = head;
                while (current2 != null)
                {
                    if (Node<T>.IsBiggerThan(current1.Data, current2.Data))
                    {
                        T temp = current1.Data;
                        current1.Data = current2.Data;
                        current2.Data = temp;
                    }
                    current2 = current2.Next;
                }
                current1 = current1.Next;
            }
        }
        // додавання елемента
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;
            node.Number = count;
            count++;
        }

        //видалення елемента
        public bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    // якщо вузол вкiнцi чи всерединi
                    if (previous != null)
                    {
                        // забираємо вузол current, тепер previous посилається не на current, а на current.Next 
                        previous.Next = current.Next;

                        // Якщо current.Next не встановлений, то вузол останнiй, змiнюємо tail
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        // якщо видаляється перший елемент, перевстановлюємо значення head
                        head = head.Next;

                        // якщо пiсля видалення список пустий, то видаляємо i tail
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }
        //видалення елемента на позицiї
        public bool RemovePosition(int position)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Number.Equals(position))
                {
                    // якщо вузол вкiнцi чи всерединi
                    if (previous != null)
                    {
                        // забираємо вузол current, тепер previous посилається не на current, а на current.Next 
                        previous.Next = current.Next;

                        // Якщо current.Next не встановлений, то вузол останнiй, змiнюємо tail
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        // якщо видаляється перший елемент, перевстановлюємо значення head
                        head = head.Next;

                        // якщо пiсля видалення список пустий, то видаляємо i tail
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }
        public void RemoveParams(List<T> elements)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                Remove(elements[i]);
            }
        }
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        // очистка списка
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        // чи мiстить список елемент
        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }
        // редагування елемента на позицiї
        public void Edit(int index, T data)
        {
            Node<T> node = new Node<T>(data);
            if (index == 0)
            {
                head = node;
                return;
            }

            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException("Index out of bounds.");
            }

            Node<T> pre = head;
            Node<T> temp = null;
            for (int i = 1; i <= index; i++)
            {
                temp = pre;
                pre = pre.Next;
            }
            temp.Next = node;
            node.Next = pre.Next;
        }
        // додаємо в початок
        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }
        // додаємо на позицiю
        public void AddBefore(T data, int position)
        {
            if (position < 0 || position >= count)
                throw new ArgumentOutOfRangeException();
            if (position == 0)
            {
                AppendFirst(data);
            }
            else
            {
                Node<T> node = head;
                for (int i = 1; i < position; i++)
                {
                    node = node.Next;
                }
                Node<T> new_node = new Node<T>(data, node.Next);
                node.Next = new_node;
                count++;
            }
        }
        // зчитування з файлу
        //public void ReadFromfile(string path)
        //{
        //    StreamReader sr = File.OpenText(path);
        //    string s;
        //    try
        //    {
        //        while ((s = sr.ReadLine()) != null)
        //        {
        //            Student ellis = new Student(s);
        //            this.Add(ellis);
        //        }

        //    }
        //    catch (IOException)
        //    {
        //    }
        //}
        // реализацiя IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
    [Serializable]
    class Student : IComparable
    {
        public Student(string name, double avarage)
        {
            Name = name;
            Avarage = avarage;
        }

        public Student()
        {
        }

        static double CorrectDoubleInput(string str)
        {
            double point = 0;
            while (true)
            {
                Console.Write(str);
                if (!double.TryParse(Console.ReadLine(), out point))  // пробує перетворити строку в int, вертає true, якщо це можливо i записує данi в point
                {
                    Console.WriteLine("Value error!");
                }
                else
                {
                    if (point >= 0)
                        break;
                }
            }
            return point;
        }
        public string Name { get; set; }
        public double Avarage { get; set; }
        public void InputInfo()
        {
            Console.WriteLine("Введiть iм'я на прiзвище студента : ");
            this.Name = Console.ReadLine();
            this.Avarage = CorrectDoubleInput("Введiть середнiй бал успiшностi : ");
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Студент : {this.Name}\nСереднiй бал : {this.Avarage}");
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Student otherStudent = (Student)obj;
            if (otherStudent != null)
            {
                return this.Avarage.CompareTo(otherStudent.Avarage);
            }
            else
            {
                throw new ArgumentException("Object is not a Student");
            }
        }
        public static bool operator ==(Student obj1, Student obj2)
        {
            if ((obj1.Name == obj2.Name) && (obj1.Avarage == obj2.Avarage))
                return true;
            return false;
        }
        public static bool operator !=(Student obj1, Student obj2)
        {
            if ((obj1.Name != obj2.Name) || (obj1.Avarage != obj2.Avarage))
                return true;
            return false;
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
            int counter;
            string path = @"D:\helga\university\programming\university\c#\Lab14\test.bin";
            string str1 = "1) формування списку (згiдно варiанту);\n"
                          + "2)	перегляд елементiв списку;\n"
                          + "3)	визначення кiлькостi елементiв списку;\n"
                          + "4)	перевiрка списку на вiдсутнiсть елементiв;\n"
                          + "5)	вставка елементiв в список;\n"
                          + "6)	видалення елементiв iз списку;\n"
                          + "7)	редагування елементiв списку;\n"
                          + "8)	замiна всiх елементiв списку iз заданим значенням на нове значення введене користувачем програми;\n"
                          + "9)	пошук елементiв в списку за заданим полем;\n"
                          + "10) сортування елементiв списку;\n"
                          + "11) збереження списку у файл;\n"
                          + "12) читання(завантаження) списку iз файлу\n";
            BinaryFormatter bf = new BinaryFormatter();
            bool flag = true;
            while (true)
            {
                MyLinkedList<Student> myLinkedList = new MyLinkedList<Student>();
                LinkedList<Student> linkedList = new LinkedList<Student>();
                string oprtr = "";
                string tmp = "";
                Console.WriteLine("1. Робота з однозв’язними списками\n2.Робота з двозв’язними списками");
                Console.Write("Введiть номер операцiї : ");
                oprtr = Console.ReadLine();
                if (oprtr == "1" && flag)
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine(str1);
                        Console.Write("\nВведiть номер операцiї : ");
                        oprtr = Console.ReadLine();
                        Console.Clear();
                        switch (oprtr)
                        {
                            case "1":
                                while (true)
                                {
                                    var temp = new Student();
                                    temp.InputInfo();
                                    myLinkedList.Add(temp);
                                    Console.WriteLine("Щоб додати ще одного учня до бази, натистiть 1. Щоб повернутися до меню натиснiть будь-яку клавiшу");
                                    tmp = Console.ReadLine();
                                    if (tmp != "1")
                                    {
                                        break;
                                    }
                                }
                                break;
                            case "2":
                                Console.WriteLine("Вiдомiсть успiшностi студентiв");
                                if (!myLinkedList.IsEmpty)
                                {
                                    foreach (var i in myLinkedList)
                                    {
                                        i.ShowInfo();
                                        Console.WriteLine("______________________________________________________");
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "3":
                                Console.WriteLine($"Кiлькiсть студентiв в вiдомостi : {myLinkedList.Count}");
                                break;
                            case "4":
                                Console.WriteLine("Ввеiть данi студента : ");
                                var temp4 = new Student();
                                temp4.InputInfo();
                                if (myLinkedList.Contains(temp4))
                                {
                                    Console.WriteLine("Цей учень занесений в вiдомiсть.");
                                }
                                else
                                {
                                    Console.WriteLine("Цей учень не занесений в вiдомiсть.");
                                }
                                break;
                            case "5":
                                while (true)
                                {
                                    Console.WriteLine("1. на початок\n2. в кiнець\n3. у вiдповiдну позицiю");
                                    Console.Write("Введiть номер операцiї : ");
                                    oprtr = Console.ReadLine();
                                    switch (oprtr)
                                    {
                                        case "1":
                                            Console.WriteLine("Ввеiть данi студента : ");
                                            var temp51 = new Student();
                                            temp51.InputInfo();
                                            myLinkedList.AppendFirst(temp51);
                                            break;
                                        case "2":
                                            Console.WriteLine("Ввеiть данi студента : ");
                                            var temp52 = new Student();
                                            temp52.InputInfo();
                                            myLinkedList.Add(temp52);
                                            break;
                                        case "3":
                                            Console.WriteLine("Ввеiть данi студента : ");
                                            var temp53 = new Student();
                                            temp53.InputInfo();
                                            int position2 = CorrectIntInput("Введiть позицiю для вставки : ");
                                            myLinkedList.AddBefore(temp53, position2);
                                            break;
                                        default:
                                            Console.WriteLine("Введенi данi некоректнi! Спробуйте знову!");
                                            break;
                                    }
                                    Console.WriteLine("Щоб вийти в головне меню, натиснiть 1. Натиснiть будь-що для продовження роботи.");
                                    oprtr = Console.ReadLine();
                                    if (oprtr == "1") break;
                                }
                                break;
                            case "6":
                                while (true)
                                {
                                    Console.WriteLine("1. всiх елементiв\n2. конкретного елементу\n3. елементу iз заданим значенням\n4. елементiв iз заданим значенням");
                                    Console.Write("Введiть номер операцiї : ");
                                    oprtr = Console.ReadLine();
                                    switch (oprtr)
                                    {
                                        case "1":
                                            myLinkedList.Clear();
                                            Console.WriteLine("Список очищено");
                                            break;
                                        case "2":
                                            int position1 = CorrectIntInput("Введiть позицiю для видалення : ");
                                            myLinkedList.RemovePosition(position1);
                                            break;
                                        case "3":
                                            Console.WriteLine("Ввеiть данi студента : ");
                                            var temp63 = new Student();
                                            temp63.InputInfo();
                                            myLinkedList.Remove(temp63);
                                            break;
                                        case "4":
                                            var tempList = new List<Student>();
                                            while (true)
                                            {
                                                Console.WriteLine("Ввеiть данi студента : ");
                                                var temp64 = new Student();
                                                temp64.InputInfo();
                                                tempList.Add(temp64);
                                                Console.WriteLine("Щоб вийти в головне меню, натиснiть 1. Натиснiть будь-що для продовження роботи.");
                                                oprtr = Console.ReadLine();
                                                if (oprtr == "1") break;
                                            }
                                            myLinkedList.RemoveParams(tempList);
                                            break;
                                        default:
                                            Console.WriteLine("Введенi данi некоректнi! Спробуйте знову!");
                                            break;
                                    }
                                    Console.WriteLine("Щоб вийти в головне меню, натиснiть 1. Натиснiть будь-що для продовження роботи.");
                                    oprtr = Console.ReadLine();
                                    if (oprtr == "1") break;
                                }
                                break;
                            case "7":
                                Console.WriteLine("Введiть данi студента : ");
                                var temp7 = new Student();
                                temp7.InputInfo();
                                int position = CorrectIntInput("Введiть позицiю для редагування : ");
                                myLinkedList.Edit(position, temp7);
                                break;
                            case "8":
                                Console.WriteLine("Ввеiть данi, котрi хочете замiнити : ");
                                var temp81 = new Student();
                                temp81.InputInfo();
                                Console.WriteLine("Ввеiть данi, на котрi хочете замiнити : ");
                                var temp82 = new Student();
                                temp82.InputInfo();
                                counter = 0;
                                foreach (var i in myLinkedList)
                                {
                                    if (i.Name == temp81.Name && i.Avarage == temp81.Avarage)
                                    {
                                        myLinkedList.Edit(counter, temp82);
                                    }
                                    counter++;
                                }
                                break;
                            case "9":
                                Console.WriteLine("Ввеiть данi, на котрi хочете знайти : ");
                                var temp9 = new Student();
                                temp9.InputInfo();
                                counter = 0;
                                foreach (var i in myLinkedList)
                                {
                                    if (i.Name == temp9.Name && i.Avarage == temp9.Avarage)
                                    {
                                        break;
                                    }
                                    counter++;
                                }
                                Console.WriteLine($"Шуканий елемент на позицiї {counter}");
                                break;
                            case "10":
                                myLinkedList.Sort();
                                Console.WriteLine("Вiдсортований список : \n");
                                foreach (var i in myLinkedList)
                                {
                                    i.ShowInfo();
                                    Console.WriteLine("________________________________________");
                                }
                                Console.ReadKey();
                                break;
                            case "11":
                                using (FileStream fs = File.Create(path))
                                    bf.Serialize(fs, myLinkedList);
                                break;
                            case "12":
                                using (FileStream fs = File.OpenRead(path))
                                {
                                   MyLinkedList<Student> newSchedule = (MyLinkedList<Student>)bf.Deserialize(fs);
                                }
                                break;
                            default:
                                Console.WriteLine("Сталася помилка! Спробуйте ще раз!");
                                break;
                        }
                    }
                }
                else if (oprtr == "2" && flag)
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine(str1);
                        Console.Write("\nВведiть номер операцiї : ");
                        oprtr = Console.ReadLine();
                        Console.Clear();
                        switch (oprtr)
                        {
                            case "1":
                                while (true)
                                {
                                    var temp = new Student();
                                    temp.InputInfo();
                                    linkedList.AddLast(temp);
                                    Console.WriteLine("Щоб додати ще одного учня до бази, натистiть 1. Щоб повернутися до меню натиснiть будь-яку клавiшу");
                                    tmp = Console.ReadLine();
                                    if (tmp != "1")
                                    {
                                        break;
                                    }
                                }
                                break;
                            case "2":
                                Console.WriteLine("Вiдомiсть успiшностi студентiв");
                                foreach (var i in linkedList)
                                {
                                    i.ShowInfo();
                                    Console.WriteLine("______________________________________________________");
                                }
                                //if (!linkedList.Any())
                                //{
                                //    foreach (var i in linkedList)
                                //    {
                                //        i.ShowInfo();
                                //        Console.WriteLine("______________________________________________________");
                                //    }
                                //}
                                Console.ReadKey();
                                break;
                            case "3":
                                Console.WriteLine($"Кiлькiсть студентiв в вiдомостi : {linkedList.Count}");
                                Console.ReadKey();
                                break;
                            case "4":
                                Console.WriteLine("Ввеiть данi студента : ");
                                var temp24 = new Student();
                                temp24.InputInfo();
                                bool fl = false;
                                foreach (var i in linkedList)
                                {
                                    if (i == temp24)
                                    {
                                        fl = true;
                                        break;
                                    }
                                }
                                if (fl)
                                {
                                    Console.WriteLine("Цей учень занесений в вiдомiсть.");
                                }
                                else
                                {
                                    Console.WriteLine("Цей учень не занесений в вiдомiсть.");
                                }
                                Console.ReadKey();
                                break;
                            case "5":
                                while (true)
                                {
                                    Console.WriteLine("1. на початок\n2. в кiнець\n3. у вiдповiдну позицiю");
                                    Console.Write("Введiть номер операцiї : ");
                                    oprtr = Console.ReadLine();
                                    switch (oprtr)
                                    {
                                        case "1":
                                            Console.WriteLine("Ввеiть данi студента : ");
                                            var temp51 = new Student();
                                            temp51.InputInfo();
                                            linkedList.AddFirst(temp51);
                                            break;
                                        case "2":
                                            Console.WriteLine("Ввеiть данi студента : ");
                                            var temp52 = new Student();
                                            temp52.InputInfo();
                                            linkedList.AddLast(temp52);
                                            break;
                                        case "3":
                                            Console.WriteLine("Ввеiть данi студента : ");
                                            var temp53 = new Student();
                                            temp53.InputInfo();
                                            int position2 = CorrectIntInput("Введiть позицiю для вставки : ");
                                            LinkedListNode<Student> current3 = linkedList.First;
                                            int j3 = 0;
                                            foreach (var i in linkedList)
                                            {
                                                if (j3 == position2)
                                                {
                                                    current3 = linkedList.Find(i);
                                                    break;
                                                }
                                                j3++;
                                            }
                                            if (current3 == linkedList.First && j3 == linkedList.Count)
                                            {
                                                Console.WriteLine("Елемента не знайдено!");
                                                break;
                                            }
                                            linkedList.AddBefore(current3, temp53);
                                            //linkedList.AddBefore(temp53, position2);
                                            break;
                                        default:
                                            Console.WriteLine("Введенi данi некоректнi! Спробуйте знову!");
                                            break;
                                    }
                                    Console.WriteLine("Щоб вийти в головне меню, натиснiть 1. Натиснiть будь-що для продовження роботи.");
                                    oprtr = Console.ReadLine();
                                    if (oprtr == "1") break;
                                }
                                break;
                            case "6":
                                while (true)
                                {
                                    Console.WriteLine("1. всiх елементiв\n2. конкретного елементу\n3. елементу iз заданим значенням\n4. елементiв iз заданим значенням");
                                    Console.Write("Введiть номер операцiї : ");
                                    oprtr = Console.ReadLine();
                                    switch (oprtr)
                                    {
                                        case "1":
                                            linkedList.Clear();
                                            Console.WriteLine("Список очищено");
                                            break;
                                        case "2":
                                            int position1 = CorrectIntInput("Введiть позицiю для видалення : ");
                                            Student temp62 = new Student();
                                            int j1 = 0;
                                            foreach (var i in linkedList)
                                            {
                                                if (j1 == position1)
                                                {
                                                    temp62 = i;
                                                    break;
                                                }
                                                j1++;
                                            }
                                            linkedList.Remove(temp62);
                                            break;
                                        case "3":
                                            Console.WriteLine("Ввеiть данi студента : ");
                                            var temp63 = new Student();
                                            temp63.InputInfo();
                                            linkedList.Remove(temp63);
                                            break;
                                        case "4":
                                            var tempList = new List<Student>();
                                            while (true)
                                            {
                                                Console.WriteLine("Ввеiть данi студента : ");
                                                var temp64 = new Student();
                                                temp64.InputInfo();
                                                tempList.Add(temp64);
                                                Console.WriteLine("Щоб вийти в головне меню, натиснiть 1. Натиснiть будь-що для продовження роботи.");
                                                oprtr = Console.ReadLine();
                                                if (oprtr == "1") break;
                                            }
                                            foreach (var i in tempList)
                                            {
                                                linkedList.Remove(i);
                                            }
                                            break;
                                        default:
                                            Console.WriteLine("Введенi данi некоректнi! Спробуйте знову!");
                                            break;
                                    }
                                    Console.WriteLine("Щоб вийти в головне меню, натиснiть 1. Натиснiть будь-що для продовження роботи.");
                                    oprtr = Console.ReadLine();
                                    if (oprtr == "1") break;
                                }
                                break;
                            case "7":
                                Console.WriteLine("Введiть данi студента : ");
                                var temp7 = new Student();
                                temp7.InputInfo();
                                int position = CorrectIntInput("Введiть позицiю для редагування : ");
                                LinkedListNode<Student> current = linkedList.First;
                                int j = 0;
                                foreach (var i in linkedList)
                                {
                                    if (j == position)
                                    {
                                        current = linkedList.Find(i);
                                        break;
                                    }
                                    j++;
                                }
                                if (current == linkedList.First && j == linkedList.Count - 1)
                                {
                                    Console.WriteLine("Елемента не знайдено!");
                                    break;
                                }
                                linkedList.Remove(current);
                                linkedList.AddBefore(current, temp7);
                                break;
                            case "8":
                                LinkedListNode<Student> current8 = linkedList.First;
                                Console.WriteLine("Ввеiть данi, котрi хочете замiнити : ");
                                var temp81 = new Student();
                                temp81.InputInfo();
                                Console.WriteLine("Ввеiть данi, на котрi хочете замiнити : ");
                                var temp82 = new Student();
                                temp82.InputInfo();
                                counter = 0;
                                foreach (var i in linkedList)
                                {
                                    if (i.Name == temp81.Name && i.Avarage == temp81.Avarage)
                                    {
                                        current8 = linkedList.Find(i);
                                        break;
                                    }
                                    counter++;
                                }
                                if (counter == linkedList.Count)
                                {
                                    Console.WriteLine("Елемента не знайдено!");
                                    break;
                                }
                                linkedList.Remove(current8);
                                linkedList.AddBefore(current8, temp82);
                                break;
                            case "9":
                                Console.WriteLine("Ввеiть данi, котрi хочете знайти : ");
                                var temp9 = new Student();
                                temp9.InputInfo();
                                counter = 0;
                                foreach (var i in linkedList)
                                {
                                    if (i.Name == temp9.Name && i.Avarage == temp9.Avarage)
                                    {
                                        break;
                                    }
                                    counter++;
                                }
                                if (counter < linkedList.Count) Console.WriteLine($"Шуканий елемент на позицiї {counter}");
                                else Console.WriteLine("Елемент не знайдено!");
                                break;
                            case "10":
                                //linkedList.OrderByDescending<Student>(item => item);
                                Console.WriteLine("Вiдсортований список : \n");
                                foreach (var i in linkedList)
                                {
                                    i.ShowInfo();
                                    Console.WriteLine("________________________________________");
                                }
                                Console.ReadKey();
                                break;
                            case "11":
                                using (StreamWriter sw = new StreamWriter(path, true))
                                {
                                    foreach (var i in myLinkedList)
                                    {
                                        try
                                        {
                                            sw.WriteLine($"{i.Name}\n{i.Avarage}");
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                    }
                                } 
                                break;
                            case "12":
                                using (FileStream fs = File.OpenRead(path))
                                {
                                    MyLinkedList<Student> newSchedule = (MyLinkedList<Student>)bf.Deserialize(fs);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
                else if (flag)
                {
                    Console.WriteLine("Помилка! Перевiрте правильнiсть введених даних!");
                    Console.WriteLine("Натиснiсть будь-яку клавiшу для продовження роботи... ");
                    Console.ReadKey();
                }
            }
        }
    }
}
