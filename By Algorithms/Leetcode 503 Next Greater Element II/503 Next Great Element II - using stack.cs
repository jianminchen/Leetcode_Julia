using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _503_next_great_element_II___using_stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = NextGreaterElements(new int[]{1, 2, 1});
        }

        /// <summary>
        /// study code from the discuss
        /// https://leetcode.com/problems/next-greater-element-ii/discuss/98262/Typical-ways-to-solve-circular-array-problems.-Java-solution
        /// The second way is to use a stack to facilitate the look up. 
        /// First we put all indexes into the stack, smaller index on the top. 
        /// Then we start from end of the array look for the first element 
        /// (index) in the stack which is greater than the current one. That one 
        /// is guaranteed to be the Next Greater Element. Then put the current 
        /// element (index) into the stack.
        /// 
        /// Walk through the test case: {1, 2, 1}
        /// 
        /// Time complexity: O(n).
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static int[] NextGreaterElements(int[] numbers) {
            if (numbers == null || numbers.Length == 0)
            {
                return new int[0];
            }

            int length = numbers.Length;
            var result = new int[length];
        
            var stack = new Stack<int>();

            // put all the elements in the stack
            for (int i = length - 1; i >= 0; i--) {
                stack.Push(i);
            }
        
            for (int i = length - 1; i >= 0; i--) {
                result[i] = -1;

                while (stack.Count > 0 && numbers[stack.Peek()] <= numbers[i]) {
                    stack.Pop();
                }

                if (stack.Count > 0)
                {
                    result[i] = numbers[stack.Peek()];
                }

                stack.Push(i);
            }
        
            return result;
       }
    }
}
