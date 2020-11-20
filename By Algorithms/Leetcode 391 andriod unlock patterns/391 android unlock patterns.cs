using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _391_android_unlock_patterns
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private bool[] used = new bool[9];

        /// <summary>
        /// Nov. 19, 2020
        /// code study
        /// https://leetcode.com/problems/android-unlock-patterns/
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumberOfPatterns(int m, int n) 
        {
            int result = 0;
            for (int length = m; length <= n; length++) 
            {	            
                result += calculatePatterns(-1, length);

                for (int i = 0; i < 9; i++) 
                {	                
                    used[i] = false;
                }            
            }

            return result;
        }

        private bool isValid(int index, int last) 
        {
            if (used[index])
            {
                return false;
            }

            // first digit of the pattern    
            if (last == -1)
            {
                return true;
            }

            // knight moves or adjacent cells (in a row or in a column)	       
            if ((index + last) % 2 == 1)
            {
                return true;
            }

            // indexes are at both end of the diagonals for example 0,0, and 8,8          
            int middle = (index + last)/2;
            if (middle == 4)
            {
                return used[middle];
            }

            // adjacent cells on diagonal  - for example 0, 0 and 1, 0 or 2, 0 and //1,1
            if ((index %3 != last%3) && (index/3 != last/3)) 
            {
                return true;
            }

            // all other cells which are not adjacent
            return used[middle];
        }

        /// <summary>
        /// depth first search - using DFS 
        /// </summary>
        /// <param name="last"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private int calculatePatterns(int last, int length) 
        {
            if (length == 0)
            {
                return 1;
            }

            int sum = 0;
            for (int i = 0; i < 9; i++) 
            {
                if (isValid(i, last)) 
                {
                    used[i] = true;
                    sum    += calculatePatterns(i, length - 1);
                    used[i] = false;                    
                }
            }

            return sum;
        }      
    }
}
