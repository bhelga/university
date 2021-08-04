using System;

namespace Lab15_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stack = new Stack<char>();
            string sequence = "(a-3)*(a+3)/(a-1)";
            string result = "";
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == '(')
                {
                    stack.Push(sequence[i]);
                    Console.Write($"({i}, ");
                }
                if (sequence[i] == ')')
                {
                    if (!stack.IsEmpty)
                    {
                        stack.Pop();
                        Console.Write($"{i}) ");
                    }
                    else
                    {
                        result = "\nIncorrect sequence!";
                        break;
                    }
                }
            }
            if (stack.IsEmpty && result == "")
            {
                result = "\nCorrect sequence!";
            }
            else
            {
                result = "\nIncorrect sequence!";
            }
            Console.WriteLine(result);
        }
    }
}
