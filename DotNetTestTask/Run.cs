using System;
using System.Runtime.Serialization;

namespace DotNetTestTask 
{
    internal class Program 
    {
        public static void Main(string[] args) 
        {
            TestListFunc();
        }

        public static void TestListFunc() 
        {
            var list = new List();
            list.insert_at_last(1);
            list.insert_at_last(2);
            list.print_info();
            list.insert_in_place(5, 3);
            list.print_info();
            list.delete_in_place(1);
            list.print_info();
            list.ReverseList();
            list.print_info();
            list.DeleteLast();
            list.print_info();
        }

        public static void TestBinaryTree() 
        {
            var tree = new BinaryTree();
            tree.add(1);
            tree.add(2);
            tree.add(3);
            tree.add(5);
            tree.add(4);
            tree.add(32);
            tree.print_tree_info();
            tree.Delete(2);
            tree.print_tree_info();
            tree.Delete(5);
            tree.print_tree_info();
        }

        public static void TestInsertionSort() 
        {
            var rand = new Random();
            var arr = new int[40];
            for (var i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(-100, 100);
            }
            
            Console.WriteLine("Before sorting: ");
            foreach (var i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            
            Sort.insertion_sort(arr);
            
            Console.WriteLine("After sorting: ");
            foreach (var i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}