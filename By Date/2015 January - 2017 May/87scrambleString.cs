using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scrambleString
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "great";
            string s2 = "eatgr";

            bool result = isScramble(s1, s2);
            bool result1_dp = isScramble(s1,s2); 

            s2 = "rgeat";
            bool result2 = isScramble(s1, s2);

        }


        /**
         * http://fisherlei.blogspot.ca/2013/01/leetcode-scramble-string.html
         * [解题思路]
        首先想到的是递归，简单明了，对两个string进行partition，然后比较四个字符串段。但是递归的话，这个时间复杂度比较高。然后想到能否DP，但是即使用DP的话，也要O(n^3)。想想算了，还是在递归里做些剪枝，这样就可以避免冗余计算：
    对于每两个要比较的partition，统计他们字符出现次数，如果不相等返回。
         */
        /*
         * https://helloworld-chasecoder.rhcloud.com/?p=21
         * Recursive, time complexity O(N^6), space complexity O(1), too much time
         * Good for understanding the problem
         * */
        public static bool isScramble(string s1, string s2)
        {

            int l1 = s1.Length;
            int l2 = s2.Length;

            if (l1 != l2) return false;

            int[] A = new int[26];

            //memset(A,0,26*sizeof(A[0])); 
            // do some pruning, assume that two strings have same chars; 
            for (int i = 0; i < 26; i++)
                A[i] = 0;

            for (int i = 0; i < l1; i++)
            {
                A[s1[i] - 'a']++;
            }

            for (int i = 0; i < l2; i++)
            {
                A[s2[i] - 'a']--;
            }

            for (int i = 0; i < 26; i++)
            {
                if (A[i] != 0)
                    return false;
            }

            if (l1 == 1 && l2 == 1) return true;

            for (int i = 1; i < l1; i++)
            {
                String s11 = s1.Substring(0, i);
                String s12 = s1.Substring(i);
                String s21 = s2.Substring(0, i);
                String s22 = s2.Substring(i);

                if (isScramble(s11, s21) && isScramble(s12, s22))
                    return true;

                s21 = s2.Substring(0, l2 - i);
                s22 = s2.Substring(l2 - i);

                if (isScramble(s11, s22) && isScramble(s12, s21))
                    return true;
            }
            return false;
        }


        /*
         * http://blog.csdn.net/fightforyourdream/article/details/17707187
         * http://blog.csdn.net/linhuanmars/article/details/24506703
         * http://qiang129.blogspot.ca/2013/05/leetcode-scramble-string.html
         * DP time complexity O(n^3) space complexity O(n^3)
         */
        public static bool isScrambleDP(String s1, String s2) {  
            int len = s1.Length; 
            int len2 = s2.Length; 

            if(len != len2){  
                return false;  
            }  

            if(len == 0){  
                return true;  
            }  
          
            /* Julia first time to use toCharArray function on June 5, 2015 */
            char[] c1 = s1.ToCharArray();   
            char[] c2 = s2.ToCharArray();
  
            // canTransform 第一维为子串的长度delta，第二维为s1的起始索引，第三维为s2的起始索引  
            // canTransform[k][i][j]表示s1[i...i+k]是否可以由s2[j...j+k]变化得来。  
            bool[][][] canT = new bool[len][][];

            /* learn how to declare jagged arrays in C# on June 6, 2015 
            * https://msdn.microsoft.com/en-us/library/aa288453%28v=vs.71%29.aspx */
            // Create the jagged array            
            for (int i = 0; i < len; i++)
            {
                canT[len][i] = new bool[len];                
            }

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {    // 如果字符串总长度为1，则取决于唯一的字符是否想到  
                    canT[0][i][j] = c1[i] == c2[j];
                }
            }  
          
            for(int k=2; k<=len; k++){       // 子串的长度  
                for(int i=len-k; i>=0; i--){         // s1[i...i+k]  
                    for(int j=len-k; j>=0; j--){ // s2[j...j+k]  
                        bool canTransform = false;  

                        for(int m=1; m<k; m++){  // 尝试以m为长度分割子串  
                            // canT[k][i][j]  
                            canTransform = (canT[m-1][i][j] && canT[k-m-1][i+m][j+m]) ||    // 前前后后匹配  
                                              (canT[m-1][i][j+k-m] && canT[k-m-1][i+m][j]); // 前后后前匹配  
                            if(canTransform){  
                                break;  
                            }  
                        }  

                        canT[k-1][i][j] = canTransform;  
                    }  
                }  
            }  
          
            return canT[len-1][0][0];  
        }
    }
}
