using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpGame
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             * Leetcode: Jump game 
             * Test case 1: 
             */
            int[] A = { 2, 3, 1, 1, 4 };         

            bool result = jump_DP(A);

            int val = jumpGameII_A(A, 5);

            bool res = canJumpG1_B(A, 5);

            int steps = jumpGameII_C(A, 5);

            int steps_2 = jumpGameII_D(A);

            int steps_3 = jumpGameII_E(A);
        }


        /**
         * Latest update: June 30, 2015
         * Leetcode: 
         * Given an array of non-negative integers, you are initially positioned 
         * at the first index of the array.

         * Each element in the array represents your maximum jump length at that position.
         * Your goal is to reach the last index in the minimum number of jumps.
         * 
         * Dynamic programming
         * Source code from the web blog:
         * http://www.cnblogs.com/lichen782/p/leetcode_Jump_Game_II.html
         * Problems: Could not pass leetcode online judge 
         * Action items:
         * 
         * Test case: 
         * Hard to figure out this DP program, debug through the code and see the steps: 
         * Let us walk through the test case: 
         * maximum jump length: 
         * { 2, 3, 1, 1, 4 }
         * and then, calculate the distance array:
         * {2,1,2,1,0}, as you read through the code, using backward direction, initialize 
         * <--------- this is the way, 
         * initialize {Int16.MaxValue, Int16.MaxValue, Int16.MaxValue, Int16.MaxValue, 0}
         * One more step to understand the minimum steps to the last index:
         * go from 1 step to maximum jump, keep the minimum one if it can reach the last index.  
         * For example:
         *   second number in the array maximum jump is 3
         *   jump  1 step, to the third element, 1+ d[2] = 3
         *   jump  2 steps, to the fourth element, 1+ d[3] = 2
         *   jump  3 steps, to the fifth element,  1+ d[4] = 1, 
         *   so 1 is mimum one in the choices of 1, 2, 3, and keep it as d[1], d[1] = 1
         * and To array, 
         * {1,4,3,4,0}, as you understand, first one, jump 1 step to second
         * 
         * Minimum steps expressed in d array
         * Action item: 
         * time analysis O(N) x uncertain number m (m is related to jumps of each element)
         *  
         * 
         */
        public static bool jump_DP(int[] nums) {
              int len = nums.Length;

              if (len < 2) return false;

              int[] dist = new int[len];
              int[] to = new int[len];

              for (int i = 0; i < len; i++)
              {
                   dist[i] = Int16.MaxValue;
              }

              // last index is 0 jump away - already there. 
              dist[len - 1] = 0;

              // build the dist array in backward direction
              for (int i = len - 2; i >= 0; i--)
              {
                  int minDist = Int16.MaxValue;

                  for(int j = 1; j <= nums[i] ; j++){
                      // too many steps, no need 
                      if (i + j >= len) break; 

                      // From current index i to next one, i+j by jumping j steps first. 
                      int nextStop = i + j;

                      // And then, to last index, just dist[nextIdx] + 1; which is DP formula
                      // need to keep the minimum one
                      if(nextStop < len){
                          int jumpsNeed = dist[nextStop] + 1;

                          if(jumpsNeed < minDist){
                              minDist = jumpsNeed;
                              to[i] = nextStop;
                          }
                      }
                  }

                  dist[i] = minDist;
              }

              if (dist[0] == Int16.MaxValue) return false;
              else return true;                
        }

        /**
         * Latest update: June 30, 2015 
         * Jump Game
         * 
         * O(n) solution 
         * Greedy algorithm
         * http://www.cnblogs.com/lichen782/p/leetcode_Jump_Game_II.html
         * The comment by the blog:
         * * We use "last" to keep track of the maximum distance that has been reached
         * by using the minimum steps "ret", whereas "curr" is the maximum distance
         * that can be reached by using "ret+1" steps. Thus,
         * curr = max(i+A[i]) where 0 <= i <= last.
         * 
         * Julia's commment: 
         * 
         * 
         */
        public static int jumpGameII_A(int[] A, int n) {
            int ret = 0;
            int last = 0;
            int curr = 0;

            for (int i = 0; i < n; ++i) {
                if (i > last) {
                    last = curr;
                    ++ret;
                }
                curr = Math.Max(curr, i+A[i]);
            }

            return ret;
        }

        /**
         * Latest update: 
         * June 30, 2015 
         * Leetcode: Jump Game 1 
         * http://bangbingsyb.blogspot.ca/2014/11/leetcode-jump-game-i-ii.html
         * 
         * comment in English in the above blog:
         * Note that A[i] is at the position i, maximum jump distance, not only option; Using greedy solution, 
         * record the maximum distance as maxIndex
         * 
         * 1. the condition to jump to i：i<=maxIndex。
           2. once it is in the position of i, then, maxIndex = max(maxIndex, i+A[i])。
           3. the condition to reach last index：maxIndex >= n-1
         * Julia's comment: 
         * For this case, the greedy algorithm is also optimal solution. 
         */
        public static bool CanJump1_1(int[] nums)
        {
            return canJumpG1_B(nums, nums.Length); 
        }
        public static bool canJumpG1_B(int[] A, int n) {
            int maxIndex = 0;

            for(int i=0; i<n; i++) {
                if(i>maxIndex || maxIndex>=(n-1)) 
                    break;

                maxIndex = Math.Max(maxIndex, i+A[i]);
            } 

            return maxIndex>=(n-1) ? true : false;
        }

        /**
         * Latest update: June 30, 2015
         * Jump game 2 
         * copy the blog:
         * http://bangbingsyb.blogspot.ca/2014/11/leetcode-jump-game-i-ii.html
         * comment in English: 
         * Using greedy method. In Jump Game I question,           
         * for each i, calculate the maximum distance from A[0:i]; 
         * whereas, in Jump Game II, calculate maximum distance after k jumps
         * 
            d[k] = max(i+A[i])     d[k-2] < i <= d[k-1]
         * 
         * Julia's comment: 
         * Let us work out the solution with an example:
         * A = { 2, 3, 1, 1, 4 }
         * d[k] array
         * i=0, A[0], first jump, curMax = 2
         * what is the loop? as long as curMax < last index n-1, continue the process. 
         * next jump, how far it can reach? In other words, what is curMax? 
         * continue on i to the area reached index, find the maximum. 
         * First step into while, 
         * curMax = 0+A[0]=2, increment jump by one; i=0
         * Second step into while, 
         *  for loop,  check i=1, i=2, curMax = max(1+A[1], 2+A[2]) = max(4, 3) = 4
         *  Debug through the code, make sure the understanding is correct. 
         *  
         *  Problems: 
         *  1. this is while loop makes difficult to read, what actually loop through
         *  2. i variable in the for loop, actually it continues in different while steps; 
         *  kind of trick to know what really looping is this i. 
         * 
         */
        public static int jumpGameII_C(int[] A, int n) {

            int curMax = 0, njumps = 0, i = 0;

            while (curMax < n-1) {
                int lastMax = curMax;
                
                for(; i<=lastMax; i++) 
                    curMax = Math.Max(curMax,i+A[i]);

                njumps++;
                if(lastMax == curMax) return -1;
            }

            return njumps;
        }

        /**
         * Latest update: 
         * June 30, 2015
         * http://blog.csdn.net/linhuanmars/article/details/21356187
         * Leetcode: jump game II
         * version D: 
         * 
         * 
         */
        public static int jumpGameII_D(int[] A)
        {
            int len = A.Length; 

            if (A == null || A.Length == 0)
                return 0;
            int lastReach = 0;
            int reach = 0;
            int step = 0;

            for (int i = 0; i <= reach && i < len; i++)
            {
                if (i > lastReach)
                {
                    step++;
                    lastReach = reach;
                }
                reach = Math.Max(reach, A[i] + i);
            }

            if (reach < len - 1)
                return 0;

            return step;
        }
        /*
         * Latest update: June 30, 2015
         * Leetcode: jump game II
        http://segmentfault.com/a/1190000002651263
         * comment from the above blog:
         * 比较典型的贪心。维护一个区间，区间表示第i步所能到达的索引范围。
         * 递推的方法为：每次都遍历一遍当前区间内的所有元素，从一个元素出
         * 发的最远可达距离是index+array[index]，那么下一个区间的左端点
         * 就是当前区间的右端点+1，下一个区间的右端点就是当前区间的
         * max(index+array[index])，以此类推，直到区间包含了终点，
         * 统计当前步数即可。
         * Julia's comment: 
         * In English, the recursive method:
         * Every time, go through each node in the current range; 
         * Maximum reachable is index+array[index], 
         * next range [left, right], left is from current range right + 1, 
         * right is determined by max(index + array[index])
         * until the last index is included. Count the jumps. 
         * 
         * Best code in my opinion - best understandable 
         * Go over the example: { 2, 3, 1, 1, 4 }
         * First range, [0, 2], 
         * next range, [3, 4], but last index is 4; so reach last index
         * */
        public static int jumpGameII_E(int[] A)
        {
            int len = A.Length; 

            if (len == 1)
                return 0;

            int max = 0, count = 1, begin = 0, end = A[0];
            while (end < len - 1)
            {
                count++;
                int index = begin;
                for (; index <= end; index++)
                {
                    max = Math.Max(max, index + A[index]);
                }
                begin = index;
                end = max;
            }
            return count;
        }
    }
}
