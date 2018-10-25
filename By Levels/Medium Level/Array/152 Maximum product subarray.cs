using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _152_Maximum_product_subarray
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int MaxProduct(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int maxProduct = nums[0];
            int max_local = nums[0];
            int min_local = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                int a = nums[i] * max_local;
                int b = nums[i] * min_local;

                max_local = Math.Max(Math.Max(a, b), nums[i]);
                min_local = Math.Min(Math.Min(a, b), nums[i]);

                maxProduct = Math.Max(maxProduct, max_local);
            }

            return maxProduct;
        }
    }
}
