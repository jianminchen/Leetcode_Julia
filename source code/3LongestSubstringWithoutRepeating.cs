using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3LongestSubstringWithoutRepeating
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /*
         * source code from blog:
         * http://blog.csdn.net/linhuanmars/article/details/19949159
         * analysis from blog:
         * 首先brute force的时间复杂度是O(n^3), 对每个substring都看看
         * 是不是有重复的字符，找出其中最长的，复杂度非常高。优化一些的思路
         * 是稍微动态规划一下，每次定一个起点，然后从起点走到有重复字符位置，
         * 过程用一个HashSet维护当前字符集，认为是constant操作，这样算法要
         * 进行两层循环，复杂度是O(n^2)。
         * 
           最后，我们介绍一种线性的算法，也是这类题目最常见的方法。基本思路
         * 是维护一个窗口，每次关注窗口中的字符串，在每次判断中，左窗口和右窗
         * 口选择其一向前移动。同样是维护一个HashSet, 正常情况下移动右窗口，
         * 如果没有出现重复则继续移动右窗口，如果发现重复字符，则说明当前窗口中
         * 的串已经不满足要求，继续移动有窗口不可能得到更好的结果，此时移动左窗口，
         * 直到不再有重复字符为止，中间跳过的这些串中不会有更好的结果，因为他们
         * 不是重复就是更短。因为左窗口和右窗口都只向前，所以两个窗口都对每个元素
         * 访问不超过一遍，因此时间复杂度为O(2*n)=O(n),是线性算法。空间复杂度
         * 为HashSet的size,也是O(n).
         * 
         * julia's comment:
         * 1. let us go over the thought process
         *    As we know, maintain two pointers for sliding window; will have O(N) solution
         *    if sliding start pointer to move x number of chars (sliding a few chars...tricky part) 
         *    to avoid duplicate char;
         *    end pointer just moves one by one by iterating through the string
         *    step 1: base case: null or length is 0 
         *    step 2: create a hashset, two pointers for a sliding window
         *    step 3: move end pointer one by one, get into a loop 
         *    step 4: inside the loop, check the end pointer char is in hashset or not
         *    step 5: if it is in, then, update max length if necessary; 
         *    second job - most important one, slide the left side of window to next 
         *    position to avoid duplication. How? 
         *    Get into the second loop ! ( Do not worry, still O(N) solution, every char gets in/out once)
         *    
         * 2. code can be as simple as 10 minutes, and then, there is a chance to perform in 
         *    10-15 minutes.
         *    
         *    online judge: 
         *  981 / 981 test cases passed.
	        Status: Accepted
            Runtime: 156 ms
         *    
         *    
         */
        public static int lengthOfLongestSubstring(String s)
        {
            int len = s.Length;

            if (s == null || len == 0)
                return 0;

            HashSet<Char> set = new HashSet<Char>();

            int max = 0;
            int start = 0;   // two pointers: start, end both from 0
            int end   = 0;  
            while (end < len)
            {
                if (set.Contains(s[end]))
                {
                    if (max < end - start)
                    {
                        max = end - start;
                    }

                    for(;;)                     // go through a loop to find next pos for start 
                    {                           // although it is an inside loop, seems like O(n^2)
                                                // but, it only goes out at most once, no repetition,
                                                // still O(n)
                        bool foundTheOne = s[start] == s[end];
                        if (foundTheOne)                    
                            break;
                                               
                        set.Remove(s[start]);   // remove all chars from sliding range 
                                                // for example, "abcb", sliding window "abc", 
                                                // sliding range is "a", 
                                                // remove 'a' from hashset
                        start++;
                    }

                    start++;
                }
                else
                {
                    set.Add(s[end]);
                }

                end++;
            }

            max = Math.Max(max, end - start);

            return max;
        }  
    }
}
