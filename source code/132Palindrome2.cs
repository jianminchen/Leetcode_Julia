using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = minCut("a");
            int n2 = minCut("leet");
            int n3 = minCut("labac"); 
        }

        /** 
         * Latest update: July 16, 2015
         * 
         * Leetcode:
         * 
            Palindrome Partitioning II   
            Given a string s, partition s such that every substring of the partition is a palindrome.  
            Return the minimum cuts needed for a palindrome partitioning of s.  
            For example, given s = "aab", 
            Return 1 since the palindrome partitioning ["aa","b"] could be produced using 1 cut. 
         */

        /*
         * 
         * source code from blog: 
         * 
         * http://blog.csdn.net/fightforyourdream/article/details/17730939
         * 
         * and 
         * 
         * http://yucoding.blogspot.ca/2013/08/leetcode-question-133-palindrome.html
         * 
         * convert Java program to C# program
         * 
         * 两个DP  
         * 
         * */
        public static int minCut(String s) {  
            int len = s.Length;  
          
            // minCuts[i]: s[0,i]最小需要的切割数才能使每个子段都是回文  
            int[] minCuts = new int[len];  
          
            //isPld[i][j]:true 当且仅当子串s[i...j]是回文时  
            bool[][] isPld = new bool[len][];  

            for(int i =0;i<len;i++)
                isPld[i] = new bool[len]; 
  
            // 生成isPld[][]   
            // isPld[i][j] = true if s[i]==s[j] and (isPld[i+1][j-1]==true or j-i<2 )  
            // j-i<2: 当只有1位字符串时肯定是回文  
            // 根据递推关系,要从左下向右上推导  

            // julia comment: based on assumption: i<=j, substring [i...j]
            // let substring [start...end], more readable       
            for(int start=len-1; start>=0; start--){ // 从下往上 i：起始下标  
                for(int end=start; end<len; end++){    // 从左往右 j：结尾下标  // julia's comment: j=i;i<len;j++

                    // 是回文当且仅当头尾字符相同，且中间也是回文  
                    // julia comment: add two explanable variables 
                    // 1.  the first and last char are the same in the string
                    // 2.  the middle part is also palindrome
                    bool theFirstAndLastIsSameChar = s[start]==s[end]; 
                    bool middlePalindrome = (end-start<2) || isPld[start+1][end-1]; 

                    if(theFirstAndLastIsSameChar && middlePalindrome){  
                        isPld[start][end] = true;  
                    }else{  
                        isPld[start][end] = false;  
                    }  
                }  
            }  
          
            // 生成minCuts[]  
            for(int i=0; i<len; i++){    // 长度为i的字串s[0,i]  

                int mc = len;     // julia: default value, assuming no palindrome substring with length>1, need len's cut 

                if(isPld[0][i]){        // 本身就是回文，因此无需切割  

                    minCuts[i] = 0;  

                }else{
                    // 遍历切割，s[0,1]+s[2,i]; s[0,2]+s[3,i]; s[0,3]+s[4,i] ... s[0,i-1]+s[i,i]  
                    for(int j=0; j<i; j++){  
                        if(isPld[j+1][i]){  // 如果后半段是回文  
                            mc = Math.Min(mc, minCuts[j] + 1);  
                        }  
                    }  

                    minCuts[i] = mc;  
                }  
            }  

            return minCuts[len-1];  
        }

        /*
         * 
         * source code from blog: 
         * 
         * http://blog.csdn.net/fightforyourdream/article/details/17730939
         * 
         * TLE 基于DFS - depth first search algorithm 
         */
        public static int minCut2(String s)
        {
            ArrayList  ret = new ArrayList();
            ArrayList  al = new ArrayList ();
            Hashtable ht = new Hashtable();

            int[] min = { Int32.MaxValue };
            dfs(s, 0, ht, ret, al, 0, min);
            return min[0];
        }
        /**
         *  julia comment: 
         *    argument list: 
         *    
         */
        public static void dfs(String s, 
            int         start, 
            Hashtable   ht, 
            ArrayList   ret, 
            ArrayList   al, 
            int         cnt, 
            int[]       min)
        {
            int len = s.Length;

            if (start == len)
            {
                ret.Add(new ArrayList(al));
                min[0] = Math.Min(min[0], cnt - 1);
                return;
            }

            for (int i = start; i < len; i++)
            {
                bool isPalindrome = false;
                // julia comment: java substring(startIndex, endIndex) 
                // convert to C# Substring (startIndex, length) 
                String substr = s.Substring(start, i + 1-start+1);
                
                if (ht.Contains(substr))
                {
                    isPalindrome = ht.Contains(substr);
                }
                else
                {
                    isPalindrome = checkPalindrome(substr);
                    ht.Add(substr, isPalindrome);
                }

                if (isPalindrome)
                {
                    al.Add(substr);

                    // julia comment: 
                    dfs(s, i + 1, ht, ret, al, cnt + 1, min);

                    al.Remove(al.Count - 1);
                }
            }
        }

        public static bool checkPalindrome(String s)
        {
            int len = s.Length; 

            if (len == 0)
            {
                return true;
            }

            for (int i = 0; i <= len / 2; i++)
            {
                if (s[i] != s[len - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }        
    }
}
