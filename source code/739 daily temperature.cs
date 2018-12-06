using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _739_daily_temperature
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTestcase(); 
        }

        /// T = [73, 74, 75, 71, 69, 72, 76, 73]
        /// your output should be [1, 1, 4, 2, 1, 1, 0, 0]
        public static void RunTestcase()
        {
            var result = DailyTemperatures(new int[] { 73, 74, 75, 71, 69, 72, 76, 73 }); 
        }

        /// <summary>
        /// Use stack to implement the solution with time complexity O(N), N is the size of the array
        /// </summary>
        /// <param name="T"></param>
        /// <returns></returns>
        public static int[] DailyTemperatures(int[] T)
        {
            if (T == null || T.Length == 0)
                return new int[0];

            var stack = new Stack<int>(); 

            var length = T.Length;
            var nextBigger = new int[length];

            stack.Push(0);
            int index = 1; 
            while (stack.Count > 0)
            {
                var peek = stack.Peek();

                if (index >= length)
                {
                    break;
                }

                if (index < length)
                {
                    if (T[index] > T[peek])
                    {
                        nextBigger[peek] = index - peek;
                        stack.Pop();

                        if (stack.Count == 0)
                        {
                            stack.Push(index);
                            index++;
                        }
                    }
                    else
                    {
                        stack.Push(index);
                        index++;
                    }
                }                
            }

            return nextBigger;
        }
    }
}
