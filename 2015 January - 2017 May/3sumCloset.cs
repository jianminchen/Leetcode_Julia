using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3SumClosest
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /*
         * August 14, 2015 
         * Leetcode: three sum closest 
         */
        /*
         * http://www.programcreek.com/2013/02/leetcode-3sum-closest-java/
         */
        public int threeSumClosest(int[] nums, int target)
        {
            int min = Int32.MaxValue;
            int result = 0;

            //Arrays.sort(nums);
            nums = sortArray(nums);  // work on it later. 

            for (int i = 0; i < nums.Length; i++)
            {
                int j = i + 1;
                int k = nums.Length - 1;

                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    int diff = Math.Abs(sum - target);

                    if (diff == 0) return sum;

                    if (diff < min)
                    {
                        min = diff;
                        result = sum;
                    }

                    if (sum <= target)
                    {
                        j++;
                    }
                    else
                    {
                        k--;
                    }
                }
            }

            return result;
        }

        protected int[] sortArray(int[] num)
        {
            return num; 
        }

    }
}
