using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_88_Merge_Sorted_array
{
    /// <summary>
    /// Leetcode 88 - merge sorted array
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// merge two sorted array
        /// assume that nums1 has enough space for merged array
        /// design: use two scan from right to left, and then 
        /// put the maximum value first in the nums1
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (nums1 == null || nums2 == null)
                return;

            var length = m + n;

            var end1 = m - 1;
            var end2 = n - 1;

            var index = length - 1;
            while(index >= 0)
            {
                var moveFirst = false;
                if (end1 < 0)
                {
                    moveFirst = false;
                }
                else if (end2 < 0)
                {
                    moveFirst = true;
                }
                else
                {
                    var current1 = nums1[end1];
                    var current2 = nums2[end2];
                    moveFirst = current1 > current2;
                }

                if (moveFirst)
                {
                    nums1[index] = nums1[end1];
                    end1--;
                }
                else
                {
                    nums1[index] = nums2[end2];
                    end2--;
                }

                index--;
            }
        }
    }
}
