using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11ContainerWithMostWater
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /*
         * source code from blog:
         * 
         * http://www.cnblogs.com/TenosDoIt/p/3812880.html
         * 
         * comment from blog: 
         * 
         * 
         * julia's comment:
         * 1. There are 3 algorithms discussed in the blog; excellent. 
         * 
         */
        // 算法1：枚举容器的两个边界，时间复杂度O（n^2）。大数据超时 
        public static int maxArea(int[] height)
        {
            int res = 0,
                n = height.Length;

            for (int i = 0; i < n; i++)       //左边界
                for (int j = i + 1; j < n; j++) //右边界
                {
                    int tmp = (j - i) * Math.Min(height[i], height[j]);
                    if (res < tmp)
                        res = tmp;
                }
            return res;
        }

        /* 对上面的稍加改进，根据当前的已经计算出来的结果以及左边界的值，
         * 可以算出容器右边界的下界。不过还是超时
         */
        int maxArea_2(int[] height) {
            int res = 0, n = height.Length;

            for(int i = 0; i < n; i++)  //左边界
            {
                if(height[i] == 0)
                    continue;

                int extraI = res / height[i];   // the minimum span of window
                int betterStart = Math.Max(i + 1, extraI + i);   
                for (int j = betterStart; j < n; j++) //右边界
                {
                    int tmp = (j-i)*Math.Min(height[i],height[j]);
                    if(res < tmp)
                        res = tmp;
                }
            }
            return res;
        }
        /*
         * source code from blog:
         * http://www.cnblogs.com/TenosDoIt/p/3812880.html
            算法3：时间复杂度O（n），两个指针i, j分别从前后向中间移动，两个指针分别表示容器的
         *  左右边界。每次迭代用当前的容量更新最大容量，然后把高度小的边界对应的指针往中间移动一位。
         * */
        /*正确性证明：由于水的容量是有较小的那个边界决定的，因此某次迭代中，假设height[i] < height[j]，
         * 那么j 减小肯定不会使水的容量增大，只有i 增加才有可能使水的容量增大。但是会不会有这种可能：
         * 当前的i 和 某个k (k > j)是最大容量, 这也是不可能的，因为按照我们的移动规则，既然右指针从k 
         * 移动到了j，说明i 的左边一定存在一个边界 m，使m > k，那么[m, k]的容量肯定大于[i, k]，所以
         * [i,k]不可能是最大容量。
         * 
         * julia's comment:
         * 1. quick to read blog:
         * https://leetcode.com/discuss/1074/anyone-who-has-a-o-n-algorithm
         * 2. Understand the problem in detail later. 
         */
        int maxArea_3(int[] height) {
            int res = 0, 
                n = height.Length;

            int left = 0, right = n-1;
            while(left < right)
            {
                int shortOne = Math.Min(height[left], height[right]);
                int width = (right - left); 
                int volume = shortOne * width; 

                res = Math.Max(res, volume);

                if(height[left] < height[right])
                    left++;
                else right--;
            }
            return res;
        }
    }
}
