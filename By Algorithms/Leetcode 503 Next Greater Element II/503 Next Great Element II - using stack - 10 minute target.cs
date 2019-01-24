using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _503_next_larger_element_II___practice
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = NextGreaterElements(new int[]{1, 2, 1});
        }

        /// <summary>
        /// I wrote the solution by myself this time. 
        /// Here are the ideas to come out a working solution. 
        /// step 1: extend the array to 2 * length size; use module calculation;
        /// step 2: every node in the array will be pushed into stack once; Since 
        /// we like to find larger element for all those nodes;        
        /// step 3: all nodes in the array with double size will be considered as 
        /// next larger element once for the small;
        /// array starts from left to right. 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static int[] NextGreaterElements(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return new int[0];
            }

            var length = numbers.Length;
            var result = new int[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = -1; 
            }

            var stack = new Stack<int>();

            for (int i = 0; i < 2 * length; i++)
            {
                var larger = numbers[i % length]; // remember the range of array 

                while (stack.Count > 0 && numbers[stack.Peek()] < larger)
                {
                    result[stack.Pop()] = larger;
                }

                // all nodes will be pushed into stack once
                if (i < length)
                {
                    stack.Push(i);
                }
            }

            return result; 
        }
    }
}
