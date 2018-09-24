using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_278_First_bad_version
{
    /// <summary>
    /// Leetcode 278 First bad version
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// isBadVersion()
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FirstBadVersion(int n)
        {
            if (n <= 0)
                return -1; 

            // find lowest index which is bad version
            var start = 1;
            var end = n; 
            while(start <= end)
            {
                var middle = start + (end - start) / 2;
                var middleIsBad = IsBadVersion(middle);

                if (middleIsBad)
                {
                    if(middle == 1 || !IsBadVersion(middle - 1))
                    {
                        return middle; 
                    }
                    else 
                    {
                        end = middle - 1;
                    }
                }
                else
                {
                    start = middle + 1; 
                }
            }

            return -1; 
        }
    }
}
