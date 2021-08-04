using System;
using System.Collections.Generic;
using System.Text;

namespace Lab15_3
{
    class Tree<T>
    {
        public static bool Compare(T a, T b, int res)
        {
            Comparer<T> comparer = Comparer<T>.Default;
            return comparer.Compare(a, b) == res ? true : false;
        }
        public static bool IsBiggerThan(T a, T b) { return Compare(a, b, 1); }

        public static bool IsEqualTo(T a, T b) { return Compare(a, b, 0); }

        public static bool IsLessThan(T a, T b) { return Compare(a, b, -1); }
        public class TreeNode<T>
        {
            public T value { get; set; }
            public TreeNode<T> left { get; set; }
            public TreeNode<T> right { get; set; }

            public TreeNode()
            {
            }

            public TreeNode(T value, TreeNode<T> left, TreeNode<T> right)
            {
                this.value = value;
                this.left = left;
                this.right = right;
            }

            public TreeNode(T value)
            {
                this.value = value;
                this.left = null;
                this.right = null;
            }
            public static bool Compare(T a, T b, int res)
            {
                Comparer<T> comparer = Comparer<T>.Default;
                return comparer.Compare(a, b) == res ? true : false;
            }

            public static bool IsBiggerThan(T a, T b) { return Compare(a, b, 1); }

            public static bool IsEqualTo(T a, T b) { return Compare(a, b, 0); }

            public static bool IsLessThan(T a, T b) { return Compare(a, b, -1); }
        }
        public TreeNode<T> root;
        public int size;

        public Tree(TreeNode<T> root)
        {
            this.root = root;
            this.size++;
        }

        public Tree()
        {
        }

        public void Insert(T key)
        {
            TreeNode<T> current = root;
            if (root == null)
            {
                root = new TreeNode<T>(key);
                size++;
                return;
            }
            while (current != null && !current.value.Equals(key))
            {
                if (IsBiggerThan(current.value, key) && current.left == null)
                {
                    current.left = new TreeNode<T>(key);
                    size++;
                    return;
                }
                if (IsLessThan(current.value, key) && current.right == null)
                {
                    current.right = new TreeNode<T>(key);
                    size++;
                    return;
                }
                if (IsBiggerThan(current.value, key))
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }
            }
        }
        public void Erase(T key)
        {
            TreeNode<T> current = root;
            TreeNode<T> parent = null;
            while (current != null && !current.value.Equals(key))
            {
                parent = current;
                if (IsBiggerThan(current.value, key))
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }
            }
            if (current == null)
                return;
            if (current.left == null)
            {
                if (parent != null && parent.left.Equals(current))
                {
                    parent.left = current.right;
                }
                if (parent != null && parent.right.Equals(current))
                {
                    parent.right = current.left;
                }
                size--;
                return;
            }
            TreeNode<T> replace = current.right;
            while (replace.left != null)
            {
                replace = replace.left;
            }
            T replaceValue = replace.value;
            Erase(replaceValue);
            current.value = replaceValue;
        }
        public void Print()
        {
            PrintTree(root);
            Console.WriteLine();
        }
        private void PrintTree(TreeNode<T> current)
        {
            if (current != null)
            {
                PrintTree(current.left);
                Console.WriteLine(current.value + " ");
                PrintTree(current.right);
            }
        }
        public bool Find(T key)
        {
            TreeNode<T> current = root;
            while (current != null && !current.value.Equals(key))
            {
                if (IsBiggerThan(current.value, key))
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }
            }
            return current != null;
        }
    }
}
