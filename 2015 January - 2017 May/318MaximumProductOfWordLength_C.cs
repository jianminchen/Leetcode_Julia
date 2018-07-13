using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _318MaximumProductOfWordLength_C
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
    * 1. Put bit operation code here. 
    */
    class Solution
    {
        static void Main(string[] args)
        {
            IList<string> words = new List<string> { "a", "ab", "abc", "d", "cd", "bcd", "abcd" };
            //IList<string> words = new List<string> { "ab", "bcd" };
            // result: 4, two words, "ab", "cd"
            int result = maxProduct(words);

        }

        /*
         * 1. 26 chars - 
         * 2. get a list of list with 26 chars 
         * 3. Two words contains the same char - extract to a function
         * 
         *   
         */
        public static int maxProduct(IList<string> words)
        {
            int n = words.Count;

            IList<int> elements = getListWithInitilization(n);

            for (int i = 0; i < n; i++)
                elements[i] = getIntExpression(words[i]);

            int ans = 0;
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                {                    
                    if (twoWordsDifferent_OneByOne(elements[i], elements[j]))
                    {
                        int current = words[i].Length * words[j].Length;

                        ans = current > ans ? current : ans;
                    }
                }

            return ans;
        }


        /*
         * Extract to a function
        */
        private static IList<int> getListWithInitilization(int n)
        {
            IList<int> elements = new List<int>();
            for (int i = 0; i < n; i++)
                elements.Add(0);

            return elements;
        }        

        /*
         * Feb. 8, 2016
         * 
         * Write down this second version of check: 
         * 
         * go through each char from a to z, to compare two input arguments.  
         * If two of them are the same, with value 1, then return false
         * 
         * Tip: 1. get the char using "int ch = 1<<i"
         *      2. Instead of AND operation between two input strings, both work against ch 
         *      
         * Bug001 - design problem on bit manipulation      
         * This version of code has a bug: 
         * ab, bcd, both contain b, but the order of checking does not work
         */
        private static bool twoWordsDifferent_OneByOne_Bug001(int s1, int s2)
        {
            for (int i = 0; i < 26; i++)
            {
                int ch = 1 << i;
                if (((s1 & ch) == 1) && ((s2 & ch) == 1))
                    return false;
            }

            return true;
        }

        /*
         * Feb. 8, 2016
         * Need to check all the bits 
         */
        private static bool twoWordsDifferent_OneByOne(int s1, int s2)
        {
            for (int i = 0; i < 26; i++)
            {
                int ch = 1 << i;

                if (bitContaining(s1, ch) && bitContaining(s2, ch))
                    return false;
            }

            return true;
        }

        /*
         * check all the bits in the integer, and then, figure out
         * 
         * Two bugs in the function design: Julia, think about more before you write <- save your time, improve your performance
         * BUG002: 
         * IF WORD CONTAINS CHAR, THEN TMP & CH > 0, NOT ==1 
         * 
         * JULIA HAS TO GET MORE WORK ON BIT MANIPULATION -> ANOTHER PRACTICE
         * 
         * BUG003: 
         * int tmp = s << i;  <-  does not make sense, left shift i bit <- only apply to 1 makes sense to get 'a'+ i
         */
        private static bool bitContaining_bug002(int s, int ch)
        {
            for (int i = 0; i < 26; i++)
            {
                int tmp = s << i;
                if ((tmp & ch) == 1)
                    return true;
            }

            return false;
        }

        /*
         * IF THERE IS ONE BIT 1 IN THE INTERGER, THEN IT IS BIGT THAN 0 
         */
        private static bool bitContaining_bug003(int s, int ch)
        {
            for (int i = 0; i < 26; i++)
            {
                int tmp = s << i;
                if ((tmp & ch) > 0)
                    return true;
            }

            return false;
        }

        /*
         * bitContaining_notNeccessary -> bitContaining
         * 
         * Do not shift 
         */
        private static bool bitContaining(int s, int ch)
        {
            if ((s & ch) > 0)
                return true;

            return false;
        }

        /*
         * Extract to a function
         * 1. Use one integer to express a string 
         * 2. Interger has 32 bit, each bit from 0 to 26 expresses 
         *    a, b, c, ...
         * 3. We only need to compare if two string contains the same char, so it does not matter
         *    the order of chars in the string. 
         *    if string aaa, then 1; also string a, then 1 is the expression as well. 
         * 4. Review bit operation | 
         * https://msdn.microsoft.com/library/8xftzc7e(v=vs.100).aspx
         * 14 << 2 <-  14 (00001110 in binary shifted left two bits equals 56 (00111000 in binary). 
         * 
         * Julia confused that 14 << 2, left shift 2 times, she thought opposite - 2 shift 14 times. 
         * - look up google and then find out this design - remember the associativity - left to right for bitwise shift
         * 
         * Read the blog:
         * https://msdn.microsoft.com/en-us/library/2bxt6kc4.aspx
         * 
         * about precedence and associatity 
         * Precedence and Associativity of C Operators
         * symbol:            << 
         * Type of operation: bitwise shift 
         * Associativity:     left to right 
         * 
         * 
         * 5. Integer expression cannot reverse back to the string, but it does not matter for problem solving.    
         * Bug001 - word[i] - 'a' 
         */
        private static int getIntExpression(string word)
        {
            int res = 0;
            for (int i = 0; i < word.Length; i++)
                res |= 1 << (word[i] - 'a');

            return res;
        }
    }
}
