using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _996_number_of_squared_arrays_III
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = NumSquarefulPerms(new int[]{2, 2, 2});
        }

        public static int count = 0;

        public static int NumSquarefulPerms(int[] numbers)
        {
            if (numbers.Length == 0) 
            {
                return 0;
            }

            Array.Sort(numbers);
            var used = new bool[numbers.Length];

            count = 0; 
            backtracking(numbers, used, new List<int>());

            return count;
        }

        /// <summary>
        /// code is written based on Java code in the following:
        /// https://leetcode.com/problems/number-of-squareful-arrays/discuss/238658/Java-Backtracking-similar-to-Permutations-II
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="used"></param>
        /// <param name="list"></param>
        private static void backtracking(int[] numbers, bool[] used, List<int> list) 
        {
            if (list.Count == numbers.Length) {
                count ++;                

                return;
            }

            for (int i = 0; i < numbers.Length; i ++) 
            {
                // avoid duplicate count - numbers are sorted
                if (used[i] || (i - 1 >= 0 && numbers[i] == numbers[i - 1] && !used[i - 1]))
                {
                    continue;
                }

                if (list.Count == 0 || isSquare(list[list.Count - 1] + numbers[i])) 
                {
                    list.Add(numbers[i]);
                    used[i] = true;

                    backtracking(numbers, used, list);
                    
                    list.RemoveAt(list.Count - 1); // RemoveAt not Remove API

                    used[i] = false;
                }
            }
        }

        private static bool isSquare(int x) 
        {
            double r = Math.Sqrt(x);

            if ((r - Math.Floor(r)) == 0) 
            {
                return true;
            }

            return false;
        }
    }
}
