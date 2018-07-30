using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_202_Happy_number
{
    /// <summary>
    /// Leetcode 202 
    /// Happy number
    /// https://leetcode.com/problems/happy-number/description/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var result = IsHappy(19);
        }

        public static bool IsHappy(int n)
        {
            if (n == 1)
                return true;

            var hashSet = new HashSet<int>();

            return isHappyHelper(n, hashSet);
        }

        private static bool isHappyHelper(int n, HashSet<int> hashSet)
        {
            if (n == 1)
                return true;

            if (hashSet.Contains(n))
                return false;

            hashSet.Add(n);

            return isHappyHelper(getSumSquare(n), hashSet);
        }

        /// <summary>
        ///  19
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int getSumSquare(int n)
        {
            // base case
            if (n < 10)
                return n * n;

            var digit = n % 10; // 9

            return getSumSquare(n / 10) + digit * digit; 
        }
    }
}
