using System;

namespace Lab15_3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 	включення елемента в дерево;
             * 	видалення елементу з дерева;
             * 	обхід дерева;
             * 	пошук в бінарному дереві.
            */
            Tree<string> ExcelMenu = new Tree<string>();
            ExcelMenu.Insert("0_Menu");
            ExcelMenu.Insert("1_File");
            ExcelMenu.Insert("2_Table");
            ExcelMenu.Insert("1_File save");
            ExcelMenu.Insert("1_File open");
            ExcelMenu.Insert("2_Table create");
            ExcelMenu.Insert("2_Table change");
            ExcelMenu.Print();
            ExcelMenu.Erase("File");
            Console.WriteLine("\n\nNew menu\n");
            ExcelMenu.Print();

            if (ExcelMenu.Find("2_Table"))
            {
                Console.WriteLine("2_Table is avalible here");
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
