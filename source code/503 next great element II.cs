using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _503_next_great_element_II
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = NextGreaterElements(new int[]{1, 5, 3, 6, 8}); 
        }

        /// <summary>
        /// test case 1:
        /// [1, 2, 3]
        /// -> reverse [3, 2, 1] -> ok
        /// test case 2:
        /// [4, 2, 3]
        /// -> reverse [3, 2, 4] 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static int[] NextGreaterElements(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                return new int[0];

            var length = numbers.Length;
            var copy = new int[length];

            Array.Copy(numbers, copy, length);

            Array.Reverse(numbers); // [3, 2,1]            

            var nextGreater      = new int[length];
            var nextGreaterFound = new bool[length];

            for (int i = 0; i < length; i++)
                nextGreater[i] = -1;

            var stack = new Stack<int>();

            for (int i = 0; i < length; i++)
            {
                if (i == 0)
                {
                    stack.Push(i); // 0
                    continue; 
                }

                var current = numbers[i]; // 2
                var top = stack.Peek();                 

                while (stack.Count > 0 && numbers[stack.Peek()] <= current)
                {                                        
                    stack.Pop();                    
                }

                if (stack.Count > 0)
                {
                    nextGreater[i] = numbers[stack.Peek()];
                    nextGreaterFound[i] = true;
                }

                stack.Push(i); 
            }
            
            Array.Reverse(nextGreater);
            Array.Reverse(nextGreaterFound);

            // iterate from left to right - O(N) - get maximum from left side
            int start = 0; 
            for (int i = 0; i < length; i++)
            {               
                var reverse = length - 1 - i;
                if (nextGreaterFound[reverse])
                    continue;

                while (start < reverse)
                {
                    if (start < reverse && copy[start] > copy[reverse])
                    {
                        nextGreater[reverse] = copy[start];                        
                        break;
                    }

                    start++;
                }                
            }

            return nextGreater;
        }
    }
}
