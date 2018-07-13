using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditDistance
{
    class Program
    {
        static void Main(string[] args)
        {

            int result1 = minDistance("abc", "abcd");
            int result2 = minDistance("abc", "bca");
            int result3 = minDistance("abc", "cba"); 
        }

        /**
         * Latest update: June 17, 2015
         * Leetcode: edit distance 
         * DP bottom-up  
         * Dynamic programming 
         * Time O(mxn), space O(mxn),
         * 
         * http://blog.csdn.net/fightforyourdream/article/details/13169573
         * there is a table to explain how to build this distance table:
         * http://www.cnblogs.com/etcow/archive/2012/08/30/2662985.html
         * Test cases: 
         * 1. abc, abcd, minimum distance is 1
         * 2. abc, bca,  minimum distance is 2
         * 3. abc, cba,  minimum distance is 2 
         * 4. 
         * Leetcode online judge:
         * 1146 / 1146 test cases passed.
            Status: Accepted
            Runtime: 208 ms
         * */
        public static int minDistance(String word1, String word2) {  
            int l1 = word1.Length; 
            int l2 = word2.Length; 

            int[][] distance = new int[l1+1][];
  
            for(int i = 0; i<l1+1;i++)
                distance[i] = new int[l2+1]; 
          
            // 边界情况：当其中一个string为空时，只要一直添加或删除就可以  
            for(int i=0; i< l1+1; i++){  
                distance[i][0] = i;  
            } 
 
            for(int j=1; j< l2+1; j++){  
                distance[0][j] = j;  
            }  
          
            // 递推，[i][j]处可以由左，上，左上3种情况而来  
            for(int i=1; i< l1+1; i++){  
                for(int j=1; j< l2+1; j++){  
                     int tmp = Math.Min(distance[i-1][j]+1,   // 从上演变  
                                        distance[i][j-1]+1); // 从左演变  
                 
                     // 从左上演变，考虑是否需要替换 
                     // avoid word1, word2 index out of range bug - how?
                     // word1: index range from 0->l1-1
                     // word2: index range from 0->l2-1
                     // but distance[i][j] is between word1's substring from 0 to i-1 and word2's substring from i to j-1; 
                     //  not 0 to i. 
                     // 
                     distance[i][j] = Math.Min(tmp, distance[i-1][j-1]+((word1[i-1]==word2[j-1]) ? 0 : 1));                  
                }  
            }  

            // 返回右下角
            return distance[l1][l2];          
        } 
    }
}
