using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _67AddBinary2
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /*
         * source code from blog
         * http://fisherlei.blogspot.ca/2013/01/leetcode-add-binary.html
         * 
         * julia's comment: 
         * Leetcode online judge:
         *   294 / 294 test cases passed.
             Status: Accepted
             Runtime: 128 ms
         * 
         * Write down thought process: 
         * two string, go through one loop with two indexes, one is for string a, another one is for string b; 
         * the iteration is from right to left, decreasing order; 
         * althought two strings with different length, the addition will still continue normally
         * considering the carry and one or two numbers from input argument. 
         * The tip is to set addition integer to 0 if the string index is < 0 
         */
        string addBinary(string a, string b) {  
          int carry =0;  
          string result = "";

          int aLen = a.Length;
          int bLen = b.Length; 

          for(int i = aLen - 1, j = bLen - 1;    // from rightmost digit to left
               i >=0 || j>=0; 
               --i,--j
             )  
          {  
            int ai = i>=0? a[i]-'0':0;  
            int bj = j>=0? b[j]-'0':0;  
            int val = (ai+bj+carry)%2;  
            carry = (ai+bj+carry) /2;
            char c = (char)(val + '0'); 

            result = c.ToString()+result;  
          } 
 
          if(carry ==1)  
          {
              result = "1" + result; ;  
          }  

          return result;  
        } 
    }
}
