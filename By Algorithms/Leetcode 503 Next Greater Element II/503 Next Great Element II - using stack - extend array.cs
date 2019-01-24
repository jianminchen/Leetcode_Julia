using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _503_next_great_element_II___stack_technique
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = NextGreaterElements(new int[] { 1, 2, 1 });
        }

        /// <summary>
        /// study code
        /// https://leetcode.com/problems/next-greater-element-ii/discuss/98273/Java-10-lines-and-C%2B%2B-12-lines-linear-time-complexity-O(n)-with-explanation
        /// the design ideas:
        /// every node in the array will be pushed into stack once; Since we like to find larger element for all those nodes;        /// 
        /// all nodes in the array with double size will be considered as next larger element once for the small;
        /// array starts from left to right. 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static int[] NextGreaterElements(int[] numbers) {
            if (numbers == null || numbers.Length == 0)
            {
                return new int[0];
            }

            int n = numbers.Length;

            var next = new int[n];
            for (int i = 0; i < n; i++)
            {
                next[i] = -1;
            }

            var stack = new Stack<int>();
            
            for (int i = 0; i < n * 2; i++) 
            {
                // double the size of the array 
                int num = numbers[i % n]; // n -> 0, n + 1 -> 1, ...

                while (stack.Count > 0 && numbers[stack.Peek()] < num)
                {
                    next[stack.Pop()] = num;
                }

                if (i < n)
                {
                    stack.Push(i);
                }
            }   

            return next;
        }
    }
}
