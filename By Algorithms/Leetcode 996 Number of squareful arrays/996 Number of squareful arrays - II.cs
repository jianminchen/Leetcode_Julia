using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _996_number_of_squareful_arrays_II
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = NumSquarefulPerms(new int[]{2,2,2});
        }

        /// <summary>
        /// study code based on 
        /// http://anothercasualcoder.blogspot.com/2019/02/hard-leetcode-problem-number-of.html
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static int NumSquarefulPerms(int[] numbers)
        {
            var squares = getAllSquare(numbers);
           
            int num = 0;
            NumSquarefulPerms(numbers, 0, -1, new HashSet<int>(), squares, ref num);
            return num;
        }

        private static HashSet<int> getAllSquare(int[] numbers)
        {
            var squares = new HashSet<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    var sum = numbers[i] + numbers[j];

                    var sqrt = (int)Math.Sqrt(sum);
                    if (sqrt * sqrt == sum)
                    {
                        squares.Add(sum);
                    }
                }
            }

            return squares;
        }

        /// <summary>
        /// code review on 2019-02-27
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="index"></param>
        /// <param name="previousVal"></param>
        /// <param name="usedIndex"></param>
        /// <param name="squares"></param>
        /// <param name="num"></param>
        private static void NumSquarefulPerms(
            int[] numbers,
            int   index,
            int   previousVal,
            HashSet<int> usedIndex,
            HashSet<int> squares,
            ref int num)
        {
            if (index >= numbers.Length)
            {
                num++;
                return;
            }

            var forLoopVisitedNumbers = new HashSet<int>();

            // forLoopVisitedNumbers is to avoid duplication count. For example, [2,2,2]
            // only one of 2s will start for loop. 
            for (int i = 0; i < numbers.Length; i++)
            {
                var current = numbers[i];

                var sum = previousVal + current;

                /*let us write conditions here
                  1. current value is not visited before. 
                     For example, [2, 2, 2], only start once using 2. Not three times.
                  2. index i is not used before
                  3. either the index is 0 or 
                     current value and previous value's sum is squareful                
                 */

                if (!forLoopVisitedNumbers.Contains(current) &&
                    !usedIndex.Contains(i)        &&
                   (index == 0 || squares.Contains(sum)))
                {
                    forLoopVisitedNumbers.Add(current);

                    usedIndex.Add(i);

                    NumSquarefulPerms(numbers, index + 1, current, usedIndex, squares, ref num);
                    //backtracking 
                    usedIndex.Remove(i);
                }
            }
        }
    }
}
