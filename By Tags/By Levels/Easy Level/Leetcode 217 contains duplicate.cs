using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_217_contains_duplicate
{
    public class Solution
    {
        public bool ContainsDuplicate(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return false;

            var visited = new HashSet<int>();

            var length = nums.Length;
            for (int i = 0; i < length; i++)
            {
                var current = nums[i];

                if (visited.Contains(current))
                    return true;
                else
                    visited.Add(current);
            }

            return false;
        }
    }
}
