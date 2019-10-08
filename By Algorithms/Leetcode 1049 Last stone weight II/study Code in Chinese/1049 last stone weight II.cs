using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1049_last_stone_weight_II
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = LastStoneWeightII(new int[] {2, 7, 4, 1, 8, 1 });
        }

        /// <summary>
        /// study code
        /// https://www.acwing.com/solution/LeetCode/content/2139/
        /// I like to read comment written in Chinese. I like to write good comment like this 
        /// as well one day. 
        /// (动态规划) O(n×sum)
        /// 合并的过程就是给每个重量前赋值正号或者负号的过程，相当于把这些石头分为两组，
        /// 使得两组的差值尽可能小，所以这是经典的集合划分NP完全问题，可以采用动态规划的方法求解。
        /// 设状态 f(i) 表示是否存在一个划分，使得某组的重量综合为 i。
        /// 初始时 f(0)=true，其余为 false。
        /// 转移时，模仿01背包的算法，对于每个物品，有放和不放两种决策，故 
        /// f(j)=f(j)|f(j−stones[j])。
        /// 最终答案需要枚举，j 从 sum/2 开始到 0，如果 f(j)==true，则返回 sum−j−j。
        /// 时间复杂度
        /// 状态数为 O(n×sum)，转移数为常数，故时间复杂度为 O(n×sum)。
        /// 空间复杂度
        /// 需要额外 O(n) 的空间构造堆。
        /// </summary>
        /// <param name="stones"></param>
        /// <returns></returns>
        public static int LastStoneWeightII(int[] stones)
        {
            var length = stones.Length;
            var sum = stones.Sum();

            var found = new bool[sum + 1];  // not length + 1
            found[0] = true;

            // transition formula - figure out the reasoning later
            for (int i = 0; i < length; i++)
            {
                var current = stones[i];
                for (int j = sum / 2; j >= current; j--)
                {
                    found[j] = found[j] | found[j - current];
                }
            }

            // Find maximum sum less and equal to sum/2. 
            for (int i = sum / 2; i >= 0; i--)
            {
                if (found[i])
                {
                    return sum - i - i; 
                }
            }

            return sum; 
        }
    }
}
