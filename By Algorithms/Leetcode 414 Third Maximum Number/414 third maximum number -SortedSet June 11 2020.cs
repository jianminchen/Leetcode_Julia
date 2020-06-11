using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_414_third_maximum_number_SortedSet
{
    class Program
    {
        /// <summary>
        /// code review: June 11, 2020
        /// Make property private - sortedSet
        /// Add four APIs 
        /// 1. Add(int value)
        /// 2. int RemoveMin()
        /// 3. int GetMin()
        /// 4. int GetLast()
        /// 5. int Count()
        /// </summary>
        public class MinHeap
        {
            private SortedSet<int> sortedSet = new SortedSet<int>();

            public void Add(int value)
            {
                sortedSet.Add(value); 
            }

            public int RemoveMin()
            {
                var minimum = sortedSet.First();// O(1) time 

                sortedSet.Remove(minimum); // O(logn) time

                return minimum; 
            }

            public int GetMin()
            {
                return sortedSet.First(); 
            }

            public int GetLast()
            {
                return sortedSet.Last(); 
            }

            public bool Contains(int value)
            {
                return sortedSet.Contains(value); 
            }

            public int Count()
            {
                return sortedSet.Count();
            }
        }

        static void Main(string[] args)
        {
            var result = ThirdMax(new int[] { 2, 2, 3, 1 });
            var result2 = ThirdMax(new int[] { 1, 2, 3, 4, 4, 5, 6, 7, 8, 9, 10 });
            Debug.Assert(result2 == 8);
        }

        /// <summary>
        /// try to use MinHeap - August 15, 2018
        /// Requirement: 
        /// 1. Remove third maximum number;
        /// 2. If total of distinct numbers is less than three, remove maximum number. 
        /// Tips:
        /// 1. Design a minimum heap using C# SortedSet;
        /// 2. If there is less than three distinct numbers in the array, return maximum one;
        /// 3. Always keep minimum heap size on check, make sure that it is less and equal to 3;
        /// 4. More on step 3, if the size of heap is bigger than three, remove minimum one;
        /// 5. Go over all the numbers in the array, put them to heap;
        /// 6. Remove smallest one at the end. 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static int ThirdMax(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                return -1;

            int size = 0; 
            var length = numbers.Length;
            var minimumHeap = new MinHeap();
            var count = 0; 

            for (int i = 0; i < length && size < 3; i++)
            {
                minimumHeap.Add(numbers[i]);
                size = minimumHeap.Count(); // caught by online judge, heap excludes duplicate
                count++; 
            }

            // if the array has less than three distinct number, return maximum one
            if (count == length && size < 3)
            {
                return minimumHeap.GetLast(); 
            }

            for (int i = count; i < length; i++)
            {
                var current = numbers[i];

                // if the current number is in the minimm heap or smaller than minimum value in the heap
                if(minimumHeap.Contains(current) || current < minimumHeap.GetMin())
                {
                    continue; 
                }
               
                minimumHeap.RemoveMin();               
                minimumHeap.Add(current); 
            }

            return minimumHeap.GetMin(); 
        }
    }
}