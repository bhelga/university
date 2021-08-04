using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace tryy
{
    class Program
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

            // додаємо в початок
            public void AppendFirst(T data)
            {
                Node<T> node = new Node<T>(data);
                node.Next = head;
                head = node;
                if (count == 0)
                    tail = head;
                node.Number = 0;
                Node<T> current = head.Next;
                while (current != null)
                {
                    current.Number++;
                    current = current.Next;
                }
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
                    new_node.Number = position;
                    Node<T> current = new_node.Next;
                    while (current != null)
                    {
                        current.Number++;
                        current = current.Next;
                    }
                    count++;
                }
            }

            //видалення елемента
            public void Remove(T data)
            {
                Node<T> current = head;
                Node<T> previous = null;
                int position = count;
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
                        position = current.Number;
                        count--;
                        //return true;
                    }
                    if (current.Number > position)
                    {
                        current.Number--;
                    }

                    previous = current;
                    current = current.Next;
                }
                //return false;
            }
            //видалення елемента на позицiї
            public void RemovePosition(int position)
            {
                if (position < 0 || position >= count)
                    throw new ArgumentOutOfRangeException();

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
                        //return true;
                    }

                    if (current.Number > position)
                    {
                        current.Number--;
                    }

                    previous = current;
                    current = current.Next;
                }
                //return false;
            }
            public void RemoveParams(List<T> elements)
            {
                if (elements.Count > count)
                    throw new ArgumentOutOfRangeException();
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
                    head.Data = node.Data;
                    return;
                }

                if (index < 0 || index >= count)
                {
                    throw new ArgumentOutOfRangeException("Index out of bounds.");
                }

                Node<T> current = head;
                while (current.Number != index)
                {
                    current = current.Next;
                }
                current.Data = node.Data;
            }
            
            public void Replace(T data)
            {
                Node<T> current = head;

                while (current != null)
                {
                    current.Data = data;
                    current = current.Next;
                }
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                Node<T> current = head;
                while (current != null)
                {
                    Console.WriteLine($"Current : {current.Number}");
                    yield return current.Data;
                    current = current.Next;
                }
            }
        }
        public class NodeDoubleLinkedList<T>
        {
            //конструктор 
            public NodeDoubleLinkedList(T value)
            {
                Value = value;
            }
            public NodeDoubleLinkedList(T value, NodeDoubleLinkedList<T> next)
            {
                Value = value;
                Next = next;
            }
            
            public T Value { get; set; }
            
            public NodeDoubleLinkedList<T> Next { get; set; }
            public NodeDoubleLinkedList<T> Previous { get; set; } 
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
        internal class DoubleLinkedList<T> : IEnumerable
        {
            public NodeDoubleLinkedList<T> head;
            public NodeDoubleLinkedList<T> tail;
            
            public int Count { get; set; }
            public T this[int index]
            {
                get
                {
                    if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException();
                    NodeDoubleLinkedList<T> current = head;
                    for (int i = 0; i < index; i++)
                    {
                        if (current.Next == null)
                            throw new ArgumentOutOfRangeException();
                        current = current.Next;
                    }
                    return current.Value;
                }
            } 
            public bool IsEmpty
            {
                get
                {
                    return Count == 0;
                }
            } 
            
            public void AddFirst(T value)
            {
                NodeDoubleLinkedList<T> node = new NodeDoubleLinkedList<T>(value);
                NodeDoubleLinkedList<T> temp = head;
                head = node; 
                head.Next = node; 
                head.Next = temp; 
                if (Count == 0)
                {
                    tail = head;
                }
                else
                {
                    temp.Previous = head;
                }
                NodeDoubleLinkedList<T> current = head.Next;
                while (current != null)
                {
                    current.Number++;
                    current = current.Next;
                }
                Count++;
            }
            public void AddLast(T value)
            {
                NodeDoubleLinkedList<T> node = new NodeDoubleLinkedList<T>(value);
                if (Count == 0)
                {
                    head = node;
                }
                else
                {
                    tail.Next = node; 
                    node.Previous = tail; 
                }
                tail = node; 
                node.Number = Count;
                Count++;
            }
            public void AddInside(T value, int index) 
            {
                if (index > Count || index < 0)
                    throw new ArgumentOutOfRangeException();
                if (index == 0)
                    AddFirst(value);
                else if (index == (Count - 1))
                    AddLast(value);
                else
                {
                    NodeDoubleLinkedList<T> currentNode = head;
                    for (int i = 0; i < index - 1; i++)
                    {
                        currentNode = currentNode.Next;
                    }
                    NodeDoubleLinkedList<T> node = new NodeDoubleLinkedList<T>(value, currentNode.Next);
                    currentNode.Next = node;
                    node.Number = index;
                    NodeDoubleLinkedList<T> current = node.Next;
                    while (current != null)
                    {
                        current.Number++;
                        current = current.Next;
                    }
                    Count++;
                }
            }
            public void Remove(T value)
            {
                NodeDoubleLinkedList<T> previous = null;
                NodeDoubleLinkedList<T> current = head; 
                int position = Count;
                while (current != null)
                {
                    if (current.Value.Equals(value))
                    {
                                  

                        if (previous != null) 
                        {
                            previous.Next = current.Next; 


                            if (current.Next == null)
                            {
                                tail = previous;
                            }
                            else
                            {
                                current.Next.Previous = previous; 
                            }
                            Count--;
                        }
                        else
                        {
                            RemoveFirst();
                        }
                        position = current.Number;
                    }

                    if (current.Number > position)
                    {
                        current.Number--;
                    }

                    previous = current;
                    current = current.Next;
                }
            }
            public void RemoveAt(int index)
            {
                if (index > Count || index < 0)
                    throw new ArgumentOutOfRangeException();
                NodeDoubleLinkedList<T> current = head;
                NodeDoubleLinkedList<T> previous = null;

                while (current != null)
                {
                    if (current.Number.Equals(index))
                    {
                        
                        if (previous != null)
                        {
                            
                            previous.Next = current.Next;

                            
                            if (current.Next == null)
                                tail = previous;
                        }
                        else
                        {
                            
                            head = head.Next;

                            
                            if (head == null)
                                tail = null;
                        }

                        Count--;
                        
                    }

                    if (current.Number > index)
                    {
                        current.Number--;
                    }

                    previous = current;
                    current = current.Next;
                }

            } 
            public T RemoveFirst()
            {
                T removedData = head.Value;
                if (Count != 0)
                {
                    head = head.Next;
                    Count--;
                    if (Count == 0)
                    {
                        tail = null;
                    }
                    else
                    {
                        head.Previous = null;
                    }
                }
                Count--;
                return removedData;
            }
            public T RemoveLast()
            {
                T removedData = tail.Value;
                switch (Count)
                {
                    case 0:
                        return removedData;
                    case 1:
                        head = tail = null;
                        break;
                    default:
                        tail.Previous.Next = null;
                        tail = tail.Previous;
                        break;
                }
                Count--;
                return removedData;
            }
            public void RemoveParams(List<T> elements)
            {
                for (int i = 0; i < elements.Count; i++)
                {
                    Remove(elements[i]);
                }
            }
            public bool Contains(T value) 
            {
                NodeDoubleLinkedList<T> current = head;
                for (int i = 0; i < Count; i++)
                {
                    if (current.Value.Equals(value))
                        return true;
                    current = current.Next;
                }
                return false;
            }
            public int FindIdByElement(T value) 
            {
                NodeDoubleLinkedList<T> current = head;
                for (int i = 0; i < Count; i++)
                {
                    if (current.Value.Equals(value))
                        Console.WriteLine("Поиск нужного элемента имеет номер {0} в списке", i);
                    current = current.Next;
                }
                return -1;
            }
            public void ReplaceAll(T data)
            {
                NodeDoubleLinkedList<T> current = head;

                while (current != null)
                {
                    current.Value = data;
                    current = current.Next;
                }
            }
            public void Replace(T oldItem, T newItem) 
            {
                NodeDoubleLinkedList<T> current = head;
                while (current != null)
                {
                    if (current.Value.Equals(oldItem))
                    {
                        current.Value = newItem;
                    }
                    current = current.Next;
                }
            }
            public void ReplaceLast(T value)
            {
                NodeDoubleLinkedList<T> node = new NodeDoubleLinkedList<T>(value);
                if (head == null)
                {
                    head = node;
                    tail = node;
                }
                else
                {
                    tail.Value = value;
                }
            } 
            public void ReplaceFirst(T value)
            {
                NodeDoubleLinkedList<T> node = new NodeDoubleLinkedList<T>(value);
                if (head == null)
                {
                    head = node;
                    tail = node;
                }
                else
                {
                    head.Value = value;
                }
            }
            public void ClearAll() 
            {
                head = null;
                tail = null;
                Count = 0;
            }
            public void Edit(int index, T data)
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException();
                NodeDoubleLinkedList<T> node = new NodeDoubleLinkedList<T>(data);
                if (index == 0)
                {
                    head.Value = node.Value;
                    return;
                }

                NodeDoubleLinkedList<T> current = head;
                while (current.Number != index)
                {
                    current = current.Next;
                }
                current.Value = node.Value;
            }
            public void Sort()
            {
                NodeDoubleLinkedList<T> current1 = head;

                while (current1 != null)
                {
                    NodeDoubleLinkedList<T> current2 = head;
                    while (current2 != null)
                    {
                        if (NodeDoubleLinkedList<T>.IsBiggerThan(current1.Value, current2.Value))
                        {
                            T temp = current1.Value;
                            current1.Value = current2.Value;
                            current2.Value = temp;
                        }
                        current2 = current2.Next;
                    }
                    current1 = current1.Next;
                }
            }
            public IEnumerator<T> GetEnumerator()
            {
                NodeDoubleLinkedList<T> current = head;
                while (current != null)
                {
                    Console.WriteLine($"Current : {current.Number}");
                    yield return current.Value;
                    current = current.Next;
                }
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();

            }
        }
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
            public override bool Equals(object obj)
            {
                if (obj is Student)
                {
                    Student s = (Student)obj;
                    return this.Name == s.Name && this.Avarage == s.Avarage;
                }
                else
                {
                    return false;
                }
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
            //public static bool operator ==(Student obj1, Student obj2)
            //{
            //    if ((obj1.Name == obj2.Name))
            //    {
            //        if ((obj1.Avarage == obj2.Avarage))
            //            return true;
            //        else 
            //            return false;
            //    }
            //    return false;
            //}
            //public static bool operator !=(Student obj1, Student obj2)
            //{
            //    if ((obj1.Name != obj2.Name) || (obj1.Avarage != obj2.Avarage))
            //        return true;
            //    return false;
            //}
            //public static bool operator >(Student obj1, Student obj2)
            //{
            //    if (obj1.Avarage > obj2.Avarage)
            //        return true;
            //    return false;
            //}
            //public static bool operator <(Student obj1, Student obj2)
            //{
            //    if (obj1.Avarage < obj2.Avarage)
            //        return true;
            //    return false;
            //}
            //public static bool operator >=(Student obj1, Student obj2)
            //{
            //    if (obj1.Avarage >= obj2.Avarage)
            //        return true;
            //    return false;
            //}
            //public static bool operator <=(Student obj1, Student obj2)
            //{
            //    if (obj1.Avarage <= obj2.Avarage)
            //        return true;
            //    return false;
            //}
        }
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
                    if (point >= 0)
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
            string path1 = @"D:\helga\university\programming\university\c#\Lab14\test1.txt";
            string path2 = @"D:\helga\university\programming\university\c#\Lab14\test2.txt";
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
                DoubleLinkedList<Student> doubleLinkedList = new DoubleLinkedList<Student>();
                string oprtr = "";
                string tmp = "";

                Console.WriteLine("1. Робота з однозв’язними списками\n2.Робота з двозв’язними списками");
                Console.WriteLine("\n\nЩоб почати роботу з файлом напишiть \"Start\". Щоб закiнчити – \"Exit\" : ");
                string exit = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("1. Робота з однозв’язними списками\n2.Робота з двозв’язними списками");
                
                if (exit == "Start")
                {
                    Console.Write("Введiть номер операцiї : ");
                    oprtr = Console.ReadLine();
                }
                else if (exit == "Exit")
                {
                    break;
                }
                else
                {
                    continue;
                }
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
                                Console.WriteLine("\n\nНатиснiть будь-яку клавiшу для виходу");
                                Console.ReadKey();
                                break;
                            case "3":
                                Console.WriteLine($"Кiлькiсть студентiв в вiдомостi : {myLinkedList.Count}");
                                Console.WriteLine("\n\nНатиснiть будь-яку клавiшу для виходу");
                                Console.ReadKey();
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
                                Console.WriteLine("\n\nНатиснiть будь-яку клавiшу для виходу");
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
                                Console.WriteLine("\n\nНатиснiть будь-яку клавiшу для виходу");
                                Console.ReadKey();
                                break;
                            case "8":
                                Console.WriteLine("Ввеiть данi, на котрi хочете замiнити : ");
                                var temp82 = new Student();
                                temp82.InputInfo();
                                myLinkedList.Replace(temp82);
                                Console.WriteLine("\n\nНатиснiть будь-яку клавiшу для виходу");
                                Console.ReadKey();
                                break;
                            case "9":
                                Console.WriteLine("Ввеiть iм'я студента : ");
                                var str = Console.ReadLine();
                                //var temp9 = new Student();
                                //temp9.InputInfo();
                                counter = 0;
                                foreach (var i in myLinkedList)
                                {
                                    if (i.Name == str)
                                    {
                                        break;
                                    }
                                    counter++;
                                }
                                Console.WriteLine($"Шуканий елемент на позицiї {counter}");
                                Console.WriteLine("\n\nНатиснiть будь-яку клавiшу для виходу");
                                Console.ReadKey();
                                break;
                            case "10":
                                myLinkedList.Sort();
                                Console.WriteLine("Вiдсортований список : \n");
                                foreach (var i in myLinkedList)
                                {
                                    i.ShowInfo();
                                    Console.WriteLine("________________________________________");
                                }
                                Console.WriteLine("\n\nНатиснiть будь-яку клавiшу для виходу");
                                Console.ReadKey();
                                break;
                            case "11":
                                using (StreamWriter sw = new StreamWriter(path1, true))
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
                                Console.WriteLine("Файл успiшно записано!\n\nНатиснiть будь-яку клавiшу для виходу");
                                Console.ReadKey();
                                break;
                            case "12":
                                var newLinkedList = new MyLinkedList<Student>();
                                using (StreamReader sr = new StreamReader(path2, encoding: System.Text.Encoding.Default))
                                {
                                    string line;
                                    while ((line = sr.ReadLine()) != null)
                                    {
                                        var tempStudent = new Student();
                                        tempStudent.Name = line;
                                        tempStudent.Avarage = int.Parse(sr.ReadLine());
                                        newLinkedList.Add(tempStudent);

                                    }
                                }
                                Console.WriteLine("New Linked List : ");
                                foreach (var i in newLinkedList)
                                {
                                    i.ShowInfo();
                                }
                                Console.WriteLine("Файл успiшно зчитано!\n\nНатиснiть будь-яку клавiшу для виходу");
                                Console.ReadKey();
                                break;
                            default:
                                Console.WriteLine("Сталася помилка! Спробуйте ще раз!");
                                break;
                        }
                        Console.WriteLine("Щоб вийти в головне меню, натиснiть \"1\". Натиснiть будь-що для продовження роботи");
                        oprtr = Console.ReadLine();
                        if (oprtr == "1") break;
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
                                    doubleLinkedList.AddLast(temp);
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
                                if (!doubleLinkedList.IsEmpty)
                                {
                                    foreach (var i in doubleLinkedList)
                                    {
                                        i.ShowInfo();
                                        Console.WriteLine("______________________________________________________");
                                    }
                                }
                                Console.WriteLine("\n\nНатиснiть будь-яку клавiшу для виходу");
                                Console.ReadKey();
                                break;
                            case "3":
                                Console.WriteLine($"Кiлькiсть студентiв в вiдомостi : {doubleLinkedList.Count}");
                                Console.WriteLine("\n\nНатиснiть будь-яку клавiшу для виходу");
                                Console.ReadKey();
                                break;
                            case "4":
                                Console.WriteLine("Ввеiть данi студента : ");
                                var temp4 = new Student();
                                temp4.InputInfo();
                                if (doubleLinkedList.Contains(temp4))
                                {
                                    Console.WriteLine("Цей учень занесений в вiдомiсть.");
                                }
                                else
                                {
                                    Console.WriteLine("Цей учень не занесений в вiдомiсть.");
                                }
                                Console.WriteLine("\n\nНатиснiть будь-яку клавiшу для виходу");
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
                                            doubleLinkedList.AddFirst(temp51);
                                            break;
                                        case "2":
                                            Console.WriteLine("Ввеiть данi студента : ");
                                            var temp52 = new Student();
                                            temp52.InputInfo();
                                            doubleLinkedList.AddLast(temp52);
                                            break;
                                        case "3":
                                            Console.WriteLine("Ввеiть данi студента : ");
                                            var temp53 = new Student();
                                            temp53.InputInfo();
                                            int position2 = CorrectIntInput("Введiть позицiю для вставки : ");
                                            doubleLinkedList.AddInside(temp53, position2);
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
                                            doubleLinkedList.ClearAll();
                                            Console.WriteLine("Список очищено");
                                            break;
                                        case "2":
                                            int position1 = CorrectIntInput("Введiть позицiю для видалення : ");
                                            doubleLinkedList.RemoveAt(position1);
                                            break;
                                        case "3":
                                            Console.WriteLine("Ввеiть данi студента : ");
                                            var temp63 = new Student();
                                            temp63.InputInfo();
                                            doubleLinkedList.Remove(temp63);
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
                                            doubleLinkedList.RemoveParams(tempList);
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
                                doubleLinkedList.Edit(position, temp7);
                                Console.WriteLine("\n\nНатиснiть будь-яку клавiшу для виходу");
                                Console.ReadKey();
                                break;
                            case "8":
                                Console.WriteLine("Ввеiть данi, на котрi хочете замiнити : ");
                                var temp82 = new Student();
                                temp82.InputInfo();
                                doubleLinkedList.ReplaceAll(temp82);
                                Console.WriteLine("\n\nНатиснiть будь-яку клавiшу для виходу");
                                Console.ReadKey();
                                break;
                            case "9":
                                Console.WriteLine("Ввеiть iм'я студента : ");
                                var str = Console.ReadLine();
                                //var temp9 = new Student();
                                //temp9.InputInfo();
                                counter = 0;
                                foreach (var i in doubleLinkedList)
                                {
                                    if (i.Name == str)
                                    {
                                        break;
                                    }
                                    counter++;
                                }
                                Console.WriteLine($"Шуканий елемент на позицiї {counter}");
                                Console.WriteLine("\n\nНатиснiть будь-яку клавiшу для виходу");
                                Console.ReadKey();
                                break;
                            case "10":
                                doubleLinkedList.Sort();
                                Console.WriteLine("Вiдсортований список : \n");
                                foreach (var i in doubleLinkedList)
                                {
                                    i.ShowInfo();
                                    Console.WriteLine("________________________________________");
                                }
                                Console.WriteLine("\n\nНатиснiть будь-яку клавiшу для виходу");
                                Console.ReadKey();
                                break;
                            case "11":
                                using (StreamWriter sw = new StreamWriter(path1, true))
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
                                Console.WriteLine("Файл успiшно записано!\n\nНатиснiть будь-яку клавiшу для виходу");
                                Console.ReadKey();
                                break;
                            case "12":
                                var newLinkedList = new MyLinkedList<Student>();
                                using (StreamReader sr = new StreamReader(path2, encoding: System.Text.Encoding.Default))
                                {
                                    string line;
                                    while ((line = sr.ReadLine()) != null)
                                    {
                                        var tempStudent = new Student();
                                        tempStudent.Name = line;
                                        tempStudent.Avarage = int.Parse(sr.ReadLine());
                                        newLinkedList.Add(tempStudent);

                                    }
                                }
                                Console.WriteLine("New Linked List : ");
                                foreach (var i in newLinkedList)
                                {
                                    i.ShowInfo();
                                }
                                Console.WriteLine("Файл успiшно зчитано!\n\nНатиснiть будь-яку клавiшу для виходу");
                                Console.ReadKey();
                                break;
                            default:
                                Console.WriteLine("Сталася помилка! Спробуйте ще раз!");
                                break;
                        }
                        Console.WriteLine("Щоб вийти в головне меню, натиснiть \"1\". Натиснiть будь-що для продовження роботи");
                        oprtr = Console.ReadLine();
                        if (oprtr == "1") break;
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
