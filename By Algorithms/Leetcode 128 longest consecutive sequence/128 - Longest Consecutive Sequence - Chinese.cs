using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode128_LongestConsecutiveSequence
{
    /// <summary>
    /// Feb. 13, 2018
    /// study code:
    /// http://blog.csdn.net/linhuanmars/article/details/22964467
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Please refer to my blog:
        /// http://juliachencoding.blogspot.com/2018/02/leetcode-128-longest-consecutive.html
        /// Use graph idea. How to understand the idea of the algorithm?
        /// 如果要达到好的时间复杂度，还得从图的角度来考虑。思路是把这些数字看成图的顶点，
        /// 而边就是他相邻的数字，然后进行深度优先搜索。通俗一点说就是先把数字放到一个
        /// 集合中，拿到一个数字，就往其两边搜索，得到包含这个数字的最长串，并且把用过的
        /// 数字从集合中移除（因为连续的关系，一个数字不会出现在两个串中）。最后比较当前
        /// 串是不是比当前最大串要长，是则更新。如此继续直到集合为空。如果我们用HashSet
        /// 来存储数字，则可以认为访问时间是常量的，那么算法需要一次扫描来建立集合，第二
        /// 次扫描来找出最长串，
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public int longestConsecutive(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return 0;
            }

            var set = new HashSet<int>(numbers);
            int maximumLength = 1;

            while (set.Count > 0)
            {
                var enumerator = set.GetEnumerator();
                var item = enumerator.Current;

                set.Remove(item);

                int currentLength = 1;
                int smaller = item - 1;

                // search consecutive numbers smaller than current
                while (set.Contains(smaller))
                {
                    set.Remove(smaller--);
                    currentLength++;
                }

                // search consecutive numbers bigger than current
                smaller = item + 1;
                while (set.Contains(smaller))
                {
                    set.Remove(smaller++);
                    currentLength++;
                }

                if (currentLength > maximumLength)
                {
                    maximumLength = currentLength;
                }
            }

            return maximumLength;
        }
    }
}