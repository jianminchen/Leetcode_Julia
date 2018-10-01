using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _350_intersection_of_two_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int[] Intersect(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums2 == null)
                return new int[0];

            Array.Sort(nums1);
            Array.Sort(nums2);

            var duplicate = new List<int>();
            int index1 = 0;
            int index2 = 0;

            int length1 = nums1.Length;
            int length2 = nums2.Length;

            while (index1 < length1 && index2 < length2)
            {
                var current1 = nums1[index1];
                var current2 = nums2[index2];
                if (current1 == current2)
                {
                    duplicate.Add(current1);
                    index1++;
                    index2++;
                }
                else if (current1 < current2)
                {
                    index1++;
                }
                else
                {
                    index2++;
                }
            }

            return duplicate.ToArray();
        }
    }
}
