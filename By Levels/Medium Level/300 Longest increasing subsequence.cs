using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _300_longest_increasing_subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int LengthOfLIS(int[] nums)
        {
            int size = nums.Length;

            if (size == 0)
            {
                return 0;
            }

            var subsequence = new int[size];

            int length = 1;
            for (int i = 0; i < size; ++i)
            {
                var current = nums[i];
                subsequence[i] = 1;

                // get maximum value from all options
                for (int j = 0; j < i; ++j)
                {
                    var visit = nums[j];
                    if (visit < current)
                    {
                        subsequence[i] = Math.Max(subsequence[i], subsequence[j] + 1);
                    }
                }

                // update the length if need
                length = Math.Max(length, subsequence[i]);
            }

            return length;
        }
    }
}
