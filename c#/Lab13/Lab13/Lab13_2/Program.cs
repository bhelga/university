using System;

namespace Lab13_2
{
    class Program
    {
        enum PartOfDay
        {
            Dawn,
            Morning,
            Midday,
            Afternoon,
            Evening,
            Midnight
        }
        static void Main(string[] args)
        {
            bool flag = true;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Parts of day:\n" +
                "1. Dawn\n" +
                "2. Morning\n" +
                "3. Midday\n" +
                "4. Afternoon\n" +
                "5. Evening\n" +
                "6. Midnight");
                Console.Write("Choose your part : ");
                string userPart = Console.ReadLine();
                switch (userPart)
                {
                    case nameof(PartOfDay.Dawn):
                        Console.WriteLine("Dawn – 5:00 AM (Glass of water)");
                        break;
                    case nameof(PartOfDay.Morning):
                        Console.WriteLine("Morning – 8:00 AM (Avocado & black bean eggs)");
                        break;
                    case nameof(PartOfDay.Midday):
                        Console.WriteLine("Midday – 12:00 PM (Heart helper smoothie)");
                        break;
                    case nameof(PartOfDay.Afternoon):
                        Console.WriteLine("Afternoon – 4:00 PM (Spinach protein pancakes)");
                        break;
                    case nameof(PartOfDay.Evening):
                        Console.WriteLine("Evening – 6:00 PM (Quinoa porridge)");
                        break;
                    case nameof(PartOfDay.Midnight):
                        Console.WriteLine("Midnight – 9:00 PM (Green tea)");
                        break;
                    default:
                        Console.WriteLine("Something wrong! Try to change your data!");
                        flag = false;
                        break;
                }
                if (!flag) continue;
                else
                {
                    Console.WriteLine("Do you wanna stop or contnue? (0 for stop, anything for continue) : ");
                    string opr = Console.ReadLine();
                    if (opr == "0") break;
                    else continue;
                }
            }

        }
    }
}
