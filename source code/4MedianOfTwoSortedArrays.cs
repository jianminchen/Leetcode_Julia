using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4MedianOfTwoSortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /*
         * source code from blog:
         * http://blog.csdn.net/yutianzuijin/article/details/11499917
         * 
         * http://blog.csdn.net/zxzxy1988/article/details/8587244  
         * 
         * analysis from the above blog:
         * 题目是这样的：给定两个已经排序好的数组（可能为空），找到两者所有元素中
         * 第k大的元素。另外一种更加具体的形式是，找到所有元素的中位数。
         * 本篇文章我们只讨论更加一般性的问题：如何找到两个数组中第k大的元素？
         * 不过，测试是用的两个数组的中位数的题目，Leetcode第4题 Median of Two Sorted Arrays
         * 
            方案1：假设两个数组总共有n个元素，那么显然我们有用O(n)时间和O(n)空间的方法：
         *  用merge sort的思路排序，排序好的数组取出下标为k-1的元素就是我们需要的答案。
            这个方法比较容易想到，但是有没有更好的方法呢？
         * 
            方案2：我们可以发现，现在我们是不需要“排序”这么复杂的操作的，因为我们仅仅需要
         * 第k大的元素。我们可以用一个计数器，记录当前已经找到第m大的元素了。同时我们使用
         * 两个指针pA和pB，分别指向A和B数组的第一个元素。使用类似于merge sort的原理，如果
         * 数组A当前元素小，那么pA++，同时m++。如果数组B当前元素小，那么pB++，同时m++。
         * 最终当m等于k的时候，就得到了我们的答案 — O(k)时间，O(1)空间。
         * 
         * 
           但是，当k很接近于n的时候，这个方法还是很费时间的。当然，我们可以判断一下，如果k
         * 比n/2大的话，我们可以从最大的元素开始找。但是如果我们要找所有元素的中位数呢？时间
         * 还是O(n/2)=O(n)的。有没有更好的方案呢？
         * 
           我们可以考虑从k入手。如果我们每次都能够剔除一个一定在第k大元素之前的元素，那么我们
         * 需要进行k次。但是如果每次我们都剔除一半呢？所以用这种类似于二分的思想，我们可以这样
         * 考虑：
         * 
         * Julia's comment: 
         * 1. Quickly review what we should do in the function
         * step 1: input arguments, two array, 2 length, keep small length array in the first one; 
         *         switch the call if need. - reduce if case discussion
         * step 2: base cases - 
         *         case 1: m==0, kth element is b[k-1]
         *         case 2: k==1, kth element is to compare first element in two sorted array
         * step 3: divide k into two parts, memorize first part of k: minimum (k / 2, m)
         *    2 tips to remember: 
         *       1. first, it should not be bigger than short array length m, 
         *          should be less than k /2 as well. 
         * step 4: need to remove first part of array a or first part of array b,
         *     recall how to make the decision: 
         *     compare, and then, decide: 
         * step 5: recursive call in 3 cases of if statement 
         * 
         * 
         */
        public static double findKth(int[] a, int m, int[] b, int n, int k)
        {
            //always assume that m is equal or smaller than n  
            if (m > n)                              // step 1
                return findKth(b, n, a, m, k);

            if (m == 0)                 // step 2
                return b[k - 1];

            if (k == 1)                 // step 2 
                return Math.Min(a[0], b[0]);

            //divide k into two parts  
            int pa = Math.Min(k / 2, m), pb = k - pa;

            if (a[pa - 1] < b[pb - 1])
            {
                int[] aShift = arrayShift(a, pa);
                return findKth(aShift, m - pa, b, n, k - pa);
            }
            else if (a[pa - 1] > b[pb - 1])
            {
                int[] bShift = arrayShift(b, pb);
                return findKth(a, m, bShift, n - pb, k - pb);
            }
            else
                return a[pa - 1];
        }

        /*
         * a short version of arrayShift in C#
         * 
         */
        public static int[] arrayShift(int[] a, int n)
        {
            int len = a.Length;

            if (n <= len)
            {
                int[] outA = new int[len - n];
                for (int i = 0; i < len - n; i++)
                    outA[i] = a[n + i];

                return outA; 
            }

            return null; 
        }
    }
}
