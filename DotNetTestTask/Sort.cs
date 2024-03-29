﻿using System;

namespace DotNetTestTask 
{
    public class Sort 
    {
        private static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
        public static void insertion_sort<T>(T[] array) where T : IComparable<T> 
        {
            uint i = 1;
            while (i < array.Length)
            {
                var j = i;
                while (j > 0 && array[j - 1].CompareTo(array[j]) > 0)
                {
                    Swap(ref array[j], ref array[j - 1]);
                    j--;
                }
                i++;
            }
        }
    }
}