using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_349_intersection_of_two_arrays
{
    /// <summary>
    /// Leetcode 349 - intersection of two arrays
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int[] Intersection(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums2 == null)
                return new int[0];

            var hashset = new HashSet<int>(nums2);

            var duplicate = new List<int>();

            for(int i = 0; i < nums1.Length; i++)
            {
                var current = nums1[i];
                if (hashset.Contains(current))
                {
                    duplicate.Add(current);
                    hashset.Remove(current);  // one element only will be saved once. 
                }
            }

            return duplicate.ToArray(); 
        }
    }
}
