using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _318MaximumProductOfWordLength
{
    /*
     * Leetcode 318: 
     * Given a string array words, find the maximum value of length(word[i]) * length(word[j])
     * where the two words do not share common letters. You may assume that each word will 
     * contain only lower case letters. If no such two words exist, return 0.
     * 
     * Code reference:
     * https://www.hrwhisper.me/leetcode-maximum-product-of-word-lengths/
     * 
     * Analysis from the sharing:
     * 1. 直接看看每个字符串都包括了哪个字符，然后一一枚举是否有交集：
          有交集，则乘积为0
          无交集，乘积为 words[i].length() * words[j].length()
     * 2. 其实因为全部都是小写的字母，用int 就可以存储每一位的信息。这就是位运算
          elements[i] |= 1 << (words[i][j] – ‘a’);   //把words[i][j] 在26字母中的出现的次序变为1
          elements[i] & elements[j]    // 判断是否有交集只需要两个数 按位 与 （AND）运算即可
     * 
     * More in detail, from the blog:
     * http://www.cnblogs.com/onlyac/p/5155881.html
     * 
     * 小写字母a-z是26位，一般统计是否存在我们要申请一个bool flg[26]这样的数组，但是我们在这里用int代替，
     * int是32位可以替代flg数组，用 与（&），或（1），以及向左移位（<<）就能完成。如“abcd” 的int值为 
     * 0000 0000 0000 0000 0000 0000 0000 1111，“wxyz” 的int值为 
     * 1111 0000 0000 0000 0000 0000 0000 0000，这样两个进行与（&）得到0， 如果有相同的字母则不是0。
     * 
     * Julia's analysis:
     * 1. Put the code together first. 
     */
    class Solution
    {
        static void Main(string[] args)
        {
            IList<string> words = new List<string>{"a","ab","abc","d","cd","bcd","abcd"};
            // result: 4, two words, "ab", "cd"
            int result = maxProduct(words); 
        }

        /*
         * 1. 26 chars - 
         * 2. get a list of list with 26 chars 
         * 3. Two words contains the same char - extract to a function
         * 
         * bug001 - do not break the loop - 
         */
        public static int maxProduct(IList<string> words)
        {
            int n = words.Count;

            IList<IList<int>> elements = getListWithInitilization(n); 

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    elements[i][words[i][j] - 'a']++; 
                }
            }

            int ans = 0; 
            for(int i=0; i<n; i++)
                for (int j = i + 1; j < n; j++)
                {                   
                    if (twoWordsDoNotContainSameChar(elements[i], elements[j]))
                    {
                        int current = words[i].Length * words[j].Length; 
                        
                        ans = current>ans? current : ans; 
                    }
                }

            return ans;
        }

        /*
         * Extract to a function
        */
        private static IList<IList<int>> getListWithInitilization(int n)
        {
            IList<IList<int>> elements = new List<IList<int>>();
            for (int i = 0; i < n; i++)
            {
                IList<int> tmpL = new List<int>();
                for (int j = 0; j < 26; j++)
                {
                    tmpL.Add(0);
                }

                elements.Add(tmpL);
            }

            return elements; 
        }
        /*
         * Make the function 
         * Go through all 26 chars and see if both has one. 
         * 
         */
        private static bool twoWordsDoNotContainSameChar(IList<int> s1, IList<int> s2)
        {
            for (int i = 0; i < 26; i++)            
                if (s1[i] != 0 && s2[i] != 0) // meaning: both contains char 'a' + k
                {
                    return false; 
                }
            
            return true; 
        }
    }
}
