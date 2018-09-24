using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode277_FindCelebrity
{
    /* Leetcode 277: find celebrity
     * 
     * Suppose you are at a party with n people (labeled from 0 to n - 1) and among them, 
     * there may exist one celebrity. The definition of a celebrity is that all the other 
     * n - 1 people know him/her but he/she does not know any of them.

       Now you want to find out who the celebrity is or verify that there is not one. The 
     * only thing you are allowed to do is to ask questions like: "Hi, A. Do you know B?" 
     * to get information of whether A knows B. You need to find out the celebrity (or 
     * verify there is not one) by asking as few questions as possible (in the asymptotic 
     * sense).

       You are given a helper function bool knows(a, b) which tells you whether A knows B. 
     * Implement a function int findCelebrity(n), your function should minimize the number 
     * of calls to knows.

     Note: There will be exactly one celebrity if he/she is in the party. Return the celebrity's 
     * label if there is a celebrity in the party. If there is no celebrity, return -1.
     * 
     * source code is based on
     * http://www.cnblogs.com/grandyang/p/5310649.html
     */
    class Program
    {
        static void Main(string[] args)
        {
            var celebrity = FindCelebrity(100);
        }

        /// <summary>
        /// my job is to find O(N) solution, N is number of candidates
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int FindCelebrity(int n)
        {
            if (n <= 0)
            {
                return -1;
            }

            for (int i = 0, j = 0; i < n; ++i)
            {
                for (j = 0; j < n; ++j)
                {
                    if (i != j && (knows(i, j) || !knows(j, i))) break;
                }

                if (j == n) return i;
            }

            return -1;            
        }

        /// <summary>
        /// assume that there are more than 10 people, and make 10th people as a celebrity.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static bool knows(int a, int b)
        {
            if (a == b)
                return true;

            if (a == 10)
                return false;

            return true; // false
        }
    }
}
