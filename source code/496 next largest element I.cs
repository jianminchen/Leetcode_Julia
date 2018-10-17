using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _496_next_largest_element_I
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTestcase();
        }

        /// <summary>
        /// I failed the test case in my first submission.
        /// I need to store decreasing numbers in the stack only.
        /// </summary>
        public static void RunTestcase()
        {
            var findNums = new int[] {4, 1, 2 };
            var nums = new int[] {1, 3, 4, 2};

            var result = NextGreaterElement(findNums, nums); 
        }

        /// <summary>
        /// use stack to keep non-decreasing order of numbers in the stack. 
        /// Every time the number is popped out the stack, the next greater element is 
        /// saved in the hashmap. 
        /// </summary>
        /// <param name="findNums"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] NextGreaterElement(int[] findNums, int[] nums)
        {
            if (findNums == null || nums == null)
                return new int[0];

            var map = new Dictionary<int, int>();
            var stack = new Stack<int>();

            foreach (var item in nums)
            {
                while (true)
                {
                    if (stack.Count == 0 || item < stack.Peek())
                    {
                        stack.Push(item);
                        break;
                    }
                    else
                    {
                        var number = stack.Pop();
                        map.Add(number, item); 
                    }
                }
            }

            var length = findNums.Length;
            var nextGreater = new int[length];

            for (int i = 0; i < length; i++)
            {
                nextGreater[i] = -1;
                var current = findNums[i];
                if(map.ContainsKey(current))
                {
                    nextGreater[i] = map[current];
                }
            }

            return nextGreater;
        }
    }
}
